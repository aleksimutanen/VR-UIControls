using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRizza : MonoBehaviour {

    bool pt2Done;
    public GameObject snapPoint;
    public GameObject snapPoint2;

	void Update () {
        //if(!pt2Done)
           //transform.parent.transform.position += Time.deltaTime * Vector3.forward * 0.1f;
		//TODO: haamuobjektit??
	}

    private void OnCollisionEnter(Collision collision) {
        print("collision detected " + collision.gameObject);
        if (!pt2Done && collision.transform.name == "Rizza pt 2") {
            print("rizzas touching " + collision.gameObject);
            collision.transform.parent = transform.parent;
            collision.transform.rotation = transform.rotation;
            collision.transform.position = snapPoint.transform.position; //
            collision.gameObject.tag = "Untagged";
            pt2Done = true;
        }
        if (collision.gameObject.name == "Rizza pt 3" && pt2Done) {
            print("kolmas osa");
            collision.transform.parent = transform.parent;
            collision.transform.rotation = transform.rotation;
            collision.transform.rotation = Quaternion.Euler(-80, 0, 0);
            collision.transform.position = snapPoint2.transform.position;
            collision.gameObject.tag = "Untagged";
        }

    }
}
