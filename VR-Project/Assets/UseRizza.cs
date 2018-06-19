using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRizza : MonoBehaviour {

    public SteamVR_TrackedController tc;
    bool inUse;
    WandController wc;

    void Update () {
		if (inUse && !tc.triggerPressed) {
            //heitä asia
            wc.Throw(transform.position + transform.forward);
            print(transform.position + transform.forward);
            inUse = false;
        }
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<SteamVR_TrackedController>()) {
            tc = other.gameObject.GetComponent<SteamVR_TrackedController>();
            wc = tc.gameObject.GetComponent<WandController>();
            if (tc.triggerPressed && !inUse) {
                gameObject.transform.rotation = Quaternion.Euler(80, 0, 0);
                inUse = true;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        inUse = false;
    }
}
