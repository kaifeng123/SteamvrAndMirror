using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System;

public class PlayerMovement : MonoBehaviourPun
{
    public Text nameText;
    public PhotonView photonview;
    public GameObject bullet;
    public Transform bulletPos;


    private void Awake()
    {
        if (photonView.IsMine)
            nameText.text ="You : " + PhotonNetwork.NickName;
        else
            nameText.text = photonView.Owner.NickName;
        //Debug.Log(PhotonNetwork.NickName + "|"+ photonView.Owner.NickName);
    }

    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;
        Move();

        if(Input.GetKeyDown(KeyCode.Q))
        {
            Shot();
        }
    }

    private void Shot()
    {
       GameObject goBullet = PhotonNetwork.Instantiate(bullet.name, bulletPos.transform.position, Quaternion.identity, 0);
        Rigidbody r = goBullet.GetComponent<Rigidbody>();
        r.velocity = Vector3.forward * 10;
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        this.transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 5);
    }
}
