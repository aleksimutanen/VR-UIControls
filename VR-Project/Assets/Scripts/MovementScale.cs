using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScale : MonoBehaviour {
    //kameran edellinen paikka ja kameran uus paikka
    //    ja siirto sama määrä määrä kun kameran muutos
    public Transform hmd;
    Vector3 hmdLastPos;
    public float factor;

	void Start () {
		
	}
	
	void Update () {
        var hmdDelta = hmd.position - hmdLastPos;
        hmdDelta.y = 0f;
        transform.position += hmdDelta * factor;
        hmdLastPos = hmd.position;
	}
}
