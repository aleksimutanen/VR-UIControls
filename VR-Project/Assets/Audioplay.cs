using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioplay : MonoBehaviour {

    public string BGM;

	// Use this for initialization
	void Start () {
        Fabric.EventManager.Instance.PostEvent(BGM);
	}
	

}
