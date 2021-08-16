using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Commons
{
    public static string name = "";

    public static string pwd = "";

    private static string switcher = "OpenOrClose";

    public static int Key = 0;

    public static bool IsRember = false;

    public static bool IsTimerClock = false;

    public static int cnt = 0;

    public bool Switcher
    {
        get
        {
            var v = PlayerPrefs.GetInt(switcher);
            return v == 0;
        }

        set
        {
            PlayerPrefs.SetInt(switcher, value ? 1 : 0);
        }
    }
}
