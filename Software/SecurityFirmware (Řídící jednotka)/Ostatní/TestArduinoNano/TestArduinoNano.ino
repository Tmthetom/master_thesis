void setup() {
  Serial.begin(9600);
}

int i = 0;

void loop() {
  i = ++i;
  delay(300);
  Serial.println(i);
}
