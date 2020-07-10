using System.Collections;
using UnityEngine;
using UnityEngine.Android;



public class Gps : MonoBehaviour
{

    bool gpsInit = false;

    LocationInfo currentGPSPosition;

   



    double detailed_num = 1.0;//기존 좌표는 float형으로 소수점 자리가 비교적 자세히 출력되는 double을 곱하여 자세한 값을 구합니다.
    public double latitude;
    public double longitude;
    public string s;

    void Start()

    {
     

        Input.location.Start(5f);



        int wait = 3000; // 기본 값

        if (Input.location.isEnabledByUser)//사용자에 의하여 좌표값을 실행 할 수 있을 경우

        {

            while (Input.location.status == LocationServiceStatus.Initializing && wait > 0)//초기화 진행중이면

            {

                wait--; // 기다리는 시간을 뺀다

            }

            //GPS를 잡는 대기시간

            if (Input.location.status != LocationServiceStatus.Failed)//GPS가 실행중이라면

            {

                gpsInit = true;

                InvokeRepeating("RetrieveGPSData", 0.0001f, 1.0f);//0.0001초에 실행하고 1초마다 해당 함수를 실행합니다.

            }

        }

        else//GPS가 없는 경우 (GPS가 없는 기기거나 안드로이드 GPS를 설정 하지 않았을 경우

        {

            //  text_latitude.text = "GPS not available";

            //  text_longitude.text = "GPS not available";
            s = "Gps not available";
        }

    }

    void RetrieveGPSData()

    {
        currentGPSPosition = Input.location.lastData;//gps를 데이터를 받습니다.
        latitude = (currentGPSPosition.latitude * detailed_num);
       
        longitude = (currentGPSPosition.longitude * detailed_num);
        s = "위도:" + latitude + "경도" + longitude;

    }

}