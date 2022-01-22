using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocoController : MonoBehaviour
{
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public XRRayInteractor leftInteractorRay;
    public XRRayInteractor rightRayinteractor;

    
    public bool EnableLeftTeleport { get; set; } = false;
    public bool EnableRightTeleport { get; set; } = false;

    // Update is called once per frame
    void Update()
    {
       
        if (rightTeleportRay  )
        {
            rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay));
        }
        if (leftTeleportRay  )
        {
          
            leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isAxtivated, activationThreshold);

       // Debug.Log(isAxtivated);
        return isAxtivated;
        
    }
}
