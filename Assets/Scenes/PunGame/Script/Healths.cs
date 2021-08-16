using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Healths : MonoBehaviourPun
{
    public Image fillImage;
    public float health = 1f;

    public void CheckHealth()
    {
        if(photonView.IsMine &&health <= 0)
        {
            this.GetComponent<PhotonView>().RPC("Death", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    public void Death()
    {

    }


    [PunRPC]
    public void HealthUpdate(float damage)
    {
        fillImage.fillAmount -= damage;
        health = fillImage.fillAmount;
        CheckHealth();
    }
}
