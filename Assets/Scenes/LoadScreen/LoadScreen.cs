using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScreen : MonoBehaviour
{
    public int ScenarioMode = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))//критические ошибки
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.W))//обучение
        {
            ScenarioMode = 2;

            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.E))//эвакуация 
        {
            ScenarioMode = 3;

            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
