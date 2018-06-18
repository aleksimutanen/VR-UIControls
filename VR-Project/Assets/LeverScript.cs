using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour {

    public Transform hand;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var pointInPivotCoords = transform.InverseTransformPoint(hand.position);
        var pointOnPlane = pointInPivotCoords; pointOnPlane.z = 0;
        var pointInWorld = transform.TransformPoint(pointOnPlane);
        transform.rotation = Quaternion.LookRotation(transform.forward, pointInWorld - transform.position);
	}
}
