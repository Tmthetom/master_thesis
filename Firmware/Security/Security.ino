
#pragma region Initialization

/* Setting */

const int baudRate = 9600;
const int maxSensors = 10;
const int maxSwitches = 10;
const int maxBytesOfMessage = 200;

/* Strings */

// Common
String stringEquals = " = ";
String stringId = "Id";
String stringPin = "Pin";
String stringName = "Name";
String stringState = "State";
String stringType = "Type";
String stringSeparator = ",";
String stringOk = "OK";

// Functions
String leftBracket = "(";
String rightBracket = ")";

// Sensor
String stringSensorCategory = "Sensor";
String stringSensorsCategory = "Sensors";
String stringGetAllSensors = "GetAllSensors";
String stringSetSensorName = "SetSensorName";
String stringSetSensorPin = "SetSensorPin";
String stringAddSensor = "AddSensor";
String stringDeleteSensor = "DeleteSensor";

// Switch
String stringSwitchCategory = "Switch";
String stringSwitchesCategory = "Switches";
String stringGetAllSwitches = "GetAllSwitches";
String stringSetSwitchState = "SetSwitchState";
String stringSetSwitchName = "SetSwitchName";
String stringSetSwitchPin = "SetSwitchPin";
String stringAddSwitch = "AddSwitch";
String stringDeleteSwitch = "DeleteSwitch";

// Error
String stringError = "ERROR";

/* Variables */

// Communication
String in = "";
String out = "";
boolean inComplete = false;

// Sensor
int pinSensor[maxSensors];
int stateSensorOld[maxSensors];
int stateSensorNew[maxSensors];
bool typeSensor[maxSensors];  // true = push-to-make, false = push-to-break
String nameSensor[maxSensors];

// Switch
int pinSwitch[maxSwitches];
String nameSwitch[maxSwitches];

/* Setup before start */
void setup() {

	// Sensors
	pinSensor[0] = 8;
	nameSensor[0] = "Main Door Sensor";
	typeSensor[0] = false;  // Normaly open type = NO = Push to break
	setPinMode(pinSensor, sizeof(pinSensor) / sizeof(int), INPUT);
	getSensorsState(pinSensor, sizeof(pinSensor) / sizeof(int), stateSensorOld);

	// Switches
	pinSwitch[0] = 3;
	nameSwitch[0] = "Right Led Switch";
	pinSwitch[1] = 4;
	nameSwitch[1] = "Left Led Switch";
	setPinMode(pinSwitch, sizeof(pinSwitch) / sizeof(int), OUTPUT);

	// Communication
	in.reserve(maxBytesOfMessage);
	Serial.begin(baudRate);
}

#pragma endregion

#pragma region Main program loops

/* Main program loop */
void loop() {

	// Check if sensor state changed
	checkSensorStateChangedAndSendIfTrue();

	// Communication
	readSerialAndRespond();
}

/* Read serial message and respond */
void readSerialAndRespond() {
	if (inComplete && in.length() != 0) {
		
		// Sensors
		if (in.equalsIgnoreCase(stringGetAllSensors)) getAllSensors();
		else if (in.startsWith(stringSetSensorName)) setSensorName();

		// Switches 
		else if (in.equalsIgnoreCase(stringGetAllSwitches)) getAllSwitches();
		else if (in.startsWith(stringSetSwitchState)) setSwitchState();
		else if (in.startsWith(stringSetSwitchName)) setSwitchName();
		else if (in.startsWith(stringSetSwitchPin)) SetSwitchPin();
		else if (in.startsWith(stringAddSwitch)) AddSwitch();
		else if (in.startsWith(stringDeleteSwitch)) DeleteSwitch();

		// Not recognized
		else sendMessageNotRecognized();

		in = "";
		inComplete = false;
	}
}

#pragma endregion

#pragma region Public

#pragma region Getters

/* Send all sensors */
void getAllSensors() {
	out = stringSensorsCategory + leftBracket;													// Name of category
	for (int i = 0; i < sizeof(pinSensor) / sizeof(int); i++) {
		if (pinSensor[i] != NULL) {
			out +=
				leftBracket + stringId + stringEquals + String(i) + stringSeparator + 			// ID
				stringPin + stringEquals + String(pinSensor[i]) + stringSeparator +				// Pin 
				stringName + stringEquals + String(nameSensor[i]) + stringSeparator +			// Name
				stringState + stringEquals + String(stateSensorOld[i]) + stringSeparator + 		// State
				stringType + stringEquals + String(typeSensor[i]) + rightBracket				// Type
				;
		}
	}
	out += rightBracket;
	Serial.println(out);
}

/* Send all switches */
void getAllSwitches() {
	out = stringSwitchesCategory + leftBracket;													// Name of category
	for (int i = 0; i < sizeof(pinSwitch) / sizeof(int); i++) {
		if (pinSwitch[i] != NULL) {
			out +=
				leftBracket + stringId + stringEquals + String(i) + stringSeparator + 			// ID
				stringPin + stringEquals + String(pinSwitch[i]) + stringSeparator +				// Pin 
				stringName + stringEquals + String(nameSwitch[i]) + stringSeparator +			// Name
				stringState + stringEquals + String(getSwitchState(i)) + rightBracket			// State
				;
		}
	}
	out += rightBracket;
	Serial.println(out);
}

#pragma endregion

#pragma region Setters

#pragma region Sensor

