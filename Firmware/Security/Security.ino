/* Setting */

const int baudRate = 9600;
const int maxSenzors = 10;
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

// Senzor
String stringSenzorCategory = "Senzor";
String stringSenzorsCategory = "Senzors";
String stringGetAllSenzors = "GetAllSenzors";
String stringSetSenzorName = "SetSenzorName";

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
boolean inComplete = false;

// Senzor
int pinSenzor[maxSenzors];
String nameSenzor[maxSenzors];

// Switch
int pinSwitch[maxSwitches];
int stateSwitch[maxSwitches];				// Old value
int stateSwitchCurrent[maxSwitches];		// Current value
String nameSwitch[maxSwitches];

/* Setup before start */

void setup() {

	// Senzors
	pinSenzor[0] = 5;
	nameSenzor[0] = "First doors senzor";
	pinSenzor[1] = 6;
	nameSenzor[1] = "Second door senzor";
	setPinMode(pinSenzor, INPUT);

	// Switches
	pinSwitch[0] = 2;
	nameSwitch[0] = "First led switch";
	pinSwitch[1] = 3;
	nameSwitch[1] = "Second led switch";
	pinSwitch[1] = 4;
	nameSwitch[1] = "Third led switch";
	setPinMode(pinSwitch, OUTPUT);
	readSwitchState(pinSwitch, stateSwitch);

	// Communication
	in.reserve(maxBytesOfMessage);
	Serial.begin(baudRate);
}

/* Main program loop */

void loop() {
	// Send Switch state changed
	checkSwitchStateChangedAndSendIfTrue();

	// Read Switch
	readSerialGetAllSwitches();
	
	// Read Senzors
	readSerialGetAllSenzors();
}

void readSerialAndRespond() {
	if (inComplete && in.length() != 0) {


		// Clear incoming message:
		in = "";
		inComplete = false;
	}
}

void readSerialGetAllSwitches() {
	if (in.equalsIgnoreCase(stringGetAllSwitches)) {
		Serial.println(
			stringSwitchesCategory + leftBracket

		);

		String out = "Leds[";                                           // Add start of out
		for (int i = 0; i < sizeof(leds) / sizeof(int); i++) {            // Foreach led
			out += String(leds[i]) + ',';
		}
		out = out.substring(0, out.length() - 1);                         // Cut last comma
		out += ']';                                                     // Add end of out
		Serial.println(out);                                            // Send it
	}
}

void readSerialGetAllSenzors() {
	;
}

/* Check switch state changed */
void checkSwitchStateChangedAndSendIfTrue() {
	readSwitchState(pinSwitch, stateSwitchCurrent);
	for (int i = 0; i < sizeof(pinSwitch) / sizeof(int); i++) {
		if (pinSwitch[i] != NULL) {
			if (stateSwitchCurrent[i] != stateSwitch[i]) {
				Serial.println(
					// Name of category
					stringSwitchCategory + leftBracket +

					// Id
					stringSeparator + stringEquals + String(i) + stringSeparator +

					// Pin 
					stringPin + stringEquals + String(pinSwitch[i]) + stringSeparator +

					// State
					stringState + stringEquals + String(stateSwitchCurrent[i]) + rightBracket
				);
			}
		}
	}
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
