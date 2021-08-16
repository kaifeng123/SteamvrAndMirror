using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate("CubeGa", new Vector3(-2,0.5f,0), new Quaternion (0,0,0,0), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
