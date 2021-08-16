using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOwners : Photon.Pun.MonoBehaviourPun
{
    public VRTK.VRTK_InteractableObject toss;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	private void Toss_InteractableObjectGrabbed(object sender,VRTK.InteractableObjectEventArgs e)
    {
        //toss.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer.);
    }
}
