using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Tools;


public class Player : MonoBehaviour
{
    public bool isLocalPlayer = true;

    private SyncPositionRequest syncPositionRequest;

    private SyncPlayerRequest syncPlayerRequest;

    private Vector3 lastPosition = Vector3.zero;

    public string username;

    public GameObject playerPrefab;

    public GameObject player;

    private Dictionary<string, GameObject> playerDic = new Dictionary<string, GameObject>();

    // Use this for initialization
    void Start()
    {
        //if(isLocalPlayer)
        //{
            player.GetComponent<Renderer>().material.color = Color.red;
            syncPositionRequest = GetComponent<SyncPositionRequest>();
            syncPlayerRequest = GetComponent<SyncPlayerRequest>();
            syncPlayerRequest.DefaultRequest();
            InvokeRepeating("SyncPosition", 3, 0.2f);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if(isLocalPlayer)
        //{
           
        float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            player.transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 5);
        //}
    }

    void SyncPosition()
    {
        if(Vector3.Distance(player.transform.position,lastPosition)>0.1f)
        {
            lastPosition = player.transform.position;
            syncPositionRequest.pos = player.transform.position;
            syncPositionRequest.DefaultRequest();
        }
    }


    public void OnSyncPlayerResponse(List<string>usernameList)
    {
        //创建其他客户端的player角色
        foreach (var username in usernameList)
        {
            OnNewPlayerEvent(username);
        }      
    }

    public void OnNewPlayerEvent(string username)
    {
            GameObject go = GameObject.Instantiate(playerPrefab);
            playerDic.Add(username, go);
    }

    public void OnSyncPositionEvent(List<PlayerData>playerDataList)
    {
        foreach (PlayerData pd in playerDataList)
        {
           GameObject go = DictTool.GetValue<string, GameObject>(playerDic,pd.Username);
           if(go != null)
                go.transform.position = new Vector3() { x = pd.Pos.x, y = pd.Pos.y, z = pd.Pos.z };            
        }
     }
 }
