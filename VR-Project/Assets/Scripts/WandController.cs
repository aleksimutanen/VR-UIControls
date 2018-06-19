using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    public SteamVR_TrackedController tc;
    Collider col;
    bool grabbableInCol = false;
    Rigidbody grabbed;
	bool snapped;
    //lever?

    void Start() {
        col = GetComponent<Collider>();
    }

    void Update() {
        if (tc.triggerPressed && grabbableInCol) {
            //jos colliderissa grabbable object ota se käteen
			if (!snapped) {
				grabbed.position = transform.position;
				snapped = true;
				grabbed.useGravity = false;
				grabbed.isKinematic = true;
				grabbed.velocity = new Vector3(0,0,0);
				grabbed.gameObject.transform.parent = gameObject.transform;
			}

            
            //grabbed.rotation = transform.rotation;
		} else if (!tc.triggerPressed)  {
			//print ("trigger not pressed");

			if(grabbed && snapped) {
				grabbed.gameObject.transform.parent = null;
				grabbed.useGravity = true;
				grabbed.isKinematic = false;
				grabbed = null;
				snapped = false;
			} 
		}
		
    }

    //checkaa onko colliderissa grabbable object
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Grabbable") {
            grabbableInCol = true;
            grabbed = other.GetComponent<Rigidbody>();
        }

        //TODO: rizzalle omat hommat other.gameObject.tag == "Rizza"
    }

    private void OnTriggerExit(Collider other) {
        grabbableInCol = false;

    }
}
