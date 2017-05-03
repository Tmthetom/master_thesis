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
String stringSeparator = ",";

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

/* Variables */

// Communication
String in = "";
String out = "";
boolean inComplete = false;

// Sensor
int pinSensor[maxSensors];
int stateSensorOld[maxSensors];
int stateSensorNew[maxSensors];
String nameSensor[maxSensors];

// Switch
int pinSwitch[maxSwitches];
String nameSwitch[maxSwitches];

/* Setup before start */
void setup() {

	// Sensors
	pinSensor[0] = 8;
	nameSensor[0] = "First door sensor";
	pinSensor[1] = 9;
	nameSensor[1] = "Second door sensor";
	setPinMode(pinSensor, sizeof(pinSensor) / sizeof(int), INPUT);
	readSensorsState(pinSensor, sizeof(pinSensor) / sizeof(int), stateSensorOld);

	// Switches
	pinSwitch[0] = 2;
	nameSwitch[0] = "First led switch";
	pinSwitch[1] = 3;
	nameSwitch[1] = "Second led switch";
	pinSwitch[2] = 4;
	nameSwitch[2] = "Third led switch";
	setPinMode(pinSwitch, sizeof(pinSwitch) / sizeof(int), OUTPUT);

	// Communication
	in.reserve(maxBytesOfMessage);
	Serial.begin(baudRate);
}

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
		if (in.equalsIgnoreCase(stringGetAllSwitches)) readSerialGetAllSwitches();
		else if (in.equalsIgnoreCase(stringGetAllSensors)) readSerialGetAllSensors();
		else sendMessageNotRecognized();

		in = "";
		inComplete = false;
	}
}

/* Check if all switches wanted */
void readSerialGetAllSwitches() {
	out = stringSwitchesCategory + leftBracket;													// Name of category
	for (int i = 0; i < sizeof(pinSwitch) / sizeof(int); i++) {
		if (pinSwitch[i] != NULL) {
			out +=
				leftBracket + stringId + stringEquals + String(i) + stringSeparator + 			// ID
				stringPin + stringEquals + String(pinSwitch[i]) + stringSeparator +				// Pin 
				stringName + stringEquals + String(nameSwitch[i]) + stringSeparator +			// Name
				stringState + stringEquals + String(readSwitchState(i)) + rightBracket			// State
				;
		}
	}
	out += rightBracket;
	Serial.println(out);
}

/* Check if all sensors wanted */
void readSerialGetAllSensors() {
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

/* Check sensor state changed */
void checkSensorStateChangedAndSendIfTrue() {
	readSensorsState(pinSensor, sizeof(pinSensor) / sizeof(int), stateSensorNew);
	for (int i = 0; i < sizeof(pinSensor) / sizeof(int); i++) {
		if (pinSensor[i] != NULL) {
			if (stateSensorOld[i] != stateSensorNew[i]) {
				stateSensorOld[i] = stateSensorNew[i];
				Serial.println(
					stringSensorCategory + leftBracket +										// Name of category
					stringId + stringEquals + stringEquals + String(i) + stringSeparator +		// Id
					stringPin + stringEquals + String(pinSensor[i]) + stringSeparator +			// Pin 
					stringName + stringEquals + String(nameSensor[i]) + stringSeparator +		// Name
					stringState + stringEquals + String(stateSensorOld[i]) + rightBracket		// State
				);
			}
		}
	}
}

/* If command not recognized renspond to sender */
void sendMessageNotRecognized() {
	Serial.println("Command '" + in + "' not recognized.");
}

/* Read all sensors state [HIGH,LOW] */
void readSensorsState(int pinSensors[], int size, int stateSensors[]) {
	for (int i = 0; i < size; i++) {
		if (pinSensors[i] != NULL) stateSensors[i] = digitalRead(pinSensors[i]);
	}
}

/* Read current selected switch state [HIGH,LOW] */
int readSwitchState(int id) {
	if (pinSwitch[id] != NULL) return digitalRead(pinSwitch[id]);
}

/* Set pin mode [INPUT/OUTPUT] */
void setPinMode(int pins[], int size, int mode) {
	if (mode != INPUT && mode != OUTPUT) return;
	for (int i = 0; i < size; i++) {
		if (pins[i] != NULL) pinMode(pins[i], mode);
	}
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

/*
// Set led state
else if (string.startsWith("SetLed")) {
// Parse data
String middle = string.substring(string.indexOf('[') + 1);        // Get text after '['
String data = middle.substring(0, middle.indexOf(']'));         // Get text before ']'
int sep = data.indexOf(separator);                              // Get index of ';'
int pin = data.substring(0, sep).toInt();
int val = data.substring(sep + 1).toInt();

// Use data
digitalWrite(pin, (val == 1) ? HIGH : LOW);
Serial.println("Pin[" + String(pin) + "] = [" + String(val) + "]");
}

*/
