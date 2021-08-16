using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SendRequest();
            Debug.Log(6666);
        }
    }

    private void SendRequest()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add(1, 666);
        data.Add(2, "ptserver");

        PtotonEngine.Peer.OpCustom(1,data, true);
    }
}
