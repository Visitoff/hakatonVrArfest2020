using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CopyScript : MonoBehaviourPunCallbacks
{
    public int index = 1;
    void Start()
    {

    }

    void Update()
    {
        if (photonView.IsMine)
        {
            switch (index)
            {
                case 1:
                    transform.position = ViveController.Instance.head.transform.position;
                    transform.rotation = ViveController.Instance.head.transform.rotation;
                    break;
                case 2:
                    transform.position = ViveController.Instance.leftHand.transform.position;
                    transform.rotation = ViveController.Instance.leftHand.transform.rotation;
                    break;
                case 3:
                    transform.position = ViveController.Instance.rightHand.transform.position;
                    transform.rotation = ViveController.Instance.rightHand.transform.rotation;
                    break;

            }
        }
    }
}
