using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioplay : MonoBehaviour {

    public string BGM;
    public string party;
    public string stop;

	// Use this for initialization
	void Start () {
        Fabric.EventManager.Instance.PostEvent(BGM);
	}

    public void StartParty()
    {
        Fabric.EventManager.Instance.PostEvent(stop);
        Fabric.EventManager.Instance.PostEvent(party);
    }
	

}
