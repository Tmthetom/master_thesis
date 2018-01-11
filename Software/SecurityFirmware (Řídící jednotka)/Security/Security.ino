
/*
TODO: Fix memory leaks from String (object) arrays using reserve.
... Until fixed, maxSensors|maxSwitches set to 6.
-> nameSensor
-> nameSwitch

TODO: Consider memory saving using PROGMEM
*/

#pragma region Initialization

/* Include libraries */

//#include <avr/pgmspace.h>
//#include <EEPROM.h>
//#include <SoftwareSerial.h>  // GSM communication

/* Setting */

#define baudRate 9600
#define maxSensors 6  // Ideal size for Arduino memory, Atmega can stop working when number grows, when changing, call InitialFillMemory()
#define maxSwitches 6  // Ideal size for Arduino memory, Atmega can stop working when number grows, when changing, call InitialFillMemory()
#define maxBytesOfMessageIn 100
#define maxBytesOfMessageOut 500  // Encrease this, when maximum number of devices encreased
#define maxNameLength 30  // In bytes, when changing, call InitialFillMemory()

/* Strings */

// Common
const static char stringEquals[] = " = ";
const static char stringId[] = "Id";
const static char stringPin[] = "Pin";
const static char stringName[] = "Name";
const static char stringState[] = "State";
const static char stringType[] = "Type";
const static char stringSeparator[] = ",";

// Functions
const static char leftBracket = '(';
const static char rightBracket = ')';

// Sensor
const static char stringSensorCategory[] = "Sensor";
const static char stringSensorsCategory[] = "Sensors";
const static char stringGetAllSensors[] = "GetAllSensors";
const static char stringSetSensorName[] = "SetSensorName";
const static char stringSetSensorPin[] = "SetSensorPin";
const static char stringSetSensorType[] = "SetSensorType";
const static char stringAddSensor[] = "AddSensor";
const static char stringDeleteSensor[] = "DeleteSensor";

// Switch
const static char stringSwitchCategory[] = "Switch";
const static char stringSwitchesCategory[] = "Switches";
const static char stringGetAllSwitches[] = "GetAllSwitches";
const static char stringSetSwitchState[] = "SetSwitchState";
const static char stringSetSwitchName[] = "SetSwitchName";
const static char stringSetSwitchPin[] = "SetSwitchPin";
const static char stringAddSwitch[] = "AddSwitch";
const static char stringDeleteSwitch[] = "DeleteSwitch";

// Answers
const static char stringOk[] = "OK";
const static char stringError[] = "ERROR";

/* Variables */

// Communication common
String in;
String out;

// Communication USB
bool inComplete = false;

// Communication GSM
//SoftwareSerial gsm(10, 11); // RX, TX
String arduinoReceived = "";  // Console text before received message
String arduinoSending = "[-->] ";  // Console text before sended message
int command = 0;  // Number of initialisation command in row
int numberOfDots;  // For watingForIP, number of dots in IP
bool watingForResponse = false;
bool watingForIP = false;
bool initCompleted = false;

// Sensor
uint8_t pinSensor[maxSensors];
uint8_t stateSensorOld[maxSensors];
uint8_t stateSensorNew[maxSensors];
bool typeSensor[maxSensors];  // true = push-to-make, false = push-to-break
String nameSensor[maxSensors];

// Switch
uint8_t pinSwitch[maxSwitches];
String nameSwitch[maxSwitches];

