﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanger : MonoBehaviour {

    public List<GameObject> roomActivity;
    int i;
    public bool eventDone;
    public TriggerEnabler t1;
    public Transform door2;
    public Vector3 startPos;
    public Vector3 endPos;
    public float openspeed;
    public float closespeed;
    public string openAudioEvent;
    public Audioplay ap;

    private void Start() {
        t1 = FindObjectOfType<TriggerEnabler>();
        startPos = door2.position;
        endPos += door2.position + new Vector3(1.2f, 0, 0);
        i = 1;
    }

    private void OnTriggerEnter(Collider other) {
        Fabric.EventManager.Instance.PostEvent(openAudioEvent);
        if (eventDone == true && t1.trigger == true && other.gameObject.tag == ("MainCamera")) {
            if (i > 0) {
                    roomActivity[i - 1].SetActive(false);
                }
                if (i < roomActivity.Count) {
                    roomActivity[i].SetActive(true);
                    if (i == roomActivity.Count - 1) {
                        ap.StartParty();
                    }
                    i++;
                    eventDone = false;
                }

                
        }
    }
    //Opens door2

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == ("MainCamera")) {
            if (door2.position != endPos) {
                door2.transform.position = Vector3.MoveTowards(door2.position, endPos, Time.deltaTime * openspeed);
            }
        }
    }
}
