using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    public SteamVR_TrackedController tc;
    Collider col;
    bool grabbableInCol = false;
    GameObject grabbed;
    Rigidbody rb;
	bool snapped;
    //lever?

    void Start() {
        col = GetComponent<Collider>();
    }

    void Update() {
        if (tc.triggerPressed && grabbableInCol) {
            //jos colliderissa grabbable object ota se käteen
			if (!snapped) {
				rb.position = transform.position;
				snapped = true;
				rb.useGravity = false;
				rb.isKinematic = true;
				rb.velocity = new Vector3(0,0,0);
				grabbed.transform.parent = transform;
			}

            
            //grabbed.rotation = transform.rotation;
		} else if (!tc.triggerPressed)  {
			//print ("trigger not pressed");

			if(grabbed && snapped) {
				grabbed.transform.parent = null;
				rb.useGravity = true;
				rb.isKinematic = false;
				grabbed = null;
                rb = null;
				snapped = false;
			} 
		}
		
    }

    //checkaa onko colliderissa grabbable object
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Grabbable" || other.gameObject.tag == "Rizza") {
            grabbableInCol = true;
            if (other.gameObject.transform.parent) {
                grabbed = other.transform.parent.gameObject;
            }
            else {
                grabbed = other.gameObject;
            }
            rb = other.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Untagged") {
            grabbableInCol = false;
            grabbed = null;
            rb = null;
            snapped = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        grabbableInCol = false;

    }

    public void Throw(Vector3 dir) {
        if (rb && grabbed.tag == "Grabbable") {
            rb.velocity = dir;
        }
    }
}
