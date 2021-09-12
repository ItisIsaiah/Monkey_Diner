using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateInteraction : MonoBehaviour
{
    public string theObject;
    public Transform spawnPoint;
    ObjectPooler objectPooler;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
       
    }
    public void SpawntheObject()
    {
       objectPooler.SpawnedFromQueue(theObject,spawnPoint.position,Quaternion.identity);
    }
    private void Update()
    {
       // SpawntheObject();
    }
}
