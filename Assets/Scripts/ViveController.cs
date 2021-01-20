using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveController : MonoBehaviour
{
    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;

    public static ViveController Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
