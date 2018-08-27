using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateLine : MonoBehaviour
{
    public Text dateText;
    private System.DateTime dateTime;

    private void Start()
    {
        dateText.text = dateTime.Year + "년 " + dateTime.Month + "월 " + (dateTime.Day - 1) + "일 ";

        var dayOfWeek = "";
        if(dateTime.DayOfWeek == System.DayOfWeek.Monday)
            dayOfWeek = "월요일";
        else if(dateTime.DayOfWeek == System.DayOfWeek.Tuesday)
            dayOfWeek = "화요일";
        else if(dateTime.DayOfWeek == System.DayOfWeek.Wednesday)
            dayOfWeek = "수요일";
        else if(dateTime.DayOfWeek == System.DayOfWeek.Thursday)
            dayOfWeek = "목요일";
        else if(dateTime.DayOfWeek == System.DayOfWeek.Friday)
            dayOfWeek = "금요일";
        else if(dateTime.DayOfWeek == System.DayOfWeek.Saturday)
            dayOfWeek = "토요일";
        else if(dateTime.DayOfWeek == System.DayOfWeek.Sunday)
            dayOfWeek = "일요일";
        dateText.text += dayOfWeek;
    }
}