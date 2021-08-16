using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Tools;
using VRTK;
using Photon.Pun;

public class VRPlayer : MonoBehaviourPun
{
    public bool isLocalPlayer = true;

    private SyncPositionRequest syncPositionRequest;

    private SyncPlayerRequest syncPlayerRequest;

    private Vector3 lastPosition = Vector3.zero;

    public string userName;

    public GameObject playerPrefab;

    public GameObject player;


    private Dictionary<string, GameObject> playerDic = new Dictionary<string, GameObject>();


    // Use this for initialization
    void Start()
    {
        //if(isLocalPlayer)
        //{
        StartCoroutine(WaitToDo());
        //}
    }

    IEnumerator WaitToDo()
    {
        yield return new WaitForSeconds(1f);
        player.transform.Find("Player").GetComponent<Renderer>().material.color = Color.red;
        syncPositionRequest = GetComponent<SyncPositionRequest>();
        syncPlayerRequest = GetComponent<SyncPlayerRequest>();
        syncPlayerRequest.DefaultRequest();
        InvokeRepeating("SyncPosition", 3, 0.2f);
        userName = PhotonNetwork.NickName;
        Debug.Log("userName --->" + userName);
    }

    // Update is called once per frame
    void Update()
    {
        #region 测试
        //if(isLocalPlayer)
        //{
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //player.transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 5);
        //}
        #endregion 
    }

    void SyncPosition()
    {
        if (Vector3.Distance(player.transform.position, lastPosition) > 0.1f)
        {
            lastPosition = player.transform.position;
            syncPositionRequest.pos = player.transform.position;
            syncPositionRequest.DefaultRequest();
        }
        
    }


    public void OnSyncPlayerResponse(List<string> usernameList)
    {
        //创建其他客户端的player角色
        foreach (var username in usernameList)
        {
            Debug.Log(userName);
            OnNewPlayerEvent(username);
        }
    }

    public void OnNewPlayerEvent(string username)
    {
        if(userName != username)
        {
            GameObject go = GameObject.Instantiate(playerPrefab);
            DestroyImmediate(go.GetComponentInChildren<SDK_InputSimulator>());
            #region
            //DestroyImmediate(go.GetComponent<VRTK_SDKSetup>());
            //DestroyImmediate(go.transform.Find("VRSimulatorCameraRig").GetComponent<SDK_InputSimulator>());
            //DestroyImmediate(go.transform.Find("LeftHand").GetComponent<SDK_ControllerSim>());
            //DestroyImmediate(go.transform.Find("RightHand").GetComponent<SDK_ControllerSim>());
            #endregion
            playerDic.Add(username, go);
        }
       
    }

    public void OnSyncPositionEvent(List<PlayerData> playerDataList)
    {
        foreach (PlayerData pd in playerDataList)
        {
            GameObject go = DictTool.GetValue<string, GameObject>(playerDic, pd.Username);
            if (go != null)
                go.transform.position = new Vector3() { x = pd.Pos.x, y = pd.Pos.y, z = pd.Pos.z };
        }
    }
}
