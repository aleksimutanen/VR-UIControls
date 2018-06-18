using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    public SteamVR_TrackedController tc;
    Collider col;
    bool grabbableInCol = false;
    Rigidbody grabbed;
    //lever?

    void Start() {
        col = GetComponent<Collider>();
    }

    void Update() {
        if (tc.triggerPressed && grabbableInCol) {
            //jos colliderissa grabbable object ota se käteen
            grabbed.position = transform.position;
            grabbed.rotation = transform.rotation;
        }
    }

    //checkaa onko colliderissa grabbable object
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Grabbable") {
            grabbableInCol = true;
            grabbed = other.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other) {
        grabbableInCol = false;
    }
}
