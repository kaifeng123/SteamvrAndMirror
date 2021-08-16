using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class ShowName : MonoBehaviourPun
{
    public Text nameText;

    //public PhotonView p_view;

    private void Awake()
    {
        if (photonView.IsMine)
           nameText.text = PhotonNetwork.NickName;
        else
            nameText.text = photonView.Owner.NickName;
        //Debug.Log(PhotonNetwork.NickName + "|" + photonView.Owner.NickName);
        //p_view.ViewID = Random.Range(1, 1000);
    }

    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;

        // Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        this.transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 5);
    }
}
