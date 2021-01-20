using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class networkPlayerSpawn : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;
    int a = 0;


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
        spawnedPlayerPrefab.tag = string.Format("player {0}", a);
        Camera.main.gameObject.transform.SetParent(spawnedPlayerPrefab.transform);
        a++;
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab); 
    }
}
