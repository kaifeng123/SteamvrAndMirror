using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System;

public class RoomNameBtn : MonoBehaviour
{
    public Text RoomName;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => JoinRoomByName(RoomName.text));
    }

    private void JoinRoomByName(string roomName)
    {
        //Debug.Log("-----roomName:" + roomName);
        //string[] str = roomName.Split(' ');
        //roomName = str[0] + " " + str[1];
        //Debug.Log("-----roomName:" + roomName);
        PhotonNetwork.JoinRoom(roomName);
    }

   
}