/* Setup before start */
void setup() {

	// Read memory
	//InitialFillMemory();

	// Sensors
	/*
	pinSensor[0] = 11;
	nameSensor[0] = "Door Sensor";
	typeSensor[0] = false;  // Normaly open type = NO = Push to break

	pinSensor[1] = 6;
	nameSensor[1] = "PIR Sensor";
	typeSensor[1] = true;  // Normaly close type = NC = Push to make
	setPinMode(pinSensor, sizeof(pinSensor) / sizeof(uint8_t), INPUT);
	getSensorsState(pinSensor, sizeof(pinSensor) / sizeof(uint8_t), stateSensorOld);
	*/

	// Switches
	pinSwitch[0] = 5;
	nameSwitch[0] = "Led Switch 1";
	setPinMode(pinSwitch, sizeof(pinSwitch) / sizeof(uint8_t), OUTPUT);
	digitalWrite(pinSwitch[0], HIGH);

	pinSwitch[1] = 6;
	nameSwitch[1] = "Led Switch 2";
	setPinMode(pinSwitch, sizeof(pinSwitch) / sizeof(uint8_t), OUTPUT);
	digitalWrite(pinSwitch[1], HIGH);

	pinSwitch[2] = 7;
	nameSwitch[2] = "Led Switch 3";
	setPinMode(pinSwitch, sizeof(pinSwitch) / sizeof(uint8_t), OUTPUT);
	digitalWrite(pinSwitch[2], HIGH);

	// Allocation
	in.reserve(maxBytesOfMessageIn);
	out.reserve(maxBytesOfMessageOut);

	// Connect USB communication
	Serial.begin(baudRate);

	// Connect GSM communication
	Serial1.begin(baudRate);
	sendCommand("AT");
}

/* Connect to server thru GSM */
void connectToServer() {
	switch (command) {

		// Connection
	case 0:
		sendCommand("AT+CIPSHUT");
		command++;
		break;
	case 1:
		sendCommand("AT+CIPMUX=0");
		command++;
		break;
	case 2:
		sendCommand("AT+CGATT=1");
		command++;
		break;
	case 3:
		sendCommand("AT+CSTT=\"internet\"");
		command++;
		break;
	case 4:
		sendCommand("AT+CIICR");
		command++;
		break;
	case 5:
		sendCommand("AT+CIFSR");
		watingForIP = true;
		command++;
		break;
	case 6:
		sendCommand("AT+CIPSTART=\"TCP\",\"81.200.57.24\",\"6666\"");
		command++;
		break;

	// Authentication
	case 7:
		sendMessage("Security");
		initCompleted = true;
		break;
	default:
		;
	}
}

#pragma endregion

#pragma region Main program

/* Main program loop */
void loop() {

	// Check if sensor state changed
	checkSensorStateChangedAndSendIfTrue();

	// Communication
	readSerialAndRespond();
	readGsmAndRespond();
}

/* Read gsm message and respond */
void readGsmAndRespond() {

	// Wating for response
	if (watingForResponse) {

		// Response (GSM -> PC)
		if (Serial1.available()) {

			// Send received message to console
			in = Serial1.readString();
			in.trim();
			Serial.println(arduinoReceived + in);

			// Check if command runs OK
			if (in.endsWith("OK")) {
				watingForResponse = false;
				Serial.println();
			}
			
			// When wating for client IP, check if runs OK
			else if (watingForIP) {
				for (int i = 0; i < in.length(); i++) {
					if (in.charAt(i) == '.') {
						numberOfDots++;
						Serial.println();
					}
				}
				if (numberOfDots >= 3) {
					watingForIP = false;
					watingForResponse = false;
				}
				numberOfDots = 0;
			}
		}
	}

	// Initialisation
	else {
		if (initCompleted == false) connectToServer();
		else {
			// Read communication
			if (Serial1.available()) {

				in = Serial1.readString();
				in.trim();
				Serial.println(arduinoReceived + in);

				// Sensors
				if (in.equalsIgnoreCase(stringGetAllSensors)) getAllSensors();

				// Switches 
				else if (in.equalsIgnoreCase(stringGetAllSwitches)) getAllSwitches();
				else if (in.startsWith(stringSetSwitchState)) setSwitchState();
			}
		}
	}
}

