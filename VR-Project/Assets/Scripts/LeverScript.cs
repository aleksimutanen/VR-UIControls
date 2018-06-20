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
    public bool yesUse;
    public DoorOpener dooropener;
    public Vector3 dir;
    Vector3 prevHandPos;

    public bool isActivated;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(yesUse) {
            //print("ei tartuttu " + prevHandPos);
            var pointInPivotCoords = transform.InverseTransformPoint(prevHandPos);
            if ( hand) {
                pointInPivotCoords = transform.InverseTransformPoint(hand.position);
                prevHandPos = hand.position;
                print("käsi käytössä " + prevHandPos);
            }
            var pointOnPlane = pointInPivotCoords; pointOnPlane.z = 0;
            var pointInWorld = transform.TransformPoint(pointOnPlane);
            var newRot = Quaternion.LookRotation(transform.forward, pointInWorld - transform.position);
            var newUp = newRot * Vector3.up;
            var newAngle = Vector3.Angle(newUp, neutral.up);
            if (newAngle > maxAngle)
                return;
            transform.rotation = newRot;
            angle = Vector3.Angle(transform.up, neutral.up);
            dir = neutral.InverseTransformDirection(transform.up);
            if (dir.x <= 0)
            {
                angle *= -1;
            }

            if (angle >= 30 && isActivated)
            {
                isActivated = false;
                print("jes");
                switchOff.Invoke();

            }
            else if (angle <= -30 && !isActivated)
            {
                isActivated = true;
                print("jos");
                switchOn.Invoke();

            }
            if(isActivated)
            {
                //print("vipu aktivoitu ja ovi aukeaa");
                dooropener.OpenDoor();
            }
        }
        
        // did we just move to activation zone?
        // if ...
        // switchOn.Invoke();
        // switchOff.Invoke();


    }
}
