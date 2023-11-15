using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
using System.IO;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPhotonManager : MonoBehaviourPunCallbacks
{
    public GameObject loginPanel;
    public GameObject lobbyCanvas;
    public TMP_Text jemok;
    public Button createRoom;
    public TMP_InputField inviteCodeInput;
    public TMP_InputField Nick_Input;
    public TMP_Text inviteCodeText;
    public GameObject PlayerAvater;
    public GameObject PlayerAvater2;
    private string randomInviteCode;
    public TMP_InputField PlayerNameInputField;
    public TMP_Text playerName;
    public TMP_Text playerName2;
    public GameObject Player;
    public TMP_Text ReadyText;
    public TMP_Text ReadyText2;
    public Button ReadyButton1;
    public Button ReadyButton3;
    public Button GameStart;
    bool Ready1 = false;
    bool Ready2 = false;
    bool GameStartButton = false;
    PhotonView pv;
    int PlayerCount = 0;

    private void Awake()
    {
        GameStart.interactable = false;
        Screen.SetResolution(960, 540, false);
        PhotonNetwork.SendRate = 60;
        ConnectToPhoton();
        createRoom.interactable = false;

        pv = GetComponent<PhotonView>();
    }

    private void ConnectToPhoton()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void RoomMake()
    {
        Debug.Log("서버 접속 완료");
        loginPanel.SetActive(false);
        lobbyCanvas.SetActive(true);
        CreateRoom();
    }

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 2
        };
        randomInviteCode = GenerateRandomInviteCode();
        Debug.Log("Random Invite Code: " + randomInviteCode);
        string roomCodePath = "RoomCodeTXT.txt";
        if (File.Exists(roomCodePath) == false)
        {
            using (StreamWriter sw = File.CreateText(roomCodePath))
            {
                sw.Write(randomInviteCode);
            }
        }
        else
        {
            File.WriteAllText(roomCodePath, randomInviteCode);
        }
        PhotonNetwork.CreateRoom(randomInviteCode, roomOptions);
    }

    public void RoomJoin()
    {
        Debug.Log("roomjoin");
        loginPanel.SetActive(false);
        lobbyCanvas.SetActive(true);
        string inputInviteCode = inviteCodeInput.text.Trim();
        PhotonNetwork.JoinRoom(inputInviteCode);

    }
    public override void OnJoinedRoom()
    {
        jemok.text = PhotonNetwork.CurrentRoom.Name;
        if (pv.IsMine)
        {
            playerName.text = PlayerNameInputField.text;
        }
        pv.RPC("playerInstinate", RpcTarget.All);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        pv.RPC("HostName", newPlayer, playerName.text);
    }
    [PunRPC]
    public void HostName(string name)
    {
        playerName.text = name;
        pv.RPC("NameSetting", RpcTarget.All, PlayerNameInputField.text);
    }
    [PunRPC]
    public void NameSetting(string name)
    {
        pv.RPC("NameSleep", RpcTarget.All);
    }
    [PunRPC]
    public void NameSleep()
    {
        playerName2.text = name;
        PlayerPrefs.SetString("playerName2.text", playerName2.text);
        PlayerPrefs.SetString("playerName.text", playerName.text);
        Debug.Log(playerName.text);
        Debug.Log(playerName2.text);
    }
    [PunRPC]
    public void playerInstinate()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PlayerAvater.SetActive(true);
        }
        // 인원이 2명일 때
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PlayerAvater.SetActive(true);
            PlayerAvater2.SetActive(true);
        }
    }
    private void FixedUpdate()
    {

    }
    [PunRPC]
    public void ReadyButton()
    {
        pv.RPC("ButtonClick", RpcTarget.All);

    }
    [PunRPC]
    public void ReadyButton2()
    {
        pv.RPC("ButtonClick2", RpcTarget.All);

    }
    [PunRPC]
    public void ButtonClick()
    {

        ReadyText.text = "ready";
        Ready1 = true;
    }
    [PunRPC]
    public void ButtonClick2()
    {
        ReadyText2.text = "ready";
        Ready2 = true;
    }
    private void Update()
    {
        if (Ready1 == true && Ready2 == true)
        {
            GameStart.interactable = true;
        }
    }
    public void EveryoneReady()
    {
        Debug.Log("11");
        if (GameStart.interactable == true)
        {
            GameStartButton = true;
        }
        if (GameStartButton == true)
        {
            pv.RPC("Sceneload", RpcTarget.All);
        }
    }

    [PunRPC]
    public void Sceneload()
    {
        SceneManager.LoadScene("GameScene");
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("방 생성 성공!");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.LogError("방 생성 실패: " + message);
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("마스터 서버에 연결됨");
        if (PhotonNetwork.IsConnected)
        {
            createRoom.interactable = true;
        }
    }

    private string GenerateRandomInviteCode()
    {
        const string chars = "0123456789";
        int codeLength = 6;

        StringBuilder codeBuilder = new StringBuilder();
        System.Random random = new System.Random();

        for (int i = 0; i < codeLength; i++)
        {
            int randomIndex = random.Next(0, chars.Length);
            char randomChar = chars[randomIndex];
            codeBuilder.Append(randomChar);
        }

        return codeBuilder.ToString();
    }

}