﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager2 : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject headPrefab;
    [SerializeField]
    GameObject leftHandPrefab;
    [SerializeField]
    GameObject rightHandPrefab;
    GameObject localPlayerPrefab;
    GameObject netPlayerPrefab;
    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connecnt");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Room1", roomOptions, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        float a = 1;
        localPlayerPrefab = new GameObject("Player");
        netPlayerPrefab = new GameObject("NetPlayer");
        GameObject Head = PhotonNetwork.Instantiate(headPrefab.name, ViveController.Instance.head.transform.position, ViveController.Instance.head.transform.rotation, 0);
        GameObject RHand = PhotonNetwork.Instantiate(rightHandPrefab.name, ViveController.Instance.leftHand.transform.position, ViveController.Instance.leftHand.transform.rotation, 0);
        GameObject LHand = PhotonNetwork.Instantiate(leftHandPrefab.name, ViveController.Instance.rightHand.transform.position, ViveController.Instance.rightHand.transform.rotation, 0);
        switch (a)
        {
                  
            case 1:
                Debug.Log("Joined Room");
                Head.transform.SetParent(localPlayerPrefab.transform, true);
                RHand.transform.SetParent(localPlayerPrefab.transform, true);
                LHand.transform.SetParent(localPlayerPrefab.transform, true);
                localPlayerPrefab.tag = string.Format("Player");
                break;
            case 2:
                Head.transform.SetParent(netPlayerPrefab.transform, true);
                RHand.transform.SetParent(netPlayerPrefab.transform, true);
                LHand.transform.SetParent(netPlayerPrefab.transform, true);
                netPlayerPrefab.tag = string.Format("netplayer");
                break;
        }
        a++; 
        
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined in room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
