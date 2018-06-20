using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTrigger : MonoBehaviour {
    public List<int> rightCode = new List<int>();
    List<int> appliedCode = new List<int>();

    public int codeLength;
    int correctApplied;

    public GameObject[] animalSprites;
    public GameObject[] buttons;
    public AudioSource[] animalAudio;

    public string buttonAudioEvent;
    public string successAudioEvent;

    DoorOpener dop;
    MeshTriggerManager mtm;
    //public Text testing;
    //public Text testing2;
    //public float[] playInterval;
    //public float[] lastPlayed;

    public float playInterval = 1f;

    void Start () {
        if (codeLength > animalAudio.Length) {
            Debug.LogError("code too long, not enough unique animals");
            return;
        }
        //testing.text = " ";
        for (int i = 0; i < codeLength; i++) {
            var rnd = Random.Range(0, animalAudio.Length);
            while (rightCode.Contains(rnd)) {
                rnd = Random.Range(0, animalAudio.Length);
            }
            rightCode.Add(rnd);
            //testing.text += rightCode[i] + " ";
            //PlaySounds();
        }
        for (int i = 0; i < animalSprites.Length; i++)
        {
            animalSprites[i].GetComponent<Renderer>().material.color = Color.black;
        }
        mtm = FindObjectOfType<MeshTriggerManager>();
    }

    void Update()
    {
        if (mtm.doorTriggerActive)
        {
            dop.OpenDoor();
        }    
    }

    void PlaySounds() {
        for (int i = 0; i < rightCode.Count; i++) {
            animalAudio[rightCode[i]].PlayDelayed(playInterval);
            print(rightCode[i]);
            playInterval = playInterval + 3.5f;
        }
        playInterval = 1f;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Reset") {
            other.GetComponent<Renderer>().material.color = Color.black;
            appliedCode.Clear();
            //testing2.text = "";
            Fabric.EventManager.Instance.PostEvent(buttonAudioEvent);
            print("applied sounds reset");
        } else if (other.gameObject.name == "PlayAgain") {
            for (int i = 0; i < animalSprites.Length; i++)
            {
                animalSprites[i].GetComponent<Renderer>().material.color = Color.white;
            }
            Fabric.EventManager.Instance.PostEvent(buttonAudioEvent);

            other.GetComponent<Renderer>().material.color = Color.yellow;
            PlaySounds();
        }
        else if (other.gameObject.tag == "Button") { 
            //buttons.indexOf(other.gameObject)
            for (int i = 0; i < buttons.Length; i++) {
                if (other.gameObject == buttons[i]) {
                    animalAudio[i].Play();
                    buttons[i].GetComponent<Renderer>().material.color = Color.red;
                    print("button " + buttons[i] + " hit");
                    appliedCode.Add(i);
                    //testing2.text += " " + i;
                    print("number " + (i) + " added");
                }
            }
        }
        if (appliedCode.Count == rightCode.Count) {
            foreach (int number in appliedCode) {
                if (rightCode.Contains(number)) {
                    print(number);
                    print("applied number is right");
                    correctApplied++;
                } if (correctApplied == rightCode.Count) {
                    Fabric.EventManager.Instance.PostEvent(successAudioEvent);
                    mtm.doorTriggerActive = true;
                    dop = FindObjectOfType<DoorOpener>();
                    print("jee");
                    //dosomething
                }
            }
        }
        

        //foreach (int f in appliedCode) {
        //    for (int i = 0; i < rightCode.Count; i++) {
        //        if (appliedCode[i] == rightCode[i]) {
        //            appliedCode.Contains()
        //        }
        //    }
        //}

        //if (appliedNumbers.Contains(codeNumbers[0]) && appliedNumbers.Contains(codeNumbers[1])
        //    && appliedNumbers.Contains(codeNumbers[2]) && appliedNumbers.Contains(codeNumbers[3])) {
        //    light.intensity = 25f;
        //}
    }

    void OnTriggerExit(Collider other) {
        for (int i = 0; i < buttons.Length; i++) {
            if (other.gameObject == buttons[i]) {
                buttons[i].GetComponent<Renderer>().material.color = Color.cyan;
            }
        }
        if (other.gameObject.name == "Reset") {
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (other.gameObject.name == "PlayAgain") {
            other.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}

