using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviourPunCallbacks
{
    public GameObject headPrefab;

    public GameObject L_handPrefab;

    public GameObject R_handPrefab;

    void Start()
    {
        //GameObject player = PhotonNetwork.Instantiate(prefabName, new Vector3(Random.Range(1, 10), 1, Random.Range(1, 10)), Quaternion.identity, 0);
        //player.transform.parent = parent;
        PhotonNetwork.Instantiate(headPrefab.name, ViveManager.Instance.head.transform.position, ViveManager.Instance.head.transform.rotation, 0);
        //GameObject L_hand = PhotonNetwork.Instantiate(headPrefab.name, ViveManager.Instance.L_Hand.transform.position, ViveManager.Instance.L_Hand.transform.rotation, 0);
        //GameObject R_hand = PhotonNetwork.Instantiate(headPrefab.name, ViveManager.Instance.R_Hand.transform.position, ViveManager.Instance.R_Hand.transform.rotation, 0);
        //L_hand.transform.parent = head.transform;
        //R_hand.transform.parent = head.transform;
        Debug.Log("--- Instantiate complte --");
    }
}
