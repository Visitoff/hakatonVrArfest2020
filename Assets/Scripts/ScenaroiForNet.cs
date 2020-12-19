using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaroiForNet : MonoBehaviour
{
    [SerializeField]
    Transform teleportKitchen;
    [SerializeField]
    Transform teleportTarget;
    [SerializeField]
    Transform teleportToCab;
    [SerializeField]
    Transform cabinet;
    [SerializeField]
    Transform player;
    [SerializeField]
    GameObject playerObject;
    public HandClick handClick;
    int ScenarioMode= 1;

    void Start()
    {
        playerObject.transform.position = teleportTarget.transform.position;
        StartCoroutine(First());
    }
    
    void Update()
    {
        
    }
    IEnumerator First()
    {
        yield return new WaitWhile(() => !handClick.weaponReady);
        playerObject = GameObject.FindGameObjectWithTag("netplayer");
        yield return new WaitWhile(() => !handClick.teleportToCabinet);
        playerObject.transform.position = cabinet.transform.position;
        yield return new WaitWhile(() => !handClick.cabTask);
        yield return new WaitWhile(() => !handClick.teleportBack);
        playerObject.transform.position = teleportTarget.transform.position;
        yield return new WaitWhile(() => !handClick.telepotrToKitchen);
        playerObject.transform.position = teleportKitchen.transform.position;
        yield return new WaitForSeconds (5f);
        Time.timeScale = 0;
    }
    
}