/* Read serial message and respond */
void readSerialAndRespond() {
	if (inComplete && in.length() != 0) {

		// Sensors
		if (in.equalsIgnoreCase(stringGetAllSensors)) getAllSensors();
		else if (in.startsWith(stringSetSensorName)) setSensorName();
		else if (in.startsWith(stringSetSensorPin)) setSensorPin();
		else if (in.startsWith(stringSetSensorType)) setSensorType();
		else if (in.startsWith(stringAddSensor)) addSensor();
		else if (in.startsWith(stringDeleteSensor)) deleteSensor();

		// Switches 
		else if (in.equalsIgnoreCase(stringGetAllSwitches)) getAllSwitches();
		else if (in.startsWith(stringSetSwitchState)) setSwitchState();
		else if (in.startsWith(stringSetSwitchName)) setSwitchName();
		else if (in.startsWith(stringSetSwitchPin)) setSwitchPin();
		else if (in.startsWith(stringAddSwitch)) addSwitch();
		else if (in.startsWith(stringDeleteSwitch)) deleteSwitch();

		// Not recognized
		else sendMessageNotRecognized();

		in = "";
		inComplete = false;
	}
}

#pragma endregion

#pragma region API (Public methods)

#pragma region Getters

/* Send all sensors */
void getAllSensors() {
	out = String(stringSensorsCategory) + leftBracket;													// Name of category
	for (uint8_t i = 0; i < sizeof(pinSensor) / sizeof(uint8_t); i++) {
		if (pinSensor[i] != NULL) {
			out +=
				String(leftBracket) + stringId + stringEquals + String(i) + stringSeparator + 	// ID
				stringPin + stringEquals + String(pinSensor[i]) + stringSeparator +				// Pin 
				stringName + stringEquals + String(nameSensor[i]) + stringSeparator +			// Name
				stringState + stringEquals + String(stateSensorOld[i]) + stringSeparator + 		// State
				stringType + stringEquals + String(typeSensor[i]) + rightBracket				// Type
				;
		}
	}
	out += rightBracket;
	Serial.println(out);
	sendMessage(out);
}

/* Send all switches */
void getAllSwitches() {
	out = String(stringSwitchesCategory) + leftBracket;													// Name of category
	for (uint8_t i = 0; i < sizeof(pinSwitch) / sizeof(uint8_t); i++) {
		if (pinSwitch[i] != NULL) {
			out +=
				String(leftBracket) + stringId + stringEquals + String(i) + stringSeparator + 	// ID
				stringPin + stringEquals + String(pinSwitch[i]) + stringSeparator +				// Pin 
				stringName + stringEquals + String(nameSwitch[i]) + stringSeparator +			// Name
				stringState + stringEquals + String(getSwitchState(i)) + rightBracket			// State
				;
		}
	}
	out += rightBracket;
	Serial.println(out);
	sendMessage(out);
}

#pragma endregion

#pragma region Setters

#pragma region Sensor

/* Set sensor name */
void setSensorName() {

	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	uint8_t sep = stringAfter.indexOf(stringSeparator);									// Get index of separator
	uint8_t id = stringAfter.substring(0, sep).toInt();									// Get Id
	String name = stringAfter.substring(sep + 1);										// Get Value

	// Check if exists
	if (pinSensor[id] == NULL) {
		Serial.println(stringError);
		return;
	}

	// Check if value not same
	String before = nameSensor[id];
	if (before == name) {
		Serial.println(stringError);
		return;
	}

	// Do rename
	nameSensor[id] = name;

	// Check if changed
	String after = nameSensor[id];
	if (before == after) {
		Serial.println(stringError);
		return;
	}

	// Send OK
	Serial.println(stringOk);
}

