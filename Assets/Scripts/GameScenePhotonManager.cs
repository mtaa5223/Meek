using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScenePhotonManager : MonoBehaviourPunCallbacks
{
    PhotonView pv;
    public GameObject[] spawnpoints;
    public TMP_Text Name;
    public GameObject Player1;
    public GameObject Player2;
    void Start()
    {
        //Name = 
        pv = GetComponent<PhotonView>();
        if (pv.IsMine)
        {
            Vector3 spawnPosition = spawnpoints[0].transform.position;
            Player1 = PhotonNetwork.Instantiate("Player", spawnPosition, Quaternion.identity);
        }
        else
        {
            Vector3 spawnPosition = spawnpoints[1].transform.position;
            Player2 = PhotonNetwork.Instantiate("Player", spawnPosition, Quaternion.identity);
        }
        Player1.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PlayerPrefs.GetString("playerName.text");
        Debug.Log(PlayerPrefs.GetString("playerName.text"));
        Player2.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = PlayerPrefs.GetString("playerName2.text");
        Debug.Log(PlayerPrefs.GetString("playerName2.text"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
