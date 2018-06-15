using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

    public Transform door;
    Vector3 startPos;
    Vector3 endPos;
    public float openspeed;
    public float closespeed;

    private void Start() {
        startPos = door.position;
        endPos += door.position + new Vector3(0, 0, 1.2f);
    }


    private void OnTriggerStay(Collider other) {
        if (door.position != endPos) {
            door.transform.position = Vector3.MoveTowards(door.position, endPos, Time.deltaTime * openspeed);
        }

    }
}