/* Set sensor name */
void setSensorName() {

	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	int sep = stringAfter.indexOf(stringSeparator);										// Get index of separator
	int id = stringAfter.substring(0, sep).toInt();										// Get Id
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

/* Add Sensor */
void AddSensor() {

}

#pragma endregion

#pragma region Switch

/* Set sensor name */
void setSwitchName() {

	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	int sep = stringAfter.indexOf(stringSeparator);										// Get index of separator
	int id = stringAfter.substring(0, sep).toInt();										// Get Id
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
	int sep = stringAfter.indexOf(stringSeparator);										// Get index of separator
	int id = stringAfter.substring(0, sep).toInt();										// Get Id
	int val = stringAfter.substring(sep + 1).toInt();									// Get Value

	// Check if exists
	if (pinSwitch[id] == NULL) {
		Serial.println(stringError);
		return;
	}

	// Check if value not same
	int before = getSwitchState(id);
	if (before == val) {
		Serial.println(stringError);
		return;
	}

	// Do Switch
	digitalWrite(pinSwitch[id], (val == 1) ? HIGH : LOW);

	// Check if changed
	int after = getSwitchState(id);
	if (before == after) {
		Serial.println(stringError);
		return;
	}

	// Send OK
	Serial.println(stringOk);
}

/* Set switch pin */
void SetSwitchPin() {
	
	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	int sep = stringAfter.indexOf(stringSeparator);										// Get index of separator
	int id = stringAfter.substring(0, sep).toInt();										// Get Id
	int val = stringAfter.substring(sep + 1).toInt();									// Get Value

	// Check if exists
	if (pinSwitch[id] == NULL) {
		Serial.println(stringError);
		return;
	}

	// Check if value not same
	int before = pinSwitch[id];
	if (before == val) {
		Serial.println(stringError);
		return;
	}

	// Do change
	pinSwitch[id] = val;

	// Check if changed
	int after = pinSwitch[id];
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
void AddSwitch() {
	
	// Get wanted Pin
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	int sep1 = stringAfter.indexOf(stringSeparator);									// Get index of separator
	int pin = stringAfter.substring(0, sep1).toInt();									// Get Id
	int sep2;
	String s;

	// Name
	s = stringAfter.substring(sep1 + 1);												// String from current separator to end
	sep2 = s.indexOf(stringSeparator);													// Get index of another separator
	String name = s.substring(sep1 + 1, sep2);											// Get Value
	sep1 = sep2;																		// Save position of last separator as first

	// State
	s = s.substring(sep1 + 1);															// String from current separator to end
	sep2 = s.indexOf(stringSeparator);													// Get index of another separator
	int state = s.substring(sep1 + 1, sep2).toInt();									// Get Value
	sep1 = sep2;																		// Save position of last separator as first

	// Find free space, get ID and set Pin
	int id;
	bool set = false;
	for (int i = 0; i < sizeof(pinSwitch) / sizeof(int); i++) {
		if (pinSwitch[i] != NULL) {
			id = i;
			pinSwitch[i] = pin;
			set = true;
			break;
		}
	}

	// Check if free space founded
	if (!set) {
		Serial.println(stringError);
		return;
	}

	// Check if pin setted
	int pinAfter = pinSwitch[id];
	if (pinAfter != pin) {
		Serial.println(stringError);
		return;
	}

	// Set name
	nameSwitch[id] = name;

	// Check if name setted
	String nameAfter = nameSwitch[id];
	if (!nameAfter.equals(name)) {
		Serial.println(stringError);
		return;
	}

	// Set state
	digitalWrite(pin, (state == 1) ? HIGH : LOW);

	// Check if changed
	int stateAfter = getSwitchState(id);
	if (state != stateAfter) {
		Serial.println(stringError);
		return;
	}

	// Send OK
	pinMode(pin, OUTPUT);			// New pin to Output
	Serial.println(stringOk);
}

/* Delete Switch*/
void DeleteSwitch() {
	;
}

#pragma endregion

#pragma endregion

#pragma endregion

#pragma region Private

#pragma region Getters

/* Get all sensors state [HIGH,LOW] */
void getSensorsState(int pinSensors[], int size, int stateSensors[]) {
	for (int i = 0; i < size; i++) {
		if (pinSensors[i] != NULL) stateSensors[i] = digitalRead(pinSensors[i]);
	}
}

/* Get current selected switch state [HIGH,LOW] */
int getSwitchState(int id) {
	if (pinSwitch[id] != NULL) return digitalRead(pinSwitch[id]);
}

#pragma endregion

#pragma region Setters

/* Set pin mode [INPUT/OUTPUT] */
void setPinMode(int pins[], int size, int mode) {
	if (mode != INPUT && mode != OUTPUT) return;
	for (int i = 0; i < size; i++) {
		if (pins[i] != NULL) pinMode(pins[i], mode);
	}
}

#pragma endregion

#pragma region Communication

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

#pragma region Autocheck fuctions

/* Check sensor state changed */
void checkSensorStateChangedAndSendIfTrue() {
	/*
	getSensorsState(pinSensor, sizeof(pinSensor) / sizeof(int), stateSensorNew);
	for (int i = 0; i < sizeof(pinSensor) / sizeof(int); i++) {
		if (pinSensor[i] != NULL) {
			if (stateSensorOld[i] != stateSensorNew[i]) {
				stateSensorOld[i] = stateSensorNew[i];
				Serial.println(
					stringSensorCategory + leftBracket +										// Name of category
					stringId + stringEquals + stringEquals + String(i) + stringSeparator +		// Id
					stringState + stringEquals + String(stateSensorOld[i]) + rightBracket		// State
				);
			}
		}
	}*/
}

#pragma endregion

#pragma endregion
