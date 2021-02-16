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
        if (trackPad.GetStateUp(SteamVR_Input_Sources.Any))
        {
            teleporter.Teleport();
            teleporter.ToggleDisplay(false);
        }
        if (trackPad.GetStateDown(SteamVR_Input_Sources.Any))
        {
            teleporter.ToggleDisplay(true);
        }
    }
}
