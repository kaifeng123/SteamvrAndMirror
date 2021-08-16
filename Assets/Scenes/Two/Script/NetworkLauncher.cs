using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public GameObject loginUI;

    public GameObject nameUI;

    public GameObject roomUI;

    public InputField playerName;

    public InputField roomName;

    public InputField maxplayer;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        nameUI.SetActive(true);
        Debug.Log("Connected To Master");
        PhotonNetwork.JoinLobby();
    }

    public void PlayButton()
    {
        nameUI.SetActive(false);
        PhotonNetwork.LocalPlayer.NickName = playerName.text;
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        loginUI.SetActive(true);

        if(PhotonNetwork.InLobby)
        {
            roomUI.SetActive(true);
        }
    }


    public  void JoinorCreateButton()
    {
        if (roomName.text.Length < 2)
            return;

        loginUI.SetActive(false);
        byte maxPlayers;
        byte.TryParse(maxplayer.text, out maxPlayers);
        RoomOptions op = new RoomOptions { MaxPlayers = maxPlayers };

        PhotonNetwork.JoinOrCreateRoom(roomName.text, op,null);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
