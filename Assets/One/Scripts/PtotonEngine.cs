using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Common;
using Common.Tools;


public class PtotonEngine : MonoBehaviour, IPhotonPeerListener
{

    public static PtotonEngine Instance;

    private static PhotonPeer peer;

    public static PhotonPeer Peer
    {
        get
        {
            return peer;
        }
    }

    public static string username;

    private Dictionary<OperationCode, Request> RequestDic = new Dictionary<OperationCode, Request>();

    private Dictionary<EventCode, BaseEvent> EventDic = new Dictionary<EventCode, BaseEvent>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void Start()
    {
        //通过Listene接受服务器的响应
        peer = new PhotonPeer(this, ConnectionProtocol.Udp);
        //peer.Connect("127.0.0.1:5055","MyGame");
        peer.Connect("192.168.1.100:5055", "MyGame");
    }

    // Update is called once per frame
    void Update()
    {
        //if(peer.PeerState ==PeerStateValue.Connected)
        peer.Service();
    }


    void OnDestroy()
    {
        if (peer != null && peer.PeerState == PeerStateValue.Connected)
        {
            peer.Disconnect();
        }
    }


    public void DebugReturn(DebugLevel level, string message)
    {

    }

    public void OnEvent(EventData eventData)
    {
        #region
        //switch (eventData.Code)
        //{
        //    case 1:
        //        Debug.Log("收到服务器端发送过来的时间");
        //        Dictionary<byte, object> data = eventData.Parameters;
        //        object intValue, stringValue;
        //        data.TryGetValue(1, out intValue);
        //        data.TryGetValue(2, out stringValue);
        //        Debug.Log(intValue.ToString() + "-----" + stringValue.ToString());
        //        break;
        //    case 2:
        //        break;
        //    default:
        //        break;
        //}
        #endregion

        EventCode code = (EventCode)eventData.Code;

        BaseEvent e = DictTool.GetValue<EventCode, BaseEvent>(EventDic, code);
        //e.OnEvent(eventData);
    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        OperationCode opCode = (OperationCode)operationResponse.OperationCode;
        Request request = null;
        bool temp = RequestDic.TryGetValue(opCode, out request);

        if (temp)
        {
            request.OnOperationResponse(operationResponse);
        }
        else
        {
            Debug.Log("---Not found Response object!!");
        }
    }

    /// <summary>
    /// 状态转换通知
    /// </summary>
    /// <param name="statusCode"></param>
    public void OnStatusChanged(StatusCode statusCode)
    {

    }

    /// <summary>
    /// 添加请求
    /// </summary>
    /// <param name="request"></param>
    public void AddRequest(Request request)
    {
        RequestDic.Add(request.OpCode, request);
    }


    /// <summary>
    /// 移除请求
    /// </summary>
    /// <param name="request"></param>
    public void RemoverRequst(Request request)
    {
        RequestDic.Remove(request.OpCode);
    }


    /// <summary>
    /// 添加事件
    /// </summary>
    /// <param name="e"></param>
    public void AddEvent(BaseEvent e)
    {
        EventDic.Add(e.eventCode, e);
    }


    /// <summary>
    /// 移除事件
    /// </summary>
    /// <param name="e"></param>
    public void RemoverEvent(BaseEvent e)
    {
        EventDic.Remove(e.eventCode);
    }


}
