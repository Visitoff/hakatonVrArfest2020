
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TouchpadMovement : MonoBehaviour
{

    [SerializeField]
    Transform cam;
    [SerializeField]
    CharacterController controller;
    Vector2 mov;
    bool timeToMove;
        public SteamVR_Action_Boolean trackPadTouch = SteamVR_Actions.default_toucgaptouch;
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
        if (timeToMove && trackPadTouch.GetState(SteamVR_Input_Sources.RightHand))
        {
            
            Vector2 mov = SteamVR_Input.GetVector2("touchpadposition", SteamVR_Input_Sources.RightHand);
            Debug.LogFormat("Touch position = {0}", mov);
            float movX = mov.x * Time.deltaTime;
            float movY = mov.y * Time.deltaTime;
            Vector3 playerMovement = transform.right * movX + cam.transform.forward * movY;
            playerMovement += Physics.gravity;
            playerMovement = playerMovement * 5f;
            controller.Move(playerMovement);

        }
    }
    IEnumerator enumerator()
    {
      yield return new WaitForSeconds(5f);
      timeToMove = true;
     }
}