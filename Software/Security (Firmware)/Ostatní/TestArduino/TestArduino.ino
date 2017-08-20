#include <SoftwareSerial.h>

SoftwareSerial gsm(10, 11); // RX, TX
String arduinoReceived = "Arduino Received: ";
String arduinoSending = "Arduino Sending: ";
String received;

void setup() {
  Serial.begin(9600);
  while (!Serial) {
    ;
  }

  Serial.println("Arduino Connected!");
  gsm.begin(9600);
}

void loop() {

  // GSM -> PC
  if (gsm.available()) {
    Serial.print(arduinoReceived + gsm.readString());
  }

  // PC -> GSM
  if (Serial.available()) {
    received = Serial.readString();
    Serial.print(arduinoSending + received);
    gsm.print(received);
  }
}

