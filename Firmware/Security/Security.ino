// Global variables
int doorSenzors[] = {5, 6};               // Hold all door senzors
int leds[] = {2, 3, 4};                   // Hold all leds
String string = "";                       // String to hold incoming data
boolean stringComplete = false;           // Whether the string is complete

// Initialization
void setup() {
  // Init serial:
  Serial.begin(9600);
  string.reserve(200);                    // Reserve 200 bytes for the inputString:

  // Init senzors
  for (int thisPin = 0; thisPin < sizeof(doorSenzors); thisPin++) {
    pinMode(doorSenzors[thisPin], INPUT);
  }
  for (int thisPin = 0; thisPin < sizeof(leds); thisPin++) {
    pinMode(leds[thisPin], OUTPUT);
  }
}

// Program loop
void loop() {
  if (stringComplete) {
    if (string.startsWith("door")){
      // Parse data
      String middle = string.substring(string.indexOf('[')+1);          // Get text after '['
      String data = middle.substring(0, middle.indexOf(']'));         // Get text before ']'
      int pin = data.toInt();

      // Use data
      int val = digitalRead(pin);
      if (val == HIGH){
        digitalWrite(4, HIGH);
      }
      Serial.println("Button[" + String(pin) + "] = [" + String(val) + "]");
    }
    else if (string.startsWith("led")){
      // Parse data
      String middle = string.substring(string.indexOf('[')+1);          // Get text after '['
      String data = middle.substring(0, middle.indexOf(']'));         // Get text before ']'
      int separator = data.indexOf(';');                              // Get index of ';'
      int pin = data.substring(0, separator).toInt();
      int val = data.substring(separator+1).toInt();

      // Use data
      digitalWrite(pin, (val == 1) ? HIGH : LOW); 
      Serial.println("Pin[" + String(pin) + "] = [" + String(val) + "]");
    }
    else{
      Serial.println("No parse: " + string);
    }
    
    // Clear the string:
    string = "";
    stringComplete = false;
  }
}

// Serial interrput
void serialEvent() {
  while (Serial.available()) {
    // Get the new byte:
    char inChar = (char)Serial.read();
    // Add it to the inputString:
    string += inChar;
    // If the incoming character is a newline, set a flag
    // So the main loop can do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}
