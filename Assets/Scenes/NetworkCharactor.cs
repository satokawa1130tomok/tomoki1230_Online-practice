using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class NetworkCharactor : MonoBehaviour
{
    void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            bool jumpFlg = GetComponent<PlayerController>().jumpFlg;
            if (jumpFlg)
            {
                Debug.Log("Send JumpFlg:" + jumpFlg);

            }
            stream.SendNext(jumpFlg);

            GetComponent<PlayerController>().jumpFlg = false;
        }
        else
        {
            bool jumpFlg = (bool)stream.ReceiveNext();
            if (jumpFlg)
            {
                GetComponent<Animator>().SetTrigger("JumpTrigger");
                Debug.Log("Recieve JumpFlg:" + jumpFlg);
            }
        }
    }

}

