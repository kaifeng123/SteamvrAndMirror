using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViveManager : MonoBehaviourPun
{
    public GameObject head;

    public GameObject L_Hand;

    public GameObject R_Hand;

    public static ViveManager Instance;

    public Text nameText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (photonView.IsMine)
            nameText.text = "You : " + PhotonNetwork.NickName;
        else
            nameText.text = photonView.Owner.NickName;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }


}
