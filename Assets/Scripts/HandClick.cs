using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandClick : MonoBehaviour
{
    [SerializeField]
    GameObject jilet;
    [SerializeField]
    GameObject kaska;
    bool takeKaska = false;
    bool takeJilet = false;
    public bool weaponReady = false;
    public bool teleportToCabinet = false;
    bool firstPointInCab = false;
    bool secondPointInCab = false;
    bool thirdPointInCab = false;
    public bool cabTask = false;
    public bool teleportBack = false;
    public bool telepotrToKitchen = false;
    public bool error = false;
    void Start()
    {
        gameObject.tag = "Player";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "kaska")
        {
            kaska.SetActive(false);
            takeKaska = true;
        }
        if (other.tag == "jilet")
        {
            jilet.SetActive(false);
            takeJilet = true;
        }
        if (other.tag == "teleport")
        {
            teleportToCabinet = true;
            Debug.Log(teleportToCabinet);
        }
        if (other.tag == "firstcab")
        {
            firstPointInCab = true;
        }
        if (other.tag == "seccab")
        {
            secondPointInCab = true;
        }
        if (other.tag == "thirdkab")
        {
            thirdPointInCab = true;
        }
        if (other.tag == "teleportback")
        {
            teleportBack = true;
        }
        if (other.tag == "teleporttokit")
        {
            telepotrToKitchen = true;
        }
        if (other.tag == "error")
        {
            error = true;
        }

    }
    private void FixedUpdate()
    {
        if (takeKaska && takeJilet)
            weaponReady = true;
        if (firstPointInCab && secondPointInCab && thirdPointInCab)
        {
            cabTask = true;
        }
    }
}
