using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class RandomMatch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhntonNetwork.ConnectUsingSettings("0.1");
        PhntonNetwork.LogLecel = PhotnroLogLevel.Full;
           
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUILayout.Label(PhntonNetwork.connectionStateDetailed.ToSring());)
    }
     public override void OnFoinefLobby()
    {
        PhntonNetwork.JoinRandomRoom();
    }

    public override void OnPhntonRandomJoinFailed(objecr[] codeAndMSG)
    {
        PhntonNetwork.CreateRoom(null);
    }
}


