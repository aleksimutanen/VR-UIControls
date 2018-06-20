using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnabler : MonoBehaviour {

    public bool trigger;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "MainCamera") {
            trigger = true;
        }
    }
    //private void OnTriggerExit(Collider other) {
    //    trigger.SetActive(false);
    //}
}