/* Set sensor pin */
void setSensorPin() {

	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	uint8_t sep = stringAfter.indexOf(stringSeparator);									// Get index of separator
	uint8_t id = stringAfter.substring(0, sep).toInt();									// Get Id
	uint8_t val = stringAfter.substring(sep + 1).toInt();								// Get Value

	// Check if exists
	if (pinSensor[id] == NULL) {
		Serial.println(stringError);
		return;
	}

	// Check if value not same
	uint8_t before = pinSensor[id];
	if (before == val) {
		Serial.println(stringError);
		return;
	}

	// Do change
	pinSensor[id] = val;

	// Check if changed
	uint8_t after = pinSensor[id];
	if (before == after) {
		Serial.println(stringError);
		return;
	}

	// Check new state
	getSensorsState(pinSensor, sizeof(pinSensor) / sizeof(uint8_t), stateSensorOld);

	// Send OK
	pinMode(before, OUTPUT);			// Old pin to Output
	pinMode(val, INPUT);				// New pin to Input
	Serial.println(stringOk);
}

/* Set sensor type */
void setSensorType() {

	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	uint8_t sep = stringAfter.indexOf(stringSeparator);									// Get index of separator
	uint8_t id = stringAfter.substring(0, sep).toInt();									// Get Id
	uint8_t val = stringAfter.substring(sep + 1).toInt();								// Get Value

	// Check if exists
	if (pinSensor[id] == NULL) {
		Serial.println(stringError);
		return;
	}

	// Set type
	typeSensor[id] = (val == 1) ? true : false;


	// Send OK
	Serial.println(stringOk);
}

/* Add sensor */
void addSensor() {

	// Get wanted Pin
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	uint8_t sep1 = stringAfter.indexOf(stringSeparator);								// Get index of separator
	uint8_t pin = stringAfter.substring(0, sep1).toInt();								// Get Id
	uint8_t sep2;
	String s;

	// Name
	s = stringAfter.substring(sep1 + 1);												// String from current separator to end
	sep2 = s.indexOf(stringSeparator);													// Get index of another separator
	String name = s.substring(0, sep2);													// Get Value
	sep1 = sep2;																		// Save position of last separator as first

	// Type
	s = s.substring(sep1 + 1);															// String from current separator to end
	sep2 = s.indexOf(stringSeparator);													// Get index of another separator
	uint8_t type = s.substring(0, sep2).toInt();										// Get Value
	sep1 = sep2;																		// Save position of last separator as first

	// Find free space, get ID and set Pin
	uint8_t id = 0;
	bool set = false;
	for (uint8_t i = 0; i < sizeof(pinSensor) / sizeof(uint8_t); i++) {
		if (pinSensor[i] == NULL) {
			id = i;
			pinSensor[i] = pin;
			set = true;
			break;
		}
	}

	// Check if free space founded
	if (!set) {
		pinSensor[id] = NULL;
		Serial.println(stringError);
		return;
	}

	// Check if pin setted
	uint8_t pinAfter = pinSensor[id];
	if (pinAfter != pin) {
		pinSensor[id] = NULL;
		Serial.println(stringError);
		return;
	}

	// Set name
	nameSensor[id] = name;

	// Check if name setted
	String nameAfter = nameSensor[id];
	if (!nameAfter.equals(name)) {
		pinSensor[id] = NULL;
		Serial.println(stringError);
		return;
	}

	// Set type
	typeSensor[id] = (type == 1) ? true : false;

	// Read new sensor state
	getSensorsState(pinSensor, sizeof(pinSensor) / sizeof(int), stateSensorOld);

	// Send OK
	pinMode(pin, INPUT);			// New pin to INPUT
	Serial.println(stringOk);
}

/* Delete sensor */
void deleteSensor() {
	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	uint8_t id = stringAfter.toInt();													// Get Value

	// Check if exists
	if (pinSensor[id] == NULL) {
		Serial.println(stringError);
		return;
	}

	// Delete pin
	uint8_t pin = pinSensor[id];
	pinSensor[id] = NULL;

	// Delete name
	nameSensor[id] = "";

	// Delete type
	typeSensor[id] = false;

	// Delete states
	stateSensorOld[id] = NULL;
	stateSensorNew[id] = NULL;

	// Send OK
	Serial.println(stringOk);
}

