using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class RoomListing : MonoBehaviourPunCallbacks
{
    public Transform Grid;
    public GameObject RoomNamePrefab;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < Grid.childCount; i++)
        {
            if (Grid.GetChild(i).gameObject.GetComponentInChildren<Text>().text == roomList[i].Name)
            {
                Destroy(Grid.GetChild(i).gameObject);

                if (roomList[i].PlayerCount == 0)
                {
                    roomList.Remove(roomList[i]);
                }
            }
        }

        foreach (RoomInfo room in roomList)
        {
            if(room.RemovedFromList)
            {
                DeleteRoom(room);
            }
            else
            {
                AddRoom(room);
            }
        }
    }

    private void AddRoom(RoomInfo room)
    {
        Debug.Log("AddRoom : " + room.Name);
        GameObject obj = Instantiate(RoomNamePrefab, Vector2.zero, Quaternion.identity);
        obj.transform.SetParent(Grid.transform, false);
        //obj.GetComponentInChildren<Text>().text = string.Format("{0} --- {1} / {2}", room.Name, room.PlayerCount, room.MaxPlayers);
        obj.GetComponentInChildren<Text>().text = room.Name;
    }

    private void DeleteRoom(RoomInfo room)
    {
        Debug.Log("DeleteRoom : " + room.Name);

        int roomCounts = Grid.childCount;
        for (int i = 0; i < roomCounts; i++)
        {
            if(Grid.GetChild(i).gameObject.GetComponentInChildren<Text>().text == room.Name)
            {
                Destroy(Grid.GetChild(i).gameObject);
            }
        }
    }
}
