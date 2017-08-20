String received;
String gsm = "GSM Received: ";

void setup() {
  Serial.begin(9600);
  while (!Serial) {
    ;
  }

  Serial.println("GSM Connected!");
}

void loop() {
  if (Serial.available()) {
    Serial.print(Serial.readString());
  }
}
