using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class RandomMatch : MonoBehaviourPunCallbacks {

    public GameObject Player;

    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LogLevel = PunLogLevel.Full;


        

    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");

        // ロビーに入る
        //PhotonNetwork.JoinLobby();
        PhotonNetwork.JoinRandomRoom();//ランダムでルームに接続する
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }
    // public override void OnJoinedLobby()
    //{
    //    Debug.Log("ロービーです");
    //    PhotonNetwork.CreateRoom(null);
        //PhotonNetwork.JoinRandomRoom();//ランダムでルームに接続する
        
    //}

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
       Debug.Log("失敗");
       PhotonNetwork.CreateRoom(null);//ルームがなかったらルームを作る
       

    }

    public override void OnJoinedRoom()
    {
        //Debug.Log("aaa");

        Vector3 spawnPosition = new Vector3(-2, 0);
        PhotonNetwork.Instantiate("cat", spawnPosition, Quaternion.identity, 0);

        Player.tag = "cat";

    }

  
}