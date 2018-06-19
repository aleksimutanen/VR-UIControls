using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrigger : MonoBehaviour {

    MeshTriggerManager mtm;
    public string target;
    public Light spotLight;
    bool triggerActivated = false;

    void Start() {
        mtm = FindObjectOfType<MeshTriggerManager>();
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == target && triggerActivated == false) {
            spotLight.intensity = 5f;
            spotLight.spotAngle = spotLight.spotAngle * 1.2f;
            triggerActivated = true;
            mtm.TriggerActivated(this);
        } else if (other.gameObject.tag == "Grabbable" && other.gameObject.name != target) {
            //print("fail");
            //playsound or something
        }
    }
    //void OnTriggerEnter(Collider other) {
    //    if (other.gameObject == targetMesh) {
    //        print("xd");
    //        spotLight.intensity = 10f;
    //}
}

