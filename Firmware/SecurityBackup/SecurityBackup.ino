int doors[] = {5, 6};                     // Hold all door senzors
int leds[] = {2, 3, 4};                   // Hold all leds
String string = "";                       // String to hold incoming data
String separator = ",";                   // Data separator
boolean stringComplete = false;           // Whether the string is complete
int door1Last;
int door2Last;

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

  door1Last = digitalRead(doors[0]);
  door2Last = digitalRead(doors[1]);
}

// Program loop
void loop() {
  int door1 = digitalRead(doors[0]);
  int door2 = digitalRead(doors[1]);
  
  if (door1 != door1Last){
    door1Last = door1;
    Serial.println("Button[" + String(doors[0]) + "] = [" + String(door1) + "]");
  }
  else if (door2 != door2Last){
    door2Last = door2;
    Serial.println("Button[" + String(doors[1]) + "] = [" + String(door2) + "]");
  }

  
  if (stringComplete && string.length() != 0) {
    
    // Get all leds
    if (string.equalsIgnoreCase("GetLeds")){
      String out = "Leds[";                                           // Add start of out
      for (int i = 0; i < sizeof(leds)/sizeof(int); i++) {            // Foreach led
        out += String(leds[i]) + ',';
      }
      out = out.substring(0, out.length()-1);                         // Cut last comma
      out += ']';                                                     // Add end of out 
      Serial.println(out);                                            // Send it
    }

    // Get all doors
    else if (string.equalsIgnoreCase("GetDoors")){
      String out = "Doors[";                                          // Add start of out
      for (int i = 0; i < sizeof(doors)/sizeof(int); i++) {           // Foreach door
        out += String(doors[i]) + ',';
      }
      out = out.substring(0, out.length()-1);                         // Cut last comma
      out += ']';                                                     // Add end of out 
      Serial.println(out);                                            // Send it
    }

    // Set led state
    else if (string.startsWith("SetLed")){
      // Parse data
      String middle = string.substring(string.indexOf('[')+1);        // Get text after '['
      String data = middle.substring(0, middle.indexOf(']'));         // Get text before ']'
      int sep = data.indexOf(separator);                              // Get index of ';'
      int pin = data.substring(0, sep).toInt();
      int val = data.substring(sep+1).toInt();

      // Use data
      digitalWrite(pin, (val == 1) ? HIGH : LOW); 
      Serial.println("Pin[" + String(pin) + "] = [" + String(val) + "]");
    }

    // Get door state
    else if (string.startsWith("GetDoor")){
      // Parse data
      String middle = string.substring(string.indexOf('[')+1);        // Get text after '['
      String data = middle.substring(0, middle.indexOf(']'));         // Get text before ']'
      int pin = data.toInt();

      // Use data
      int val = digitalRead(pin);
      if (val == HIGH){
        digitalWrite(4, HIGH);
      }
      Serial.println("Button[" + String(pin) + "] = [" + String(val) + "]");
    }

    // Other
    else{
      Serial.println("Error: " + string);
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
