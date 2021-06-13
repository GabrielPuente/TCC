#include <ESP8266WiFi.h>
#include <dht.h>

dht DHT;

//defines
#define NAME_WIFI "" //coloque aqui o nome da rede que se deseja conectar
#define PASSWORD_WIFI "" //coloque aqui a senha da rede que se deseja conectar
#define INTERVAL_SEND_THINGSPEAK 30000 //intervalo entre envios de dados ao ThingSpeak (em ms)
#define DHT11_PIN D1
#define pinSensorA A0

//constants
char APIThingSpeak[] = "api.thingspeak.com";
String ReadKeyThingSpeak = ""; //Coloque aqui sua chave de leitura da API do thingspeak
long lastConnectionTime; 
int counter = 0;
WiFiClient client;
 
//functions
void SendValuesThingspeak(String values);
void ConectWiFi(void);
float ReadHumidity(void);

//Função: envia informações ao ThingSpeak
//Parâmetros: String com a  informação a ser enviada
void SendValuesThingspeak(String values)
{
    if (client.connect(APIThingSpeak, 80))
    {         
        //faz a requisição HTTP ao ThingSpeak
        client.print("POST /update HTTP/1.1\n");
        client.print("Host: api.thingspeak.com\n");
        client.print("Connection: close\n");
        client.print("X-THINGSPEAKAPIKEY: "+ReadKeyThingSpeak+"\n");
        client.print("Content-Type: application/x-www-form-urlencoded\n");
        client.print("Content-Length: ");
        client.print(values.length());
        client.print("\n\n");
        client.print(values);
   
        lastConnectionTime = millis();
        Serial.println(values);
        Serial.println("- Informações enviadas ao ThingSpeak!");
     }  
}

//Função: faz a conexão WiFI
void ConectWiFi(void)
{
    client.stop();
    delay(1000);
    WiFi.begin(NAME_WIFI, PASSWORD_WIFI);
 
    while (WiFi.status() != WL_CONNECTED) 
    {
        delay(500);
        Serial.print(".");
    }
    Serial.println("WiFi conected!");  
    Serial.println("IP: ");
    Serial.println(WiFi.localIP());
    delay(1000);
}

//Função: faz a leitura do nível de umidade
//Parâmetros: nenhum
//Retorno: umidade percentual (0-100)
float ReadHumidity(void)
{
    int humidityValue;
    float humidityPercentage;
    
    humidityValue = analogRead(0); 
    humidityPercentage = 100 * ((1024-(float)humidityValue) / 1024);
    
    Serial.print("Humidity percentage: ");
    Serial.print(humidityPercentage);
    Serial.println("%");
    return humidityPercentage;
}

void setup()
{  
    Serial.begin(9600);
    lastConnectionTime = 0; 
    ConectWiFi();
}
 
void loop()
{
  float humidityRead;
  float dhtHumidity;
  float dhtTemperature;
  char FieldHumidity[11];
  char FielddhtHumidity[11];
  char FielddhtTemperature[11];

  //Força desconexão ao ThingSpeak (se ainda estiver desconectado)
  if (client.connected())
  {
      client.stop();
  }
  
  humidityRead = ReadHumidity();

  int chk = DHT.read11(DHT11_PIN);
  if(chk == DHTLIB_OK)
  {
    Serial.print("Humidade: ");
    Serial.print(DHT.humidity);
    Serial.print(",\t");
    Serial.print("Temperatura: ");
    Serial.println(DHT.temperature);
    dhtHumidity = (float)DHT.humidity;
    dhtTemperature = (float)DHT.temperature;
  }

  //verifica se está conectado no WiFi e se é o momento de enviar dados ao ThingSpeak
  if(!client.connected() && (millis() - lastConnectionTime > INTERVAL_SEND_THINGSPEAK))
  {
    if(counter == 0)
    {
      sprintf(FieldHumidity,"field1=%f",humidityRead);
      SendValuesThingspeak(FieldHumidity);
      counter = 1;
    }

    else if(counter == 1)
    {
      sprintf(FielddhtTemperature,"field2=%f",dhtTemperature);
      SendValuesThingspeak(FielddhtTemperature);  
      counter = 2;
    }

    else if(counter == 2)
    {
      sprintf(FielddhtHumidity,"field3=%f",dhtHumidity);
      SendValuesThingspeak(FielddhtHumidity);
      counter = 0;
    }
  }

  Serial.print("\n\n\n");
  delay(3000);
}
