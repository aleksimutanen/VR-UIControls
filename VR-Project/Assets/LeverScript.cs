using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverScript : MonoBehaviour {

    public Transform hand;
    public float angle;
    public Transform neutral;
    public float maxAngle;
    public UnityEvent switchOn;
    public UnityEvent switchOff;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var pointInPivotCoords = transform.InverseTransformPoint(hand.position);
        var pointOnPlane = pointInPivotCoords; pointOnPlane.z = 0;
        var pointInWorld = transform.TransformPoint(pointOnPlane);
        var newRot = Quaternion.LookRotation(transform.forward, pointInWorld - transform.position);
        var newUp = newRot * Vector3.up;
        var newAngle = Vector3.Angle(newUp, neutral.up);
        if (newAngle > maxAngle)
            return;
        transform.rotation = newRot;
        angle = Vector3.Angle(transform.up, neutral.up);
        var dir = neutral.InverseTransformDirection(transform.up);
        if (dir.x <= 0) {
            angle *= -1;
        }

        if (angle >= 30) {
            print("jes");
            switchOn.Invoke();
        } else if (angle <= -30) {
            print("jos");
            switchOff.Invoke(); }
        // did we just move to activation zone?
        // if ...
        // switchOn.Invoke();
        // switchOff.Invoke();


    }
}
