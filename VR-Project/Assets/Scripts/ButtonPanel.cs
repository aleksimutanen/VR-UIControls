using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanel : MonoBehaviour {

    public Transform spawnLocation;
    public GameObject spawnObject;
    public GameObject[] buttons;
    Renderer rend;
    List<int> appliedNumbers = new List<int>();
    public Light light;

    void Start() {
        rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other) {
        //if (other.gameObject.tag == "Button") {
        //    var b = Instantiate(spawnObject);
        //    b.transform.position = spawnLocation.position;
        //}
        for (int i = 0; i < buttons.Length; i++) {
            if (other.gameObject == buttons[i]) {
                buttons[i].GetComponent<Renderer>().material.color = Color.blue;
                print("button " + buttons[i] + " hit");
                appliedNumbers.Add(i + 1);
                print("number " + (i + 1) + "added");
            }
        }
        if (appliedNumbers.Contains(1)) {
            if (appliedNumbers.Contains(3)) {
                if (appliedNumbers.Contains(4)) {
                    if (appliedNumbers.Contains(7)) {
                        light.intensity = 25f;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        for (int i = 0; i < buttons.Length; i++) {
            if (other.gameObject == buttons[i]) {
                buttons[i].GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}