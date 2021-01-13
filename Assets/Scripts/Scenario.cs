﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Scenario : MonoBehaviour
{

    [SerializeField]
    GameObject hintToKitch;
    [SerializeField]
    GameObject hintTocab;
    [SerializeField]
    GameObject hint1;
    [SerializeField]
    GameObject hint2;
    [SerializeField]
    GameObject hint3;
    [SerializeField]
    GameObject checkBar;
    [SerializeField]
    Transform teleportKitchen;
    [SerializeField]
    Transform teleportTarget;
    [SerializeField]
    Transform teleportToCab;
    [SerializeField]
    Transform teleportFromCab;
    [SerializeField]
    Transform cabinet;
    [SerializeField]
    Transform player;
    [SerializeField]
    HandClick handClick;
    [SerializeField]
    Material image1;
    [SerializeField]
    Material image2;
    [SerializeField]
    Material image3;
    [SerializeField]
    Material image4;
    [SerializeField]
    Material image5;
    [SerializeField]
    Material image6;
    [SerializeField]
    Material imageCrtError;
    [SerializeField]
    Material imageError;
    float a = 0f;
    float timeOfGame = 0f;
    public LoadScreen ld;
    float newScenarioMode;

    //Извиняюсь перед всеми программистами кто это читает:)
    private void Awake()
    {
        hintToKitch.SetActive(false);
        player.transform.position = teleportTarget.transform.position;
        StartCoroutine(First());
        GameObject objs = GameObject.FindGameObjectWithTag("param");
        newScenarioMode = objs.GetComponent<LoadScreen>().ScenarioMode;
        Destroy(objs);
    }
    
    

    void FixedUpdate()
    {
        
       

        if (newScenarioMode == 1)
        {
            hint1.SetActive(false);
            hint2.SetActive(false);
            hint3.SetActive(false);
        }
        if (newScenarioMode == 3)
        {
            handClick.weaponReady = true;
            handClick.teleportToCabinet = true;
            handClick.cabTask = true;
        }

        if (newScenarioMode == 2 && handClick.error)
        {
            a += Time.deltaTime;
            checkBar.GetComponent<MeshRenderer>().material = imageError;
            if (a > 3f)
            {
                handClick.error = false;

            }
        }
        if (newScenarioMode == 1 && handClick.error)
        {
            a += Time.deltaTime;
            checkBar.GetComponent<MeshRenderer>().material = imageCrtError;
            if (a > 5f)
            {
                Time.timeScale = 0f;
            }

        }
        if (SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand))
        {

            SceneManager.LoadScene("LoadScreen", LoadSceneMode.Single);
        }
    }
    IEnumerator First()
    {
        yield return new WaitWhile(() => !handClick.weaponReady);
        checkBar.GetComponent<MeshRenderer>().material = image1;
        yield return new WaitWhile(() => !handClick.teleportToCabinet);
        checkBar.GetComponent<MeshRenderer>().material = image2;
        player.transform.position = cabinet.transform.position;
        yield return new WaitWhile(() => !handClick.cabTask);
        Debug.Log("задания в каморке");
        checkBar.GetComponent<MeshRenderer>().material = image3;
        yield return new WaitWhile(() => !handClick.teleportBack);
        checkBar.GetComponent<MeshRenderer>().material = image4;
        player.transform.position = teleportFromCab.transform.position;
        hintTocab.SetActive(false);
        hintToKitch.SetActive(true);
        yield return new WaitWhile(() => !handClick.telepotrToKitchen);
        player.transform.position = teleportKitchen.transform.position;
        checkBar.GetComponent<MeshRenderer>().material = image6;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("LoadScreen", LoadSceneMode.Single);
    }
    void Update()
    {
        a += 1 * Time.deltaTime;
    }
}
