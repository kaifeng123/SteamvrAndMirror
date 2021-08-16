using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Threading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using LitJson;



public class Login : MonoBehaviour
{

    WWW www;
    WWWForm form;
    string url;

    private static HttpWebResponse myResponse;

    //public GameObject vrtk;
    //public GameObject uictrl;
    //勾选框
    public Toggle remPassword;
    private Toggle fogPasssword;

    //用户信息
    public InputField inputName;
    public InputField inputPassword;

    private string account;
    private string pass;

    //GUI提示
    public GameObject uitip;
    public Text ui_massage;
    private string stringmassage;

    public string UID_softwarecode = "6001";

    string devicename;

    public string softwarename = "冶金项目V1.0（MR项目）";

    void Start()
    {
        Debug.Log(666);
        //#if UNITY_EDITOR || UNITY_STANDLONE
        //        devicename = SystemInfo.deviceName + "/" + SystemInfo.operatingSystem;
        //#elif UNITY_ANDROID
        //        devicename = SystemInfo.deviceModel+ "/" + SystemInfo.operatingSystem;
        //#endif

        devicename = SystemInfo.deviceName + "/" + SystemInfo.operatingSystem;

        if (Commons.IsRember)
        {
            inputName.text = PlayerPrefs.GetString("Name", Commons.name);

            inputPassword.text = PlayerPrefs.GetString("Pwd", Commons.pwd);

            remPassword.isOn = true;
        }

        OnClick();   //自动登录
    }

    void Update()
    {
        ui_massage.text = stringmassage;

        //如果选中记住密码
        if (remPassword.isOn)
        {
            //填充数据
            //inputName.text = PlayerPrefs.GetString("Name", Commons.name);

            //inputPassword.text = PlayerPrefs.GetString("Pwd", Commons.pwd);
        }

    }


    public static bool IsConnectInternet()
    {
        try
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            PingReply pr = ping.Send("etomooc.com");
            if (pr.Status == IPStatus.Success)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            //Debug.Log(ex.Message);

            return false;
        }

    }
    public void OnClick()
    {

        //用户名密码输入判断
        if (string.IsNullOrEmpty("inputName"))
        {

            print(stringmassage = "提示信息：请输入昵称");
            return;
        }

        if (string.IsNullOrEmpty("inputPassword"))
        {

            print(stringmassage = "提示信息：请输入密码");
            return;
        }

        //检查是否链接服务器
        IsConnectInternet();
        //设备id获取
        string udid = SystemInfo.deviceUniqueIdentifier;
        form = new WWWForm();

        //获取账号
         //account = inputName.text.Trim();
        Commons.name = inputName.text.Trim();
        form.AddField("account", Commons.name);


        //获取密码
        Commons.pwd = inputPassword.text.Trim();
        form.AddField("pass", Md5.Md5Sum(Commons.pwd));

        Debug.Log(Commons.name + "\\" + Commons.pwd);

        //获取设备唯一码
        form.AddField("udid", udid);


        //获取设备名称
        //string devicename = SystemInfo.deviceName;
        form.AddField("devicename", devicename);

        //获取软件名称
        //int device_type =2;
        //form.AddField("device_type", device_type);
        form.AddField("softwarecode", UID_softwarecode);
        form.AddField("softwarename", softwarename);
        //访问接口

        //Debug.Log("info" + url + "," + account + "," + pass + "," + udid + "," + devicename + "," + softwarename+","+UID_softwarecode);
        //Debug.Log(form.data);
        uitip.SetActive(true);
        url = "https://www.etomooc.com/ar.php/Home/MRSoftwareProjectApi/devicelogin";
        www = new WWW(url, form);
        StartCoroutine(WaitForRequestUserLogin(www));

        //Debug.Log("info" + "," + account + "," + Md5.Md5Sum(pass) + "," + udid + "," + devicename + "," + softwarename+","+UID_softwarecode);

    }


    //协程调用登陆
    IEnumerator WaitForRequestUserLogin(WWW www)
    {
        yield return www;


        if (www.error != null)
            Debug.Log("fail to request...." + www.error);

        else
        {
            string msgs = www.text;
            //Debug.Log("success" + msgs);

            if (www.error != null)
            {
                //Debug.LogError("error:" + www.error);
                yield break;
            }
            if (string.IsNullOrEmpty(www.text))
            {
                yield break;
            }
            JsonData jsonObj = JsonMapper.ToObject(www.text);
            string str = "";

            UTF8Encoding utf8 = new UTF8Encoding();
            //获取数据判断
            if ((bool)jsonObj["status"])
            {
                Debug.Log("登录成功");
                SceneManager.LoadScene(1);//跳转到场景1
                //用户名密码正确则跳转场景
                //vrtk.SetActive(true);
                //uictrl.SetActive(false);
                print(stringmassage = "提示信息：登录成功");
                //提示

                str = utf8.GetString(utf8.GetBytes(jsonObj["msg"].ToString()));
                Debug.Log(str);
            }
            else
            {
                str = utf8.GetString(utf8.GetBytes(jsonObj["msg"].ToString()));
                //Debug.Log(str);
                print(stringmassage = str);
                //Debug.Log("不允许登陆");
            }

            if (remPassword.isOn)
            {
                //保存数据
                PlayerPrefs.SetString("Name", Commons.name);
                PlayerPrefs.SetString("Pwd", Commons.pwd);
                PlayerPrefs.SetInt("Key", 1);         
                Commons.IsRember = true;
            }
            else
            {
                PlayerPrefs.SetInt("Key", 0);
                Commons.IsRember = false;
            }
        }
    }
}






