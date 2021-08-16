using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GameMananger : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    public GameObject canvas;

    public GameObject feedBox,feedText_Prefab;


    public ConnectedPlayer cp;
    public GameObject cpCanvas;

    public GameObject headPrefab;

    public GameObject L_handPrefab;

    public GameObject R_handPrefab;

    private void Awake()
    {
        canvas.SetActive(true);
        
    }

    private void Start()
    {
        cp.AddLocalPlayer();
        cp.GetComponent<PhotonView>().RPC("UpdatePlayerList", RpcTarget.OthersBuffered, PhotonNetwork.NickName);     
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
            cpCanvas.SetActive(true);
        else
            cpCanvas.SetActive(false);
    }


    /// <summary>
    /// 创建玩家
    /// </summary>
    public void SpawnPlayer()
    {
        float rangeValue = Random.Range(-10, 10);
        //PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(PlayerPrefab.transform.position.x * rangeValue, 2, PlayerPrefab.transform.position.z * rangeValue), Quaternion.identity);

        PhotonNetwork.Instantiate(headPrefab.name, ViveManager.Instance.head.transform.position, ViveManager.Instance.head.transform.rotation, 0);

        PhotonNetwork.Instantiate(L_handPrefab.name, ViveManager.Instance.L_Hand.transform.position, ViveManager.Instance.L_Hand.transform.rotation, 0);

        PhotonNetwork.Instantiate(R_handPrefab.name, ViveManager.Instance.R_Hand.transform.position, ViveManager.Instance.R_Hand.transform.rotation, 0);
        canvas.SetActive(false);
    }



    /// <summary>
    /// 玩家进入房间
    /// </summary>
    /// <param name="Player"></param>
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player Player)
    {
        GameObject go = Instantiate(feedText_Prefab, Vector2.zero, Quaternion.identity);
        go.transform.SetParent(feedBox.transform);
        go.transform.localScale = Vector3.one;
        go.GetComponent<Text>().text = Player.NickName + " --- 加入房间 --- " + System.DateTime.Now;
        Destroy(go, 5f);
        Debug.Log("OnPlayerEnteredRoom : " + Player.NickName);

    }

    /// <summary>
    /// 玩家离开房间
    /// </summary>
    /// <param name="Player"></param>
    public override void OnPlayerLeftRoom(Photon.Realtime.Player Player)
    {
        cp.RemovePlayerList(Player.NickName);
        GameObject go = Instantiate(feedText_Prefab, Vector2.zero, Quaternion.identity);
        go.transform.SetParent(feedBox.transform);
        go.transform.localScale = Vector3.one;
        go.GetComponent<Text>().text = Player.NickName + " --- 离开房间 --- " + System.DateTime.Now;
        Destroy(go, 5f);
        Debug.Log("OnPlayerLeftRoom : " + Player.NickName);
    }
}
