using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Scenario : MonoBehaviour
{
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
    public LoadScreen ld;

    //Извиняюсь перед всеми программистами кто это читает:)
    void Start()
    {
        player.transform.position = teleportTarget.transform.position;
        StartCoroutine(First());
    }

    void FixedUpdate()
    {
        if (ld.ScenarioMode == 1)
        {
            hint1.SetActive(false);
            hint2.SetActive(false);
            hint3.SetActive(false);
        }
        if (ld.ScenarioMode == 3)
        {
            handClick.weaponReady = true;
            handClick.teleportToCabinet = true;
            handClick.cabTask = true;
        }
        if (Input.GetKeyDown(KeyCode.W))//обучение
        {
            ld.ScenarioMode = 2;

        }
        if (Input.GetKeyDown(KeyCode.E))//эвакуация 
        {
            ld.ScenarioMode = 3;

        }
        if (ld.ScenarioMode == 2 && handClick.error)
        {
            a += Time.deltaTime;
            checkBar.GetComponent<MeshRenderer>().material = imageError;
            if (a > 3f)
            {
                handClick.error = false;

            }
        }
        if (ld.ScenarioMode == 1 && handClick.error)
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
        player.transform.position = teleportTarget.transform.position;
        yield return new WaitWhile(() => !handClick.telepotrToKitchen);
        player.transform.position = teleportKitchen.transform.position;
        checkBar.GetComponent<MeshRenderer>().material = image6;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("LoadScreen", LoadSceneMode.Single);
    }
}
