using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollider : MonoBehaviour {

    public Transform controller;
    Rigidbody rb;


    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        rb.MovePosition(controller.position);
	}
}
