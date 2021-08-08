using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HandPressance : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private Animator   handAnimator;
    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandObject;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        showController = false;
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab && showController)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            

            else if(!prefab && showController)
            {
                Debug.LogError("Did not find controller Model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
            
        }
        spawnedHandObject = Instantiate(handModelPrefab, transform);
        handAnimator = spawnedHandObject.GetComponent<Animator>();


    }
    void UpdateHandAnim()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger,out float triggerValue))
        {
           
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger",0);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
          
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (showController)
        {
            spawnedHandObject.SetActive(false);
            spawnedController.SetActive(true);
        }
        //else if(!showController)
       // {
          //  spawnedController.SetActive(false);
         //   spawnedHandObject.SetActive(true);
            
       // }
        UpdateHandAnim();
    }
}
