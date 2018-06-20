using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFromPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var p = transform.position * 0.5f;
        //print(p.x);
       // GetComponent<Renderer>().material.color = new Color(p.x, p.y, p.z);
         GetComponent<Renderer>().material.color = new Color(p.x, p.y, p.z) - Color.gray/2;
    }
}
