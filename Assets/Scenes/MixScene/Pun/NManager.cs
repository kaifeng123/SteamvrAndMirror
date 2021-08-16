using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NManager : MonoBehaviour
{
    public GameObject headPrefab;

    public GameObject L_handPrefab;

    public GameObject R_handPrefab;

    // Use this for initialization
    public void Start()
    {
        //PhotonNetwork.ConnectUsingSettings();

        PhotonNetwork.Instantiate(headPrefab.name, ViveManager.Instance.head.transform.position, ViveManager.Instance.head.transform.rotation, 0);

        PhotonNetwork.Instantiate(L_handPrefab.name, ViveManager.Instance.L_Hand.transform.position, ViveManager.Instance.L_Hand.transform.rotation, 0);

        PhotonNetwork.Instantiate(R_handPrefab.name, ViveManager.Instance.R_Hand.transform.position, ViveManager.Instance.R_Hand.transform.rotation, 0);
        Debug.Log(666);
    }

    public virtual void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    
    public virtual void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions() { MaxPlayers = 4 }, null);
    }

    public void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(headPrefab.name, ViveManager.Instance.head.transform.position, ViveManager.Instance.head.transform.rotation, 0);

        PhotonNetwork.Instantiate(L_handPrefab.name, ViveManager.Instance.L_Hand.transform.position, ViveManager.Instance.L_Hand.transform.rotation, 0);

        PhotonNetwork.Instantiate(R_handPrefab.name, ViveManager.Instance.R_Hand.transform.position, ViveManager.Instance.R_Hand.transform.rotation, 0);
    }
}
