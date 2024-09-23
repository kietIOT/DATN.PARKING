#include <Adafruit_Fingerprint.h>
 SoftwareSerial mySerial(2, 3);
Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  finger.begin(57600);

  if (!finger.verifyPassword()) {
      SendErrorMessage("Did not find fingerprint sensor !");
  }
 
}

void loop() {
  // put your main code here, to run repeatedly:

}
void SendErrorMessage(char data)
{
 Serial.print("Error:");
 Serial.println(data);  
}
