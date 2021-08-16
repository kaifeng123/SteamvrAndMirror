using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour, IPunObservable
/// </summary>
[AddComponentMenu("Photon Networking/CubeTransformViewTest")]
[HelpURL("https://doc.photonengine.com/en-us/pun/v2/gameplay/synchronization-and-state")]
[RequireComponent(typeof(PhotonView))]
public class CubeTransformViewTest : MonoBehaviourPunCallbacks, IPunObservable
{
    private float m_Distance;
    private float m_Angle;

    private PhotonView m_PhotonView;

    private Vector3 m_Direction;
    private Vector3 m_NetworkPosition;
    private Vector3 m_StoredPosition;

    private Quaternion m_NetworkRotation;

    public bool m_SynchronizePosition = true;
    public bool m_SynchronizeRotation = true;
    public bool m_SynchronizeScale = false;

    bool m_firstTake = false;
    public bool isWrite = false;
    /// <summary>
    /// 物体是否处于移动中
    /// </summary>
    public bool isNoMove;
    public void Awake()
    {
        m_PhotonView = GetComponent<PhotonView>();
        m_PhotonView.isIndependent = false;
        m_StoredPosition = transform.position;
        m_NetworkPosition = Vector3.zero;
        m_NetworkRotation = Quaternion.identity;
    }
    public override void OnEnable()
    {
        isWrite = false;
        isNoMove = false;
        m_firstTake = true;
        gaPosition = transform.position;
        base.OnEnable();
    }
    Vector3 gaPosition;
    public void Update()
    {
        if (gaPosition != this.m_NetworkPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, this.m_NetworkPosition, this.m_Distance * (1.0f / PhotonNetwork.SerializationRate));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, this.m_NetworkRotation, this.m_Angle * (1.0f / PhotonNetwork.SerializationRate));
            gaPosition = transform.position;
        }
    }
    public void SetCubeTranSformViewIsMoveRPC(bool _isNoMove)
    {
        photonView.RPC("SetIsMoveboo", RpcTarget.AllBuffered, _isNoMove);
    }
    [PunRPC]
    private void SetIsMoveboo(bool _isNoMove)
    {
        Debug.Log("是否独立:"+_isNoMove);
        isNoMove = _isNoMove;
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log("IsWriting:"+ stream.IsWriting+ "---isWrite:"+isWrite);
        if (stream.IsWriting && isWrite)
        {
            Debug.Log("发送数据");
            if (this.m_SynchronizePosition)
            {
                this.m_Direction = transform.position - this.m_StoredPosition;
                this.m_StoredPosition = transform.position;

                stream.SendNext(transform.position);
                stream.SendNext(this.m_Direction);
            }

            if (this.m_SynchronizeRotation)
            {
                stream.SendNext(transform.rotation);
            }

            if (this.m_SynchronizeScale)
            {
                stream.SendNext(transform.localScale);
            }
        }
        else if (!stream.IsWriting)
        {
            Debug.Log("接受cube发回的数据");
            if (stream.PeekNext() == null)
                return;
            if (this.m_SynchronizePosition)
            {
                this.m_NetworkPosition = (Vector3)stream.ReceiveNext();
                this.m_Direction = (Vector3)stream.ReceiveNext();

                if (m_firstTake)
                {
                    transform.position = this.m_NetworkPosition;
                    this.m_Distance = 0f;
                }
                else
                {
                    float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
                    this.m_NetworkPosition += this.m_Direction * lag;
                    this.m_Distance = Vector3.Distance(transform.position, this.m_NetworkPosition);
                }


            }

            if (this.m_SynchronizeRotation)
            {
                this.m_NetworkRotation = (Quaternion)stream.ReceiveNext();

                if (m_firstTake)
                {
                    this.m_Angle = 0f;
                    transform.rotation = this.m_NetworkRotation;
                }
                else
                {
                    this.m_Angle = Quaternion.Angle(transform.rotation, this.m_NetworkRotation);
                }
            }

            if (this.m_SynchronizeScale)
            {
                transform.localScale = (Vector3)stream.ReceiveNext();
            }

            if (m_firstTake)
            {
                m_firstTake = false;
            }
        }
    }
}
