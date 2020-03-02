using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class NetWorkManager : MonoBehaviourPunCallbacks
{
    public static string userName;
    public InputField input;
    // Start is called before the first frame update
    void Start()
    {
        //Connect();
    }

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.OfflineMode = false;
            PhotonNetwork.ConnectUsingSettings();
        }
        Debug.Log("connecting......");
    }

    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        Debug.Log("connected");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        //base.OnDisconnected(cause);
        Debug.Log("disconnect");
    }
    
    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        Debug.Log("join room success");
        userName = input.text;

        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("join room fail , try to create");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 8 });
        Debug.Log("create new room");
    }
}
