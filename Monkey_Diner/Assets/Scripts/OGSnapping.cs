using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OGSnapping : MonoBehaviour
{
    Transform snapPoint;
    bool isSnapping;
    public Collider snapCollider;
    //public Collider physicsCollider;
    public ArrayList snapped=new ArrayList();
    Rigidbody rb;
    Rigidbody otherRb;
    GameObject parentG;
    // Start is called before the first frame update
    public void Start()
    {
        isSnapping = false;
        
        rb = GetComponent<Rigidbody>();
        if (snapCollider == null)
        {
            Debug.LogError(name+" DOES NOT HAVE A SNAP COLLIDER");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (parentG) {
           
            OGSnapping pSnap = parentG.GetComponent<OGSnapping>();
            if (snapped != null)
            {
                pSnap.snapped.Add(snapped);
                snapped = new ArrayList();

            }
            Debug.Log("Locking to"+parentG.name);
            transform.position = new Vector3(parentG.transform.position.x, parentG.transform.position.y + .05f, parentG.transform.position.z);
        }
        
       
    }

     public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Food") && other.name!=this.name && other.name!="bottbun" && !parentG)
        {

            GameObject food = other.gameObject;
            food.transform.position = new Vector3(transform.position.x,transform.position.y+.05f,transform.position.z);
            other.transform.parent = gameObject.transform;
            OGSnapping kiddo = food.GetComponent<OGSnapping>();
            kiddo.parentG = this.gameObject;
            Debug.Log(other.name+"is now my child");
            XRGrabInteractable grab= food.GetComponent<XRGrabInteractable>();

            grab.enabled = false;
            other.tag = "Snapped";

            otherRb = food.GetComponent<Rigidbody>();
           // otherRb.freezeRotation=true;
            otherRb.constraints= RigidbodyConstraints.FreezePosition;
            otherRb.constraints = RigidbodyConstraints.FreezeRotation;

            
            //Collider fD=food.GetComponent<Collider>();
           // fD.enabled = false;
            snapped.Add(food.name);     
        }
        

    }
    public void Snap(Transform snap)
    {
        isSnapping = true;
        snapPoint = snap;
        Destroy(snapCollider);
        rb.freezeRotation = true;
    }
}
