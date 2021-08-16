using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    public int sphereSpeed;
    // Start is called before the first frame update
    void Start()
    {
        TimerManager.instance.DoOnce(4000, RemoveInstGa);
    }
    void RemoveInstGa()
    {
      if(GetComponent<PhotonView>().IsMine) 
        PhotonNetwork.Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Rigidbody instance = transform.GetComponent<Rigidbody>();
        Vector3 fwd = transform.TransformDirection(Vector3.forward);//面朝的方向作为力的方向
        instance.AddForce(sphereSpeed * fwd);
    }
}