#pragma endregion

#pragma region Switch

/* Set sensor name */
void setSwitchName() {

	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	uint8_t sep = stringAfter.indexOf(stringSeparator);									// Get index of separator
	uint8_t id = stringAfter.substring(0, sep).toInt();									// Get Id
	String name = stringAfter.substring(sep + 1);										// Get Value

	// Check if exists
	if (pinSwitch[id] == NULL) {
		Serial.println(stringError);
		return;
	}

	// Check if value not same
	String before = nameSwitch[id];
	if (before == name) {
		Serial.println(stringError);
		return;
	}

	// Do rename
	nameSwitch[id] = name;

	// Check if changed
	String after = nameSwitch[id];
	if (before == after) {
		Serial.println(stringError);
		return;
	}

	// Send OK
	Serial.println(stringOk);
}

/* Set switch state */
void setSwitchState() {

	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	uint8_t sep = stringAfter.indexOf(stringSeparator);									// Get index of separator
	uint8_t id = stringAfter.substring(0, sep).toInt();									// Get Id
	uint8_t val = stringAfter.substring(sep + 1).toInt();								// Get Value

	// Check if exists
	if (pinSwitch[id] == NULL) {
		Serial.println(stringError);
		sendMessage(stringError);
		return;
	}

	// Check if value not same
	uint8_t before = getSwitchState(id);
	if (before == val) {
		Serial.println(stringError);
		sendMessage(stringError);
		return;
	}

	// Do Switch
	digitalWrite(pinSwitch[id], (val == 1) ? HIGH : LOW);

	// Check if changed
	uint8_t after = getSwitchState(id);
	if (before == after) {
		Serial.println(stringError);
		sendMessage(stringError);
		return;
	}

	// Send OK
	Serial.println(stringOk);
	sendMessage(stringOk);
}

/* Set switch pin */
void setSwitchPin() {

	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	uint8_t sep = stringAfter.indexOf(stringSeparator);									// Get index of separator
	uint8_t id = stringAfter.substring(0, sep).toInt();									// Get Id
	uint8_t val = stringAfter.substring(sep + 1).toInt();								// Get Value

	// Check if exists
	if (pinSwitch[id] == NULL) {
		Serial.println(stringError);
		return;
	}

	// Check if value not same
	uint8_t before = pinSwitch[id];
	if (before == val) {
		Serial.println(stringError);
		return;
	}

	// Do change
	pinSwitch[id] = val;

	// Check if changed
	uint8_t after = pinSwitch[id];
	if (before == after) {
		Serial.println(stringError);
		return;
	}

	// Send OK
	pinMode(before, INPUT);			// Old pin to Input
	pinMode(val, OUTPUT);			// New pin to Output
	Serial.println(stringOk);
}

/* Add Switch */
void addSwitch() {

	// Get wanted Pin
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	uint8_t sep1 = stringAfter.indexOf(stringSeparator);								// Get index of separator
	uint8_t pin = stringAfter.substring(0, sep1).toInt();								// Get Id
	uint8_t sep2;
	String s;

	// Name
	s = stringAfter.substring(sep1 + 1);												// String from current separator to end
	sep2 = s.indexOf(stringSeparator);													// Get index of another separator
	String name = s.substring(0, sep2);													// Get Value
	sep1 = sep2;																		// Save position of last separator as first

	// State
	s = s.substring(sep1 + 1);															// String from current separator to end
	sep2 = s.indexOf(stringSeparator);													// Get index of another separator
	uint8_t state = s.substring(0, sep2).toInt();										// Get Value
	sep1 = sep2;																		// Save position of last separator as first

	// Find free space, get ID and set Pin
	uint8_t id = 0;
	bool set = false;
	for (uint8_t i = 0; i < sizeof(pinSwitch) / sizeof(uint8_t); i++) {
		if (pinSwitch[i] == NULL) {
			id = i;
			pinSwitch[i] = pin;
			set = true;
			break;
		}
	}

	// Check if free space founded
	if (!set) {
		pinSwitch[id] = NULL;
		Serial.println(stringError);
		return;
	}

	// Check if pin setted
	uint8_t pinAfter = pinSwitch[id];
	if (pinAfter != pin) {
		pinSwitch[id] = NULL;
		Serial.println(stringError);
		return;
	}

	// Set name
	nameSwitch[id] = name;

	// Check if name setted
	String nameAfter = nameSwitch[id];
	if (!nameAfter.equals(name)) {
		pinSwitch[id] = NULL;
		Serial.println(stringError);
		return;
	}

	// Set state
	digitalWrite(pin, ((state == 1) ? HIGH : LOW));

	// Send OK
	pinMode(pin, OUTPUT);			// New pin to Output
	Serial.println(stringOk);
}

