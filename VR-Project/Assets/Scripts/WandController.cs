using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    public SteamVR_TrackedController tc;
    Collider col;
    bool grabbableInCol = false;
    Rigidbody grabbed;
	bool snapped;
    LeverScript ls;
    bool handleInCol = false;
    Transform prevParent;
    //lever?

    void Start() {
        col = GetComponent<Collider>();
    }

    void Update() {
        if (tc.triggerPressed) {
            if(handleInCol)
            {
                ls.yesUse = true;
            }
            //jos colliderissa grabbable object ota se käteen
			if (grabbableInCol && !snapped) {
				grabbed.position = transform.position;
				snapped = true;
				grabbed.useGravity = false;
				grabbed.isKinematic = true;
				grabbed.velocity = new Vector3(0,0,0);
                prevParent = grabbed.gameObject.transform.parent;
                grabbed.gameObject.transform.parent = gameObject.transform;
			}

            
            //grabbed.rotation = transform.rotation;
		} else {
			//print ("trigger not pressed");

            if(handleInCol)
            {
                ls.yesUse = false;
            }

			if(grabbed && snapped) {
				grabbed.gameObject.transform.parent = prevParent;
				grabbed.useGravity = true;
				grabbed.isKinematic = false;
				grabbed = null;
				snapped = false;
			} 
		} 
		
    }

    //checkaa onko colliderissa grabbable object
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Handle")
        {
            ls = other.gameObject.GetComponentInParent<LeverScript>();
            handleInCol = true;
            print("handle detected");
        }

        if (other.gameObject.tag == "Grabbable") {
            grabbableInCol = true;
            grabbed = other.GetComponent<Rigidbody>();
        }

        //TODO: rizzalle omat hommat other.gameObject.tag == "Rizza"
    }

    private void OnTriggerExit(Collider other) {
        grabbableInCol = false;
        if (other.gameObject.tag == "Handle")
        {
            ls = other.gameObject.GetComponentInParent<LeverScript>();
            ls.yesUse = false;
            handleInCol = false;
        }
    }

    //heitto: edellinen paikka - nmykyinen paikka -> vauhtivektoriksi
}
