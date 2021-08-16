using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : MonoBehaviourPunCallbacks
{
    public int index = 1;

    void Update()
    {
        if(photonView.IsMine)
        {
            switch (index)
            {
                case 1:
                    transform.position = ViveManager.Instance.head.transform.position;
                    transform.rotation = ViveManager.Instance.head.transform.rotation;
                    break;

                case 2:
                    transform.position = ViveManager.Instance.L_Hand.transform.position;
                    transform.rotation = ViveManager.Instance.L_Hand.transform.rotation;
                    break;

                case 3:
                    transform.position = ViveManager.Instance.R_Hand.transform.position;
                    transform.rotation = ViveManager.Instance.R_Hand.transform.rotation;
                    break;
            }
            //0.075，0.055，0.2  
            //0.1226，0.0775，0.1
        }
    }
}
