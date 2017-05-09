
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

// Switch
String stringSwitchCategory = "Switch";
String stringSwitchesCategory = "Switches";
String stringGetAllSwitches = "GetAllSwitches";
String stringSetSwitchState = "SetSwitchState";
String stringSetSwitchName = "SetSwitchName";
String stringChangeSwitchState = "ChangeSwitchState";

// Error
String stringError = "ERROR: ";
String stringErrorIdNull = stringError + "Id is not defined.";
String stringErrorValueNotChanged = stringError + "Value not changed.";
String stringErrorNameSame = stringError + "Name is same.";
String stringErrorValueSame = stringError + "Value is same.";

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
		else if (in.equalsIgnoreCase(stringGetAllSwitches)) getAllSwitches();
		else if (in.startsWith(stringSetSwitchState)) setSwitchState();
		else if (in.startsWith(stringSetSensorName)) setSensorName();
		else if (in.startsWith(stringSetSwitchName)) setSwitchName();
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
				stringState + stringEquals + String(stateSensorOld[i]) + rightBracket			// State
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
		Serial.println(stringErrorIdNull);
		return;
	}

	// Get current name
	String before = nameSensor[id];
	if (before == name) {
		Serial.println(stringErrorNameSame);
		return;
	}

	// Do rename
	nameSensor[id] = name;
	String after = nameSensor[id];
	if (before == after) {
		Serial.println(stringErrorValueNotChanged);
		return;
	}

	// Send OK
	Serial.println(stringOk);
}

/* Set sensor name */
void setSwitchName() {

	// Get wanted id and value
	String stringBefore = in.substring(in.indexOf(leftBracket) + 1);					// Get text after '('
	String stringAfter = stringBefore.substring(0, stringBefore.indexOf(rightBracket));	// Get text before ')'
	int sep = stringAfter.indexOf(stringSeparator);										// Get index of separator
	int id = stringAfter.substring(0, sep).toInt();										// Get Id
	String name = stringAfter.substring(sep + 1);										// Get Value

	Serial.println(stringAfter);

	// Check if exists
	if (pinSwitch[id] == NULL) {
		Serial.println(stringErrorIdNull);
		return;
	}

	// Get current name
	String before = nameSwitch[id];
	if (before == name) {
		Serial.println(stringErrorNameSame);
		return;
	}

	// Do rename
	nameSwitch[id] = name;
	String after = nameSwitch[id];
	if (before == after) {
		Serial.println(stringErrorValueNotChanged);
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

																						// Check if sensor exists
	if (pinSwitch[id] == NULL) {
		Serial.println(stringErrorIdNull);
		return;
	}

	// Get current values
	int before = getSwitchState(id);
	if (before == val) {
		Serial.println(stringErrorValueSame);
		return;
	}

	// Do Switch
	digitalWrite(pinSwitch[id], (val == 1) ? HIGH : LOW);
	int after = getSwitchState(id);
	if (before == after) {
		Serial.println(stringErrorValueNotChanged);
		return;
	}

	// Send OK
	Serial.println(stringOk);
}

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
	}
}

#pragma endregion

#pragma endregion
