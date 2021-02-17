using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TeleportControl : MonoBehaviour
{
    public VRTeleporter teleporter;
    public SteamVR_Action_Boolean trackPad = SteamVR_Actions.default_Teleport;
    void Start()
    {
        
    }

    void Update()
    {
        if (SteamVR_Input.GetStateDown("SnapTurnLeft", SteamVR_Input_Sources.RightHand))
        {
            Debug.Log("snapturnleft");
            SteamVR_Fade.Start(Color.black, 0);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 45, transform.localEulerAngles.z);
            SteamVR_Fade.Start(Color.clear, 1);
        }
        if (SteamVR_Input.GetStateDown("SnapTurnRight", SteamVR_Input_Sources.RightHand))
        {
            Debug.Log("snapturnleft");
            SteamVR_Fade.Start(Color.black, 0);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 45, transform.localEulerAngles.z);
            SteamVR_Fade.Start(Color.clear, 1);
        }
        if (trackPad.GetStateUp(SteamVR_Input_Sources.Any))
        {
            SteamVR_Fade.Start(Color.black, 0);
            teleporter.Teleport();  
            teleporter.ToggleDisplay(false);
            SteamVR_Fade.Start(Color.clear, 1);
        }
        if (trackPad.GetStateDown(SteamVR_Input_Sources.Any))
        {
            teleporter.ToggleDisplay(true);
        }
    }
}
