using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalWall : MonoBehaviour {

    public string catAudioEvent;
    public string dogAudioEvent;
    public string frogAudioEvent;
    public string roosterAudioEvent;
    public string lionAudioEvent;
    public string pigAudioEvent;
    public string wolfAudioEvent;
    public string sheepAudioEvent;
    public string cowAudioEvent;


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Cat") {
            Fabric.EventManager.Instance.PostEvent(catAudioEvent);
        } else if (other.gameObject.tag == "Dog") {
            Fabric.EventManager.Instance.PostEvent(dogAudioEvent);
        } else if (other.gameObject.tag == "Frog") {
            Fabric.EventManager.Instance.PostEvent(frogAudioEvent);
        } else if (other.gameObject.tag == "Rooster") {
            Fabric.EventManager.Instance.PostEvent(roosterAudioEvent);
        } else if (other.gameObject.tag == "Lion") {
            Fabric.EventManager.Instance.PostEvent(lionAudioEvent);
        } else if (other.gameObject.tag == "Pig") {
            Fabric.EventManager.Instance.PostEvent(pigAudioEvent);
        } else if (other.gameObject.tag == "Wolf") {
            Fabric.EventManager.Instance.PostEvent(wolfAudioEvent);
        } else if (other.gameObject.tag == "Sheep") {
            Fabric.EventManager.Instance.PostEvent(sheepAudioEvent);
        } else if (other.gameObject.tag == "Cow") {
            Fabric.EventManager.Instance.PostEvent(cowAudioEvent);
        }
    }
}
