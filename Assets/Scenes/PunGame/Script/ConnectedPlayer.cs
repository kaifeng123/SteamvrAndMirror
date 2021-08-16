using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ConnectedPlayer : MonoBehaviour
{
    public GameObject CurrentPlayer_Prefab;

    public GameObject CurrentPlayers_Grid;

    public void AddLocalPlayer()
    {
        GameObject obj = Instantiate(CurrentPlayer_Prefab, Vector2.zero, Quaternion.identity);
        obj.transform.SetParent(CurrentPlayers_Grid.transform, false);
        obj.GetComponentInChildren<Text>().text = "YOU : " + PhotonNetwork.NickName;
        obj.GetComponentInChildren<Text>().color = Color.green;
    }

    [PunRPC]
    public void UpdatePlayerList(string name)
    {
        GameObject obj = Instantiate(CurrentPlayer_Prefab, Vector2.zero, Quaternion.identity);
        obj.transform.SetParent(CurrentPlayers_Grid.transform, false);
        obj.GetComponentInChildren<Text>().text = name;
    }

    public void RemovePlayerList(string name)
    {
        foreach (Text playName in CurrentPlayers_Grid.GetComponentsInChildren<Text>())
        {
            if (name == playName.text)
                Destroy(playName.transform.parent.gameObject);
        }
    }
}
