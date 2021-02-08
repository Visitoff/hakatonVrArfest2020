
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TouchpadMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;
    Vector2 mov;
    bool timeToMove;
    private void Start()
    {
           StartCoroutine(enumerator());
    }
    private void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (timeToMove)
        {
             mov = SteamVR_Input.GetVector2("touchpadtouch", SteamVR_Input_Sources.RightHand);
               controller.Move(mov * 10f);
        }
    }
    IEnumerator enumerator()
    {
      yield return new WaitForSeconds(10f);
      timeToMove = true;
     }
}