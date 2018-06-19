using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {

    public List<int> rightCode = new List<int>();
    List<int> appliedCode = new List<int>();
    public int codeLenght;
    public GameObject[] buttons;
    public AudioClip[] animalAudio;

	void Start () {
        for (int i = 0; i < codeLenght; i++) {
            rightCode.Add(Random.Range(0, buttons.Length + 1));
        }
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Reset") {
            other.GetComponent<Renderer>().material.color = Color.black;
            appliedCode.Clear();
            print("applied sounds reset");
        } else {
            for (int i = 0; i < buttons.Length; i++) {
                if (other.gameObject == buttons[i]) {
                    //animalAudio[i].
                    //animalAudio[0].
                    //buttons[i].GetComponent<Renderer>().material.color = buttonColors[1];
                    print("button " + buttons[i] + " hit");
                    appliedCode.Add(i + 1);
                    print("number " + (i + 1) + " added");
                }
            }
            //if (appliedNumbers.Contains(codeNumbers[0]) && appliedNumbers.Contains(codeNumbers[1])
            //    && appliedNumbers.Contains(codeNumbers[2]) && appliedNumbers.Contains(codeNumbers[3])) {
            //    light.intensity = 25f;
            //}
        }
}
}
