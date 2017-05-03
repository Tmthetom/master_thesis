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
String nameSensor[maxSensors];

// Switch
int pinSwitch[maxSwitches];
int stateSwitchOld[maxSwitches];
int stateSwitchCurrent[maxSwitches];
String nameSwitch[maxSwitches];

/* Setup before start */

void setup() {

	// Sensors
	pinSensor[0] = 5;
	nameSensor[0] = "First doors sensor";
	pinSensor[1] = 6;
	nameSensor[1] = "Second door sensor";
	setPinMode(pinSensor, INPUT);

	// Switches
	pinSwitch[0] = 2;
	nameSwitch[0] = "First led switch";
	pinSwitch[1] = 3;
	nameSwitch[1] = "Second led switch";
	pinSwitch[2] = 4;
	nameSwitch[2] = "Third led switch";
	setPinMode(pinSwitch, OUTPUT);
	readSwitchState(pinSwitch, stateSwitchOld);

	// Communication
	in.reserve(maxBytesOfMessage);
	Serial.begin(baudRate);
}

/* Main program loop */

void loop() {

	// Check if switch state changed
	checkSwitchStateChangedAndSendIfTrue();

	// Communication
	readSerialAndRespond();
}

/* Read serial message and respond*/
void readSerialAndRespond() {
	if (inComplete && in.length() != 0) {
		if (in.equalsIgnoreCase(stringGetAllSwitches)) readSerialGetAllSwitches();
		else if (false) readSerialGetAllSensors();
		else sendMessageNotRecognized();

		in = "";
		inComplete = false;
	}
}

/* Check if all switches wanted */
void readSerialGetAllSwitches() {
	if (in.equalsIgnoreCase(stringGetAllSwitches)) {
		out = stringSwitchesCategory + leftBracket;												// Name of category
		for (int i = 0; i < sizeof(pinSwitch) / sizeof(int); i++) {
			if (pinSwitch[i] != NULL) {
				out +=
					leftBracket + stringId + stringEquals + String(i) + stringSeparator + 			// ID
					stringPin + stringEquals + String(pinSwitch[i]) + stringSeparator +				// Pin 
					stringName + stringEquals + String(nameSwitch[i]) + stringSeparator +			// Name
					stringState + stringEquals + String(stateSwitchCurrent[i]) + rightBracket		// State
					;
			}
		}
		out += rightBracket;
		Serial.println(out);
	}
}

/* Check if all sensors wanterd*/
void readSerialGetAllSensors() {
	;
}

/* Check switch state changed */
void checkSwitchStateChangedAndSendIfTrue() {
	readSwitchState(pinSwitch, stateSwitchCurrent);
	for (int i = 0; i < sizeof(pinSwitch) / sizeof(int); i++) {
		if (pinSwitch[i] != NULL) {
			if (stateSwitchCurrent[i] != stateSwitchOld[i]) {
				Serial.println(
					stringSwitchCategory + leftBracket + stringSeparator +						// Name of category
					stringId + stringEquals + stringEquals + String(i) + stringSeparator +		// Id
					stringPin + stringEquals + String(pinSwitch[i]) + stringSeparator +			// Pin 
					stringName + stringEquals + String(nameSwitch[i]) + stringSeparator +		// Name
					stringState + stringEquals + String(stateSwitchCurrent[i]) + rightBracket	// State
				);
			}
		}
	}
}

/* If command not recognized renspond to sender */
void sendMessageNotRecognized() {
	Serial.println("Command '" + in + "' not recognized.");
}

/* Read current switch state [HIGH,LOW] */
void readSwitchState(int pinSwitches[], int stateSwitches[]) {
	for (int i = 0; i < sizeof(pinSwitches) / sizeof(int); i++) {
		if (pinSwitches[i] != NULL) stateSwitches[i] = digitalRead(pinSwitches[i]);
	}
}

/* Set pin mode [INPUT/OUTPUT] */
void setPinMode(int pins[], int mode) {
	if (mode != INPUT || mode != OUTPUT) return;
	for (int i = 0; i < sizeof(pins) / sizeof(int); i++) {
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
void unusedCode() {
if (inComplete && string.length() != 0) {

// Get all leds
if (string.equalsIgnoreCase("GetLeds")) {
String out = "Leds[";                                           // Add start of out
for (int i = 0; i < sizeof(leds) / sizeof(int); i++) {            // Foreach led
out += String(leds[i]) + ',';
}
out = out.substring(0, out.length() - 1);                         // Cut last comma
out += ']';                                                     // Add end of out
Serial.println(out);                                            // Send it
}

// Get all doors
else if (string.equalsIgnoreCase("GetDoors")) {
String out = "Doors[";                                          // Add start of out
for (int i = 0; i < sizeof(doors) / sizeof(int); i++) {           // Foreach door
out += String(doors[i]) + ',';
}
out = out.substring(0, out.length() - 1);                         // Cut last comma
out += ']';                                                     // Add end of out
Serial.println(out);                                            // Send it
}

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

// Get door state
else if (string.startsWith("GetDoor")) {
// Parse data
String middle = string.substring(string.indexOf('[') + 1);        // Get text after '['
String data = middle.substring(0, middle.indexOf(']'));         // Get text before ']'
int pin = data.toInt();

// Use data
int val = digitalRead(pin);
if (val == HIGH) {
digitalWrite(4, HIGH);
}
Serial.println("Button[" + String(pin) + "] = [" + String(val) + "]");
}


// Other
else {
Serial.println("Error: " + in);
}

// Clear the string:
in = "";
inComplete = false;
}
}
*/
