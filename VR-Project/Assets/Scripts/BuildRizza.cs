using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRizza : MonoBehaviour {

    bool pt2Done;
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        print("collision detected " + collision.gameObject);
        if (collision.gameObject.name == "Rizza pt 2") {
            print("rizzas touching " + collision.gameObject);
            collision.gameObject.transform.parent = gameObject.transform;
            collision.gameObject.transform.localScale = new Vector3()
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.MovePosition(transform.position);
            
            pt2Done = true;
        }
        if (collision.gameObject.name == "Rizza pt 3" && pt2Done) {
            print("kolmas osa");
            collision.gameObject.transform.parent = gameObject.transform;
        }

    }
}
