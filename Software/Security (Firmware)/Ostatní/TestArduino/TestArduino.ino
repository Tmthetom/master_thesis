#include <SoftwareSerial.h>

SoftwareSerial gsm(10, 11); // RX, TX
String arduinoReceived = "";
String arduinoSending = "[-->] ";
String received;

void setup() {
  Serial.begin(9600);
  gsm.begin(9600);
  Serial.println("Arduino Connected!");
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

