using ExitGames.Client.Photon;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Asteroids
{
    public class LobbyMainPanel : MonoBehaviourPunCallbacks
    {
        [Header("Login Panel")]
        public GameObject LoginPanel;

        public InputField PlayerNameInput;

        [Header("Selection Panel")]
        public GameObject SelectionPanel;

        [Header("Create Room Panel")]
        public GameObject CreateRoomPanel;

        public InputField RoomNameInputField;
        public InputField MaxPlayersInputField;

        [Header("Join Random Room Panel")]
        public GameObject JoinRandomRoomPanel;

        [Header("Room List Panel")]
        public GameObject RoomListPanel;

        public GameObject RoomListContent;
        public GameObject RoomListEntryPrefab;

        [Header("Inside Room Panel")]
        public GameObject InsideRoomPanel;

        public Button StartGameButton;
        public GameObject PlayerListEntryPrefab;

        private Dictionary<string, RoomInfo> cachedRoomList;
        private Dictionary<string, GameObject> roomListEntries;
        private Dictionary<int, GameObject> playerListEntries;

        #region UNITY

        public void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;

            cachedRoomList = new Dictionary<string, RoomInfo>();
            roomListEntries = new Dictionary<string, GameObject>();
            
            PlayerNameInput.text = "Player " + Random.Range(1000, 10000);
        }

        #endregion

        #region PUN CALLBACKS

        /// <summary>
        /// 
        /// </summary>
        public override void OnConnectedToMaster()
        {
            this.SetActivePanel(SelectionPanel.name);
        }

        /// <summary>
        /// 房间列表更新
        /// </summary>
        /// <param name="roomList"></param>
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            ClearRoomListView();

            UpdateCachedRoomList(roomList);
            UpdateRoomListView();
        }

        /// <summary>
        /// 离开大厅
        /// </summary>
        public override void OnLeftLobby()
        {
            cachedRoomList.Clear();

            ClearRoomListView();
        }

        /// <summary>
        /// 创建房间失败
        /// </summary>
        /// <param name="returnCode"></param>
        /// <param name="message"></param>
        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            SetActivePanel(SelectionPanel.name);
        }

        /// <summary>
        /// 加入房间失败
        /// </summary>
        /// <param name="returnCode"></param>
        /// <param name="message"></param>
        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            SetActivePanel(SelectionPanel.name);
        }

        /// <summary>
        /// 随机加入房间失败
        /// </summary>
        /// <param name="returnCode"></param>
        /// <param name="message"></param>
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            string roomName = "Room " + Random.Range(1000, 10000);

            RoomOptions options = new RoomOptions {MaxPlayers = 8};

            PhotonNetwork.CreateRoom(roomName, options, null);
        }

        /// <summary>
        /// 加入房间
        /// </summary>
        public override void OnJoinedRoom()
        {
            SetActivePanel(InsideRoomPanel.name);

            if (playerListEntries == null)
            {
                playerListEntries = new Dictionary<int, GameObject>();
            }

            foreach (Player p in PhotonNetwork.PlayerList)
            {
                GameObject entry = Instantiate(PlayerListEntryPrefab);
                entry.transform.SetParent(InsideRoomPanel.transform);
                entry.transform.localScale = Vector3.one;
                entry.GetComponent<PlayerListEntry>().Initialize(p.ActorNumber, p.NickName);

                object isPlayerReady;
                if (p.CustomProperties.TryGetValue(AsteroidsGame.PLAYER_READY, out isPlayerReady))
                {
                    entry.GetComponent<PlayerListEntry>().SetPlayerReady((bool) isPlayerReady);
                }

                playerListEntries.Add(p.ActorNumber, entry);
            }

            StartGameButton.gameObject.SetActive(CheckPlayersReady());

            Hashtable props = new Hashtable
            {
                {AsteroidsGame.PLAYER_LOADED_LEVEL, false}
            };
            PhotonNetwork.LocalPlayer.SetCustomProperties(props);
        }

        /// <summary>
        /// 离开房间
        /// </summary>
        public override void OnLeftRoom()
        {
            SetActivePanel(SelectionPanel.name);

            foreach (GameObject entry in playerListEntries.Values)
            {
                Destroy(entry.gameObject);
            }

            playerListEntries.Clear();
            playerListEntries = null;
        }

        /// <summary>
        /// 玩家进入房间
        /// </summary>
        /// <param name="newPlayer"></param>
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            GameObject entry = Instantiate(PlayerListEntryPrefab);
            entry.transform.SetParent(InsideRoomPanel.transform);
            entry.transform.localScale = Vector3.one;
            entry.GetComponent<PlayerListEntry>().Initialize(newPlayer.ActorNumber, newPlayer.NickName);

            playerListEntries.Add(newPlayer.ActorNumber, entry);

            StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        /// <summary>
        /// 玩家离开房间
        /// </summary>
        /// <param name="otherPlayer"></param>
        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Destroy(playerListEntries[otherPlayer.ActorNumber].gameObject);
            playerListEntries.Remove(otherPlayer.ActorNumber);

            StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        /// <summary>
        /// 房主切换
        /// </summary>
        /// <param name="newMasterClient"></param>
        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == newMasterClient.ActorNumber)
            {
                StartGameButton.gameObject.SetActive(CheckPlayersReady());
            }
        }

        /// <summary>
        /// 玩家属性更新
        /// </summary>
        /// <param name="targetPlayer"></param>
        /// <param name="changedProps"></param>
        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            if (playerListEntries == null)
            {
                playerListEntries = new Dictionary<int, GameObject>();
            }

            GameObject entry;
            if (playerListEntries.TryGetValue(targetPlayer.ActorNumber, out entry))
            {
                object isPlayerReady;
                if (changedProps.TryGetValue(AsteroidsGame.PLAYER_READY, out isPlayerReady))
                {
                    entry.GetComponent<PlayerListEntry>().SetPlayerReady((bool) isPlayerReady);
                }
            }

            StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        #endregion

        #region UI CALLBACKS

        public void OnBackButtonClicked()
        {
            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.LeaveLobby();
            }

            SetActivePanel(SelectionPanel.name);
        }

        public void OnCreateRoomButtonClicked()
        {
            string roomName = RoomNameInputField.text;
            roomName = (roomName.Equals(string.Empty)) ? "Room " + Random.Range(1000, 10000) : roomName;

            byte maxPlayers;
            byte.TryParse(MaxPlayersInputField.text, out maxPlayers);
            maxPlayers = (byte) Mathf.Clamp(maxPlayers, 2, 8);

            RoomOptions options = new RoomOptions {MaxPlayers = maxPlayers};

            PhotonNetwork.CreateRoom(roomName, options, null);
        }

        public void OnJoinRandomRoomButtonClicked()
        {
            SetActivePanel(JoinRandomRoomPanel.name);

            PhotonNetwork.JoinRandomRoom();
        }

        public void OnLeaveGameButtonClicked()
        {
            PhotonNetwork.LeaveRoom();
        }

        public void OnLoginButtonClicked()
        {
            string playerName = PlayerNameInput.text;

            if (!playerName.Equals(""))
            {
                PhotonNetwork.LocalPlayer.NickName = playerName;
                PhotonNetwork.ConnectUsingSettings();
            }
            else
            {
                Debug.LogError("Player Name is invalid.");
            }
        }

        public void OnRoomListButtonClicked()
        {
            if (!PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinLobby();
            }

            SetActivePanel(RoomListPanel.name);
        }

        public void OnStartGameButtonClicked()
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;

            //PhotonNetwork.LoadLevel("DemoAsteroids-GameScene");
            PhotonNetwork.LoadLevel(1);
            //PhotonNetwork.LoadLevel("Game");
        }

        #endregion

        private bool CheckPlayersReady()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                return false;
            }

            foreach (Player p in PhotonNetwork.PlayerList)
            {
                object isPlayerReady;
                if (p.CustomProperties.TryGetValue(AsteroidsGame.PLAYER_READY, out isPlayerReady))
                {
                    if (!(bool) isPlayerReady)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        
        private void ClearRoomListView()
        {
            foreach (GameObject entry in roomListEntries.Values)
            {
                Destroy(entry.gameObject);
            }

            roomListEntries.Clear();
        }

        public void LocalPlayerPropertiesUpdated()
        {
            StartGameButton.gameObject.SetActive(CheckPlayersReady());
        }

        private void SetActivePanel(string activePanel)
        {
            LoginPanel.SetActive(activePanel.Equals(LoginPanel.name));
            SelectionPanel.SetActive(activePanel.Equals(SelectionPanel.name));
            CreateRoomPanel.SetActive(activePanel.Equals(CreateRoomPanel.name));
            JoinRandomRoomPanel.SetActive(activePanel.Equals(JoinRandomRoomPanel.name));
            RoomListPanel.SetActive(activePanel.Equals(RoomListPanel.name));    // UI should call OnRoomListButtonClicked() to activate this
            InsideRoomPanel.SetActive(activePanel.Equals(InsideRoomPanel.name));
        }

        private void UpdateCachedRoomList(List<RoomInfo> roomList)
        {
            foreach (RoomInfo info in roomList)
            {
                // Remove room from cached room list if it got closed, became invisible or was marked as removed
                if (!info.IsOpen || !info.IsVisible || info.RemovedFromList)
                {
                    if (cachedRoomList.ContainsKey(info.Name))
                    {
                        cachedRoomList.Remove(info.Name);
                    }

                    continue;
                }

                // Update cached room info
                if (cachedRoomList.ContainsKey(info.Name))
                {
                    cachedRoomList[info.Name] = info;
                }
                // Add new room info to cache
                else
                {
                    cachedRoomList.Add(info.Name, info);
                }
            }
        }

        private void UpdateRoomListView()
        {
            foreach (RoomInfo info in cachedRoomList.Values)
            {
                GameObject entry = Instantiate(RoomListEntryPrefab);
                entry.transform.SetParent(RoomListContent.transform);
                entry.transform.localScale = Vector3.one;
                entry.GetComponent<RoomListEntry>().Initialize(info.Name, (byte)info.PlayerCount, info.MaxPlayers);

                roomListEntries.Add(info.Name, entry);
            }
        }
    }
}