using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{

    public GameObject readyButton;

    //public string prefabName;

    public GameObject headPrefab;

    public GameObject L_handPrefab;

    public GameObject R_handPrefab;

    //public Transform parent;

    public void ReadyToPlay()
    {
        readyButton.SetActive(false);

        //GameObject go = PhotonNetwork.Instantiate(prefabName, new Vector3(Random.Range(1, 10), 1, Random.Range(1, 10)), Quaternion.identity, 0);
        //go.transform.parent = parent;

        PhotonNetwork.Instantiate(headPrefab.name, ViveManager.Instance.head.transform.position, ViveManager.Instance.head.transform.rotation, 0);

        PhotonNetwork.Instantiate(L_handPrefab.name, ViveManager.Instance.L_Hand.transform.position, ViveManager.Instance.L_Hand.transform.rotation, 0);

        PhotonNetwork.Instantiate(R_handPrefab.name, ViveManager.Instance.R_Hand.transform.position, ViveManager.Instance.R_Hand.transform.rotation, 0);
    }
}
