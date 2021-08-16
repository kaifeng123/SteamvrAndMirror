

using Common;
using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    public GameObject regPanel;

    public InputField username;
    public InputField password;
    public Text tips;

    private LoginRequest loginRequest;

    private void Start()
    {
        loginRequest = GetComponent<LoginRequest>();
    }

    public void OnLoginButton()
    {
        tips.text = "";
        loginRequest.Username = username.text; 
        loginRequest.Password = password.text;
        

        string playerName = username.text;
        if (!playerName.Equals("")&& !loginRequest.Password.Equals(""))
        {
            PhotonNetwork.LocalPlayer.NickName = playerName;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.Log("Player Name is invalid.");
        }
        loginRequest.DefaultRequest();
    }


    public void OnRegButton()
    {
        this.gameObject.SetActive(false);
        regPanel.SetActive(true);
    }

    public void OnLoginResponse(ReturnCode returnCode)
    {
        if (returnCode == ReturnCode.Success)
        {
            //跳转下个场景
            //SceneManager.LoadScene("Game");
            //SceneManager.LoadScene("GameVR");
            //lobbyMainPanel.OnConnectedToMaster();
            this.gameObject.SetActive(false);
        }
        else
            tips.text = "用户名或者密码错误";
    }
}
