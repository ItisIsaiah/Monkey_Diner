using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class ContinuosMovement : MonoBehaviour
{
    XROrigin origin;
    public XRNode input;
    public float gravity = -9.81f;
    Vector2 inputAxis;
    public float speed=5f;
    float fallSpeed;
    private CharacterController character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        origin = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(input);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }
    private void FixedUpdate()
    {
        Quaternion headYaw = Quaternion.Euler(0, origin.Camera.transform.eulerAngles.y, 0);
        Vector3 dir = headYaw *new Vector3(inputAxis.x,0,inputAxis.y);
        character.Move(dir*Time.deltaTime);

        fallSpeed = -10;
        character.Move(Vector3.up * fallSpeed * Time.fixedDeltaTime);
    }
}
