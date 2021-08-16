using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnCube : MonoBehaviour
{
    public GameObject cubePrefab;
    SteamVR_Controller.Device lDevice;
     public SteamVR_TrackedObject lTrack;

    void Start()
    {
        lTrack = GetComponent<SteamVR_TrackedObject>();
        lDevice = SteamVR_Controller.Input((int)lTrack.index);


    }
    void Update()
    {
        //var lDevice = SteamVR_Controller.Input((int)lTrack.index);
        //var rDevice = SteamVR_Controller.Input((int)ViveManager.Instance.R_Hand.GetComponent<SteamVR_TrackedObject>().index);
        if (lDevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            PhotonNetwork.Instantiate(cubePrefab.name, ViveManager.Instance.R_Hand.transform.position, ViveManager.Instance.R_Hand.transform.rotation,0,new object[] {123456789});
        }
        //if (rDevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        //{
        //    PhotonNetwork.Instantiate(cubePrefab.name, ViveManager.Instance.R_Hand.transform.position, ViveManager.Instance.R_Hand.transform.rotation, 0);
        //}

    }
}