/* Delete Switch*/
void deleteSwitch() {

	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	uint8_t id = stringAfter.toInt();													// Get Value

	// Check if exists
	if (pinSwitch[id] == NULL) {
		Serial.println(stringError);
		return;
	}

	// Delete pin
	uint8_t pin = pinSwitch[id];
	pinSwitch[id] = NULL;

	// Delete name
	nameSwitch[id] = "";

	// Send OK
	pinMode(pin, INPUT);			// New pin to Input
	Serial.println(stringOk);
}

#pragma endregion

#pragma endregion

#pragma endregion

#pragma region Internal functions

#pragma region Getters

/* Get all sensors state [HIGH,LOW] */
void getSensorsState(uint8_t pinSensors[], uint8_t size, uint8_t stateSensors[]) {
	for (uint8_t i = 0; i < size; i++) {
		if (pinSensors[i] != NULL) stateSensors[i] = digitalRead(pinSensors[i]);
	}
}

/* Get current selected switch state [HIGH,LOW] */
uint8_t getSwitchState(uint8_t id) {
	if (pinSwitch[id] != NULL) return digitalRead(pinSwitch[id]);
}

#pragma endregion

#pragma region Setters

/* Set pin mode [INPUT/OUTPUT] */
void setPinMode(uint8_t pins[], uint8_t size, uint8_t mode) {
	if (mode != INPUT && mode != OUTPUT) return;
	for (uint8_t i = 0; i < size; i++) {
		if (pins[i] != NULL) pinMode(pins[i], mode);
	}
}

#pragma endregion

#pragma region SecurityControl Communication

/* If command not recognized renspond to sender */
void sendMessageNotRecognized() {
	Serial.println("Command '" + in + "' not recognized.");
}

/* Serial interrput */
void serialEvent() {
	while (Serial.available()) {
		char inChar = (char)Serial.read();
		in += inChar;
		if (inChar == '\n') {
			in.trim();
			inComplete = true;
		}
	}
}

#pragma endregion

#pragma region SecurityViewer Communication

void sendCommand(String command) {
	Serial.println(arduinoSending + command);
	Serial1.println(command);
	watingForResponse = true;
}

void sendMessage(String message) {
	Serial.println(arduinoSending + "AT+CIPSEND");
	Serial1.println("AT+CIPSEND");
	delay(1000);
	Serial.println(arduinoSending + message);
	Serial1.println(message);
	delay(1000);
	Serial1.println((char)26);
	delay(1000);
}

#pragma endregion

#pragma region Autocheck fuctions

