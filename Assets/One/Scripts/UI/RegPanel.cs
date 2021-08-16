using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegPanel : MonoBehaviour
{
    public GameObject loginPanel;

    public InputField username;
    public InputField password;
    public Text tips;

    private RegisterRequest registerRequest;

    private void Start()
    {
        registerRequest = GetComponent<RegisterRequest>();
    }

    public void OnRegButton()
    {
        tips.text = "";
        registerRequest.Username = username.text;
        registerRequest.Password = password.text;
        registerRequest.DefaultRequest();
    }

    public void OnBackButton()
    {
        loginPanel.SetActive(true);
        this.gameObject.SetActive(false); 
    }

    public void OnRegisterResponse(ReturnCode returnCode)
    {
        if(returnCode == ReturnCode.Success)
        {
            tips.text = "注册成功，请返回登录";
        }
        else if(returnCode ==ReturnCode.Failed)
        {
            tips.text = "用户名重复，请更改用户名重新注册";
        }
    }
}
