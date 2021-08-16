using System.Collections;
using System.Collections.Generic;
using Common;
using ExitGames.Client.Photon;
using UnityEngine;

public class RegisterRequest : Request
{
    [HideInInspector]
    public string Username;
    [HideInInspector]
    public string Password;

    private RegPanel regPanel;

    public override void Start()
    {
        base.Start();
        regPanel = GetComponent<RegPanel>();
    }

    public override void DefaultRequest()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)ParameterCode.Username, Username);
        data.Add((byte)ParameterCode.Password, Password);
        PtotonEngine.Peer.OpCustom((byte)OpCode, data, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        ReturnCode returnCode = (ReturnCode)operationResponse.ReturnCode;
        regPanel.OnRegisterResponse(returnCode);
    }
}
