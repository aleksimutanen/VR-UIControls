using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour {

    public Transform spawnLocation;
    public GameObject spawnObject;

	void Start () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Cube") {
            var b = Instantiate(spawnObject);
            b.transform.position = spawnLocation.position;
        }
    }
}
