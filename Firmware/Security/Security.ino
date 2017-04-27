// Global variables
int doors[] = {5, 6};                     // Hold all door senzors
int leds[] = {2, 3, 4};                   // Hold all leds
String string = "";                       // String to hold incoming data
String separator = ",";                   // Data separator
boolean stringComplete = false;           // Whether the string is complete

// Initialization
void setup() {
  // Init serial:
  Serial.begin(9600);
  string.reserve(200);                    // Reserve 200 bytes for the inputString:

  // Init senzors
  for (int i = 0; i < sizeof(doors)/sizeof(int); i++) {
    pinMode(doors[i], INPUT);
  }
  for (int i = 0; i < sizeof(leds)/sizeof(int); i++) {
    pinMode(leds[i], OUTPUT);
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
      int sep = data.indexOf(separator);                              // Get index of ';'
      int pin = data.substring(0, sep).toInt();
      int val = data.substring(sep+1).toInt();

      // Use data
      digitalWrite(pin, (val == 1) ? HIGH : LOW); 
      Serial.println("Pin[" + String(pin) + "] = [" + String(val) + "]");
    }
    else if (string.equalsIgnoreCase("GetLeds")){
      String out = "Leds[";                                           // Add start of out
      for (int i = 0; i < sizeof(leds)/sizeof(int); i++) {            // Foreach led
        out += String(leds[i]) + ',';
      }
      out = out.substring(0, out.length()-1);                          // Cut last comma
      out += ']';                                                     // Add end of out 
      Serial.println(out);                                            // Send it
    }
    else if (string.equalsIgnoreCase("GetDoors")){
      String out = "Doors[";                                          // Add start of out
      for (int i = 0; i < sizeof(doors)/sizeof(int); i++) {           // Foreach door
        out += String(doors[i]) + ',';
      }
      out = out.substring(0, out.length()-1);                           // Cut last comma
      out += ']';                                                     // Add end of out 
      Serial.println(out);                                            // Send it
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
      string.trim();
      stringComplete = true;
    }
  }
}
