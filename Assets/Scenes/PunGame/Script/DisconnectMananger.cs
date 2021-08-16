
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisconnectMananger : MonoBehaviourPunCallbacks
{
    public GameObject DisUI;
    public GameObject MenuBtn;
    public GameObject ReconnectBtn;
    public Text StatusText;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            DisUI.SetActive(true);
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                ReconnectBtn.SetActive(true);
                StatusText.text = "Lost connection to photon, please try to reconnect";
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                MenuBtn.SetActive(true);
                StatusText.text = "Lost connection to photon, please try to reconnect in the main menu";
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        if(DisUI.activeSelf)
        {
            MenuBtn.SetActive(false);
            ReconnectBtn.SetActive(false);
            DisUI.SetActive(false);
        }
    }

    public void OnClick_TryConnect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnClick_Menu()
    {
        PhotonNetwork.LoadLevel(0);
    }

}