/* Check sensor state changed */
void checkSensorStateChangedAndSendIfTrue() {
	getSensorsState(pinSensor, sizeof(pinSensor) / sizeof(uint8_t), stateSensorNew);
	for (uint8_t i = 0; i < sizeof(pinSensor) / sizeof(uint8_t); i++) {
		if (pinSensor[i] != NULL) {
			if (stateSensorOld[i] != stateSensorNew[i]) {
				stateSensorOld[i] = stateSensorNew[i];
				Serial.println(
					String(stringSensorCategory) + leftBracket +								// Name of category
					String(stringId) + stringEquals + String(i) + stringSeparator +				// Id
					stringState + stringEquals + String(stateSensorOld[i]) + rightBracket		// State
				);
				sendMessage(
					String(stringSensorCategory) + leftBracket +								// Name of category
					String(stringId) + stringEquals + String(i) + stringSeparator +				// Id
					stringState + stringEquals + String(stateSensorOld[i]) + rightBracket		// State
				);
				delay(300);
			}
		}
	}
}

#pragma endregion

#pragma region Memory
/*
int null = 255;

void InitialFillMemory() {

	// Clear memory
	ClearMemory();

	// Sensors
	pinSensor[0] = 8;
	nameSensor[0] = "Door Sensor";
	typeSensor[0] = false;  // Normaly open type = NO = Push to break
	pinSensor[1] = 7;
	nameSensor[1] = "PIR Sensor";
	typeSensor[1] = true;  // Normaly close type = NC = Push to make
	setPinMode(pinSensor, sizeof(pinSensor) / sizeof(uint8_t), INPUT);
	getSensorsState(pinSensor, sizeof(pinSensor) / sizeof(uint8_t), stateSensorOld);

	// Switches
	pinSwitch[0] = 6;
	nameSwitch[0] = "Led Switch";
	setPinMode(pinSwitch, sizeof(pinSwitch) / sizeof(uint8_t), OUTPUT);
	digitalWrite(6, HIGH);

	int val;

	// Pin Sensors
	int address = 0;
	for (int i = address; i < address + maxSensors; i++) {
		val = (pinSensor[i] == NULL) ? null : pinSensor[i];
		EEPROM.write(i, val);
	}

	// Pin Switches
	address += maxSensors;
	for (int i = address; i < address + maxSwitches; i++) {
		val = (pinSwitch[i] == NULL) ? null : pinSwitch[i];
		EEPROM.write(i, val);
	}

	// Type Sensors
	address += maxSwitches;
	for (int i = address; i < address + maxSensors; i++) {
		val = (pinSensor[i] == NULL) ? null : typeSensor[i];
		EEPROM.write(i, val);
	}

	// State Switches
	address += maxSensors;
	for (int i = address; i < address + maxSwitches; i++) {
		val = (pinSensor[i] == NULL) ? null : getSwitchState(i);
		EEPROM.write(i, val);
	}
}

void ClearMemory() {
	for (int i = 0; i < EEPROM.length(); i++) {
		EEPROM.write(i, 0);
	}
}

void ReadMemory() {

	int val;

	// Pin Sensors
	int address = 0;
	for (int i = address; i < address + maxSensors; i++) {
		val = EEPROM.read(i);
		pinSensor[i] = (val == null) ? NULL : val;
	}

	// Pin Switches
	address += maxSensors;
	for (int i = address; i < address + maxSwitches; i++) {
		val = EEPROM.read(i);
		pinSwitch[i] = (val == null) ? NULL : val;
	}

	// Type Sensors
	address += maxSwitches;
	for (int i = address; i < address + maxSensors; i++) {
		val = EEPROM.read(i);
		typeSensor[i] = (val == null) ? NULL : val;
	}

	setPinMode(pinSensor, sizeof(pinSensor) / sizeof(uint8_t), INPUT);
	getSensorsState(pinSensor, sizeof(pinSensor) / sizeof(uint8_t), stateSensorOld);
	setPinMode(pinSwitch, sizeof(pinSwitch) / sizeof(uint8_t), OUTPUT);

	// State Switches
	address += maxSensors;
	for (int i = address; i < address + maxSwitches; i++) {
		val = EEPROM.read(i);

		if (val != null) {
			digitalWrite(i, val);
		}
	}
}
*/
#pragma endregion

#pragma endregion
