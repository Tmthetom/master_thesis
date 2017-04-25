int i = 1;

void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.println("Loop = " + String(i));
  i++;
  
  delay(500);
}
