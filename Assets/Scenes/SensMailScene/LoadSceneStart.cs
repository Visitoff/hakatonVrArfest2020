using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneStart : MonoBehaviour
{
    float a = 0f;
  public  void StartScene()
    {

        SceneManager.LoadScene("LoadScreen", LoadSceneMode.Single);
    }
    private void Update()
    {
        a += Time.deltaTime;
    }
}
