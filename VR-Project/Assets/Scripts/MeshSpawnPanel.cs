﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSpawnPanel : MonoBehaviour {

    public Transform spawnLocation;
    public GameObject[] spawnObject;
    public int meshSpawn;
    public int maxWrongThreshold;
    int index = 0;
    public Transform folder;
    public string spawnAudioEvent;

    void Start() {

    }

    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        if (meshSpawn < maxWrongThreshold && other.gameObject.name == "MeshSpawnButton") {
            print("spawn random");
            var b = Instantiate(spawnObject[Random.Range(0, 9)]);
            b.transform.parent = folder;
            b.transform.position = spawnLocation.position + new Vector3(Random.Range(0f, 0.5f), 0, Random.Range(0f, 0.5f));
            meshSpawn++;
            other.GetComponent<Renderer>().material.color = Color.red;
            Fabric.EventManager.Instance.PostEvent(spawnAudioEvent);
        } else if (meshSpawn >= maxWrongThreshold && other.gameObject.name == "MeshSpawnButton") {
            print("spawn correct");
            var c = Instantiate(spawnObject[0 + index]);
            c.transform.parent = folder;
            c.transform.position = spawnLocation.position + new Vector3(Random.Range(0f, 0.5f), 0, Random.Range(0f, 0.5f));
            index++;
            if (index == 3) {
                index = 0;
            }
            Fabric.EventManager.Instance.PostEvent(spawnAudioEvent);

        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "MeshSpawnButton") {
            other.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
