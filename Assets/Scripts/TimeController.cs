
using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private float timeMultiplier;

    [SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

     [SerializeField]
    private Light sunLight;

     [SerializeField]
    private float sunriseHour;

     [SerializeField]
    private float sunsetHour;

     [SerializeField]
    private Color dayAmbientLight;

     [SerializeField]
    private Color nightAmbientLight;

     [SerializeField]
    private AnimationCurve lightChangeCurve;

     [SerializeField]
    private float maxSunLightIntensity;

     [SerializeField]
    private Light moonLight;

     [SerializeField]
    private float maxMoonLightIntensity;
    public DateTime currentTime;

    private TimeSpan sunriseTime;

    private TimeSpan sunsetTime;
    public int DayCount; 
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public TextMeshProUGUI day;
    public TimeController a;


    // Start is called before the first frame update
    void Start()
    {
        DayCount = 1;
        PlayerPrefs.SetInt("Score", DayCount - 1);
        currentTime=DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunriseTime=TimeSpan.FromHours(sunriseHour);
        sunsetTime=TimeSpan.FromHours(sunsetHour);
        day.text=GetComponent<TMPro.TextMeshProUGUI>().text;

    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime.Hour != 12){
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();}
        if(currentTime.Hour == 12){
            Pause();
        }
    }

    private void UpdateTimeOfDay()
    {
        currentTime=currentTime.AddSeconds(Time.deltaTime*timeMultiplier);
        if(timeText!=null)
        {
            timeText.text=currentTime.ToString("HH:mm");
        }
    }

    private void RotateSun()
    {
        float sunLightRotation;

        if(currentTime.TimeOfDay>sunriseTime && currentTime.TimeOfDay<sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime,sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime,currentTime.TimeOfDay);

            double percentage= timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation= Mathf.Lerp(0,180,(float)percentage);
        }

        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime,currentTime.TimeOfDay);
            double percentage= timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation= Mathf.Lerp(180,360,(float)percentage);
        }

        sunLight.transform.rotation=Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private void UpdateLightSettings()
    {
        float dotProduct= Vector3.Dot(sunLight.transform.forward,Vector3.down);
        sunLight.intensity=Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct));
        moonLight.intensity=Mathf.Lerp(0, maxMoonLightIntensity, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight= Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if(difference.TotalSeconds < 0)
        {
            difference+= TimeSpan.FromHours(24);
        }
        return difference;
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused = true;

    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentTime = new System.DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 13, currentTime.Minute, currentTime.Second);
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused = false;
        DayCount += 1;
        PlayerPrefs.SetInt("Score", DayCount - 1);
        day.text = DayCount.ToString();
    }
}
