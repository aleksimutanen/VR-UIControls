using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    public SteamVR_TrackedController tc;
    Collider col;
    bool grabbableInCol = false;
    //lever?

    void Start() {
        col = GetComponent<Collider>();
    }

    void Update() {
        if (tc.triggerPressed && grabbableInCol) {
            //jos colliderissa grabbable object ota se käteen

        }
    }

    //checkaa onko colliderissa grabbable object
    private void OnTriggerEnter(Collider other) {
        grabbableInCol = true;
    }
}
