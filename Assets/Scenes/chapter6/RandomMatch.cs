using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class RandomMatch : MonoBehaviourPunCallbacks {


    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LogLevel = PunLogLevel.Full;
           
    }
    

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }
     public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();//ランダムでルームに接続する
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.CreateRoom(null);//ルームがなかったらルームを作る
        Vector3 spawnPosition = new Vector3(Random.Range(-2, 2), -4.395f, 0);
        PhotonNetwork.Instantiate("satPrefab", spawnPosition, Quaternion, identiy, 0);
    }
  
}


