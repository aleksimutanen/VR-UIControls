using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloser : MonoBehaviour {

    public Transform door;
    Vector3 doorOpen;
    Vector3 doorClosed;
    public float openspeed;
    public float closespeed;
    MeshTriggerManager mtm;

    public string closeAudioEvent;

    private void Start() {
        doorOpen = door.position;
        doorClosed = doorOpen + new Vector3(0, 0, 0);
        //endPos = door.position;
        //startPos += door.position + new Vector3(0, 0, -0.6f);
        mtm = FindObjectOfType<MeshTriggerManager>();
    }


    private void OnTriggerStay(Collider other) { 
        if (other.gameObject.tag == "MainCamera") {
            mtm.doorTriggerActive = false;
            print("jee");
            if (door.position != doorClosed) {
                door.transform.position = Vector3.MoveTowards(door.position, doorClosed, Time.deltaTime * openspeed);
                Fabric.EventManager.Instance.PostEvent(closeAudioEvent);
            }
            if (door.name == ("Door2")) {
                door.transform.position = Vector3.MoveTowards(door.position, doorClosed, Time.deltaTime * openspeed);
                Fabric.EventManager.Instance.PostEvent(closeAudioEvent);

            }
        }
    }
}
