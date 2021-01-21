using System.Collections;
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
        Debug.Log("Joined Room");
        PhotonNetwork.Instantiate(headPrefab.name, ViveController.Instance.head.transform.position, ViveController.Instance.head.transform.rotation, 0);
        PhotonNetwork.Instantiate(rightHandPrefab.name, ViveController.Instance.leftHand.transform.position, ViveController.Instance.leftHand.transform.rotation, 0);
        PhotonNetwork.Instantiate(leftHandPrefab.name, ViveController.Instance.rightHand.transform.position, ViveController.Instance.rightHand.transform.rotation, 0);
         
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined in room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
