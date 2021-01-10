using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuChoice : MonoBehaviour
{
    public int ScenarioMode = 1;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "evacuation")
        {
            ScenarioMode = 3;

            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
        if (other.tag == "practice")
        {
            ScenarioMode = 2;

            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
        if (other.tag == "exam")
        {
         SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
    void Update()
    {
        
    }
}
