using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSpawnPanel : MonoBehaviour {

    public Transform spawnLocation;
    public GameObject[] spawnObject;

    void Start() {


    }

    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "MeshSpawnButton") {
            var b = Instantiate(spawnObject[Random.Range(0, 9)]);
            b.transform.position = spawnLocation.position + new Vector3(Random.Range(0f, 0.5f), 0, Random.Range(0f, 0.5f));
            other.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "MeshSpawnButton") {
            other.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
