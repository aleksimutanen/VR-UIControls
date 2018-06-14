using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    //private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int) )} }
    private SteamVR_TrackedObject trackedObj;
	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
