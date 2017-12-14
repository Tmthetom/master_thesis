#include <SoftwareSerial.h>

SoftwareSerial gsm(10, 11); // RX, TX
String arduinoReceived = "";  // Console text before received message
String arduinoSending = "[-->] ";  // Console text before sended message
String received;  // Received message
int command = 0;  // Number of initialisation command in row
int numberOfDots;  // For watingForIP, number of dots in IP
bool watingForResponse = false;
bool watingForIP = false;
bool initCompleted = false;

void setup() {
  Serial.begin(9600);
  gsm.begin(9600);
  Serial.println("Arduino Connected!");
  sendCommand("AT");
}

void loop() {

  // Wating for response
  if (watingForResponse){

    // Response (GSM -> PC)
    if (gsm.available()) {
      
      // Send received message to console
      received = gsm.readString();
      received.trim();
      Serial.println(arduinoReceived + received);

      // Check if command runs OK
      if (received.endsWith("OK")){
        watingForResponse = false;
        Serial.println();
      }

      // When wating for client IP, check if runs OK
      else if (watingForIP){
        for(int i = 0; i < received.length(); i++){
          if (received.charAt(i) == '.') {
            numberOfDots++;
          }
        }
        if (numberOfDots >= 3){
          watingForIP = false;
          watingForResponse = false;
          Serial.println();
        }
        numberOfDots = 0;
      }
    }
  }

  // Initialisation
  else{
    if(initCompleted == false) initialisation();
    else readGetters();
  }
  
  // Direct commands (PC -> GSM)
  if (Serial.available()) {
    received = Serial.readString();
    Serial.print(arduinoSending + received);
    gsm.print(received);
  }
}

void readGetters(){
  if (gsm.available()) {
    // Send received message to console
    received = gsm.readString();
    received.trim();
    Serial.println(arduinoReceived + received);

    if (received.endsWith("GetAllSensors")){
      sendMessage("(Id = 2,Pin = 6,Name = Testing sensor 1,State = 0,Type = 0),(Id = 3,Pin = 8,Name = Testing sensor 2,State = 1,Type = 0),(Id = 4,Pin = 9,Name = Testing sensor 3,State = 0,Type = 0)");
    }
    else if (received.endsWith("GetAllSwitches")){
      sendMessage("(Id = 1,Pin = 2,Name = Testing switch 1,State = 0),(Id = 5,Pin = 3,Name = Testing switch 2,State = 1),(Id = 7,Pin = 5,Name = Testing switch 3,State = 0)");
    }
  }
}

void initialisation(){
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

void sendCommand(String command){
  Serial.println(arduinoSending + command);
  gsm.println(command);
  watingForResponse = true;
}

void sendMessage(String message){
  Serial.println(arduinoSending + "AT+CIPSEND");
  gsm.println("AT+CIPSEND");
  delay(1000);
  Serial.println(arduinoSending + message);
  gsm.println(message);
  delay(1000);
  gsm.println("");
  delay(1000);
}

