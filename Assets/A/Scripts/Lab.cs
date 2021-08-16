//**********************************************************
//文件名(File Name) :         Skeletal_Lab.cs
//
//作者(Author):               上善若水
//
//创建时间(CreatTime):        2016-11-22 11:41:22
//
//功能(Funtion)：  
//**********************************************************

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Lab : MonoBehaviour
{
    public GameObject ui;
    public Text txt;
    string[] arr;



    void Awake()
    {
        ui.SetActive(false);
    }

    /// <summary>
    /// 碰撞停留
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Skeletal")
        {
            ui.SetActive(true);
            string[] arr = other.name.Split('_');
            txt.text = "当前位置的名字:" + "<color=#0000ff>" + arr[0] + "</color>";
            other.transform.Find(arr[0]).gameObject.SetActive(true);
        }
        else
        {
            ui.SetActive(false);
        }
    }



    /// <summary>
    /// 碰撞离开
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        //if (other.tag == "Skeletal")
        //{
            ui.SetActive(false);
            string[] arr = other.name.Split('_');
            other.transform.Find(arr[0]).gameObject.SetActive(false);
       // }
    }

  
}