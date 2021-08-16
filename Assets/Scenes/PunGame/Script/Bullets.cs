using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullets : MonoBehaviourPun
{
    public float MoveSpeed = 8f;

    public float DestoryTiem = 2f;

    public float bulletDamage = 0.3f;

    IEnumerator DestoryBullet()
    {
        yield return new WaitForSeconds(DestoryTiem);
        this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void Destroy()
    {
        Destroy(this.gameObject,DestoryTiem);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!photonView.IsMine)
            return;

        PhotonView target = other.gameObject.GetComponent<PhotonView>();
        if (target != null && (!target.IsMine || target.IsSceneView))
        {
            if(target.tag == "Player")
            {
                target.RPC("HealthUpdate", RpcTarget.AllBuffered, bulletDamage);
            }
            this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered);
        }
    }

}
