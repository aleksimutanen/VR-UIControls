using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

    public Transform door;
    Vector3 startPos;
    Vector3 endPos;
    public float openspeed;
    public float closespeed;
    public RoomChanger rc;
    MeshTriggerManager mtm;
    float distanceThreshold;

    public string doorAudioEvent;

    private void Start() {
        startPos = door.position;
        endPos += door.position + new Vector3(0, 0, 1.2f);
        mtm = FindObjectOfType<MeshTriggerManager>();
    }


    public void OnTriggerStay(Collider other) {
        if (door.position != endPos) {
            door.transform.position = Vector3.MoveTowards(door.position, endPos, Time.deltaTime * openspeed);
            rc.eventDone = true;
            Fabric.EventManager.Instance.PostEvent(doorAudioEvent);
        }

    }
    public void OpenDoor() {
        if (mtm.doorTriggerActive) {
            if (door.position != endPos) {
                door.transform.position = Vector3.MoveTowards(door.position, endPos, Time.deltaTime * openspeed);
                rc.eventDone = true;
                Fabric.EventManager.Instance.PostEvent(doorAudioEvent);
            }
            //if (door.position == endPos) {
            //    if (Vector3.Distance(door.position, endPos) < distanceThreshold) {

            //        mtm.doorTriggerActive = false;

            //    }
            }
    }
}
