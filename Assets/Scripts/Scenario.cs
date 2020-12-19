using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    public Texture screen1;
    public Texture screen2;
    public Texture screen3;
    public Texture screen4;
    public Texture screen5;
    public Texture screen6;
    public Texture screen7;

    public List<GameObject> errorScreens;
    public List<Texture> errorScrMat;
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
    public HandClick handClick;
    public Material image1;
    public Material image2;
    public Material image3;
    public Material image4;
    public Material image5;
    public Material image6;
    public Material imageCrtError;
    public Material imageError;
    public Texture errscreen;
    float a = 0f;
   public LoadScreen ld;
    
    //Извиняюсь перед всеми программистами кто это читает:), 
    void Start()
    {
        player.transform.position = teleportTarget.transform.position;
        StartCoroutine(First());
        if (ld.ScenarioMode == 3)
        {
            handClick.weaponReady = true;
            handClick.teleportToCabinet = true;
            handClick.cabTask = true;

        }
    }

    void FixedUpdate()
    {
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
        // if (ScenarioMode == 3)
        // {
        /*
             screen1 = Material.SetTexture( "Scren4",errscreen);
            screen2 = errscreen;
            screen3 = errscreen;
            screen4 = errscreen;
            screen5 = errscreen;
            screen6 = errscreen;
            screen7 = errscreen;*/
          /*  foreach (GameObject gameobject in errorScreens)
            {
                Material[] mats ;

                mats = gameObject.GetComponent<Renderer>().sharedMaterials;

                mats[0] = errscreen;
                mats[1] = errscreen;
                mats[2] = errscreen;
                mats[3] = errscreen;
                mats[4] = errscreen;
                gameobject.GetComponent<Renderer>().sharedMaterials = mats;

            }*/
            //Извиняюсь перед всеми кто это читает:)

      // }
        if (ld.ScenarioMode == 1 && handClick.error)
        {
            a += Time.deltaTime;
            checkBar.GetComponent<MeshRenderer>().material = imageCrtError;
            if (a > 5f)
            {
                Time.timeScale = 0f;
            }

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
    }
}
