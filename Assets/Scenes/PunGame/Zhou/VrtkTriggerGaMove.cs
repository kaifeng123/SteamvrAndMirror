using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrtkTriggerGaMove : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 10;
    private bool boo = false;
    // Start is called before the first frame update
    void Start()
    {
        boo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float horizontal = Input.GetAxis("Horizontal"); //A D 左右
            float vertical = Input.GetAxis("Vertical"); //W S 上 下

            transform.Translate(Vector3.forward * vertical * moveSpeed * Time.deltaTime);//W S 上 下
            transform.Translate(Vector3.right * horizontal * moveSpeed * Time.deltaTime);//A D 左右
            Debug.Log("123");
            if (boo)
            {
                TimerManager.instance.DoLoop(200, () =>
                {
                    boo = false;
                    photonView.RPC("SetPoint", RpcTarget.Others, transform.position.x, transform.position.z);
                });
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            boo = true;
            TimerManager.instance.RemoveAllHandler();
            photonView.RPC("SetPoint", RpcTarget.OthersBuffered, transform.position.x, transform.position.z);
        }
    }
    public void StartRpc()
    {
        TimerManager.instance.DoLoop(50, SetRpc);
    }
    private void SetRpc()
    {
        Debug.Log(transform.position);
        photonView.RPC("SetPoint", RpcTarget.OthersBuffered, transform.position.x, transform.position.y, transform.position.z);
    }
    public void StopRpc()
    {
        SetRpc();
        TimerManager.instance.RemoveHandler(SetRpc);
    }
    Vector3 v3 = new Vector3();
    [PunRPC]
    private void SetPoint(float x, float y, float z)
    {
        Debug.Log(gameObject.name+"坐标:x:"+x+",y:" +y+"z:"+z);
       // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(z, y, z), ref v3, 0.2f);
        transform.position = new Vector3(z, y, z);
    }


}
