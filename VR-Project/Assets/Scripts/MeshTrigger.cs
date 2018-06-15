using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrigger : MonoBehaviour {

    public string target;
    public Light spotLight;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == target) {
            print("xd");
            spotLight.intensity = 5f;
            spotLight.spotAngle = spotLight.spotAngle * 2;
        }
    }
    //void OnTriggerEnter(Collider other) {
    //    if (other.gameObject == targetMesh) {
    //        print("xd");
    //        spotLight.intensity = 10f;
    //}
}

