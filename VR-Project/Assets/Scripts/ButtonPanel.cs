using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanel : MonoBehaviour {

    public Transform spawnLocation;
    public GameObject spawnObject;
    public GameObject[] buttons;
    public Color[] buttonColors;
    public int[] codeNumbers;

    Renderer rend;
    List<int> appliedNumbers = new List<int>();

    public Light light;

    void Start() {
        //rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Reset") {
            other.GetComponent<Renderer>().material.color = Color.black;
            appliedNumbers.Clear();
            print("numbers reset");
        } else {
            for (int i = 0; i < buttons.Length; i++) {
                if (other.gameObject == buttons[i]) {
                    buttons[i].GetComponent<Renderer>().material.color = buttonColors[1];
                    print("button " + buttons[i] + " hit");
                    appliedNumbers.Add(i + 1);
                    print("number " + (i + 1) + " added");
                }
            }
            if (appliedNumbers.Contains(codeNumbers[0]) && appliedNumbers.Contains(codeNumbers[1])
                && appliedNumbers.Contains(codeNumbers[2]) && appliedNumbers.Contains(codeNumbers[3])) {
                light.intensity = 25f;
            }
        }
        if (other.gameObject.name == "MeshSpawnButton") {
            print("xd");
            var b = Instantiate(spawnObject);
            b.transform.position = spawnLocation.position;
        }
    }

    private void OnTriggerExit(Collider other) {
        for (int i = 0; i < buttons.Length; i++) {
            if (other.gameObject == buttons[i]) {
                buttons[i].GetComponent<Renderer>().material.color = buttonColors[0];
            }
        }
        if(other.gameObject.name == "Reset") {
            other.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}