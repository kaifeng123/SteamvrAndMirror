using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject UserNameScreen, ConnectScreen;

    [SerializeField]
    private GameObject CreateNameBtn;

    [SerializeField]
    private InputField UserNameInput, CreateRoomInput, JoinRoomInput;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master !!!!");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Connected To Lobby !!!!");
        UserNameScreen.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

    #region UIMethods
    public void OnClick_CreateNameBtn()
    {
        PhotonNetwork.NickName = UserNameInput.text;
        UserNameScreen.SetActive(false);
        ConnectScreen.SetActive(true);
    }

    public void OnNameField_Changed()
    {
        if (UserNameInput.text.Length >= 2)
        {
            CreateNameBtn.SetActive(true);
        }
        else
        {
            CreateNameBtn.SetActive(true);
        }
    }

    public void OnClick_JoinRoom()
    {
        RoomOptions op = new RoomOptions();
        op.MaxPlayers = 20;
        PhotonNetwork.JoinOrCreateRoom(JoinRoomInput.text, op, TypedLobby.Default);
    }

    
    public void OnClick_CreateRoom()
    {
        if(string.IsNullOrEmpty(CreateRoomInput.text))
        {
            CreateRoomInput.text = "Room " + Random.Range(1, 999).ToString();
            PhotonNetwork.CreateRoom(CreateRoomInput.text, new RoomOptions { MaxPlayers = 20 }, null);
        }
        else
        {
            PhotonNetwork.CreateRoom(CreateRoomInput.text, new RoomOptions { MaxPlayers = 20 }, null);
        }       
    }

    #endregion


}
