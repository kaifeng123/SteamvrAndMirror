using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Comon
{
   

    private static int _count;
    public static int Count
    {
        get
        {
            return _count;
        }

        set
        {
            _count = value;
        }
    }

    private static bool isCount = false;
    public static bool IsCount
    {
        get
        {
            return isCount;
        }

        set
        {
            isCount = value;
        }
    }

    public static int Num
    {
        get
        {
            return num;
        }

        set
        {
            num = value;
        }
    }

    private static int num;

    public static void AddNum(int count)
    {
        Count = Count + count;
    }

    public static void RemoveNum(int count)
    {
        Count = Count - count;
    }
}