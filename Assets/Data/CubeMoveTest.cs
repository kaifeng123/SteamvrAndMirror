using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class CubeMoveTest : MonoBehaviourPunCallbacks, IPunObservable
{
    public float moveSpeed = 10;
    PhotonView m_PhotonView;
    Vector3 m_NetworkPosition;
    private Vector3 m_StoredPosition;
    float m_Distance;
    // Start is called before the first frame update
    void Start()
    {
        m_StoredPosition = transform.position;
        m_PhotonView = GetComponent<PhotonView>();
    }
    bool boo;
    // Update is called once per frame
    void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        //float vertical = Input.GetAxis("Vertical"); //W S 上 下

        //transform.Translate(-Vector3.forward * vertical * moveSpeed * Time.deltaTime);//W S 上 下
        //transform.Translate(-Vector3.right * horizontal * moveSpeed * Time.deltaTime);//A D 左右

        //if (photonView)
        //{
        //    if (horizontal != 0 || vertical != 0)
        //    {
        //        Debug.Log("发送:" + transform.position);
        //        photonView.RPC("SetPoint", RpcTarget.AllBuffered, transform.position.x,
        //      transform.position.z);
        //        boo = true;
        //    }
        //    else
        //        boo = false;
        //}
        if (!this.m_PhotonView.IsMine)
        {
            transform.position = Vector3.MoveTowards(transform.position, this.m_NetworkPosition, this.m_Distance * (1.0f / PhotonNetwork.SerializationRate));
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, this.m_NetworkRotation, this.m_Angle * (1.0f / PhotonNetwork.SerializationRate));
        }

    }
    public void SetCubePositionRPC()
    {
        StartRPC();
       // TimerManager.instance.DoLoop(10, StartRPC);

    }
    public void OpenCubePositionRPC()
    {
       // StartRPC();
       //TimerManager.instance.RemoveHandler(StartRPC);
    }

    public void StartRPC()
    {

        photonView.RPC("SetPoint", RpcTarget.OthersBuffered, transform.position.x,
        transform.position.z);
    }
    [PunRPC]
    private void SetPoint(float h, float v)
    {
        Debug.Log("接受:" + new Vector3(h, transform.position.y, v));
        if (!boo)
            transform.position = new Vector3(h, transform.position.y, v);
        //transform.Translate(Vector3.forward * h * moveSpeed * Time.deltaTime);//W S 上 下
        //transform.Translate(Vector3.right * v * moveSpeed * Time.deltaTime);//A D 左右
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    }

}
