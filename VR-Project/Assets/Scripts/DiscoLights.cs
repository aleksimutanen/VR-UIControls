using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLights : MonoBehaviour {

    public List<GameObject> lights;
    public GameObject victory;
    float t = 1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        t -= Time.deltaTime;
        if (t <0)
        {
            Disco();
            t = 0.2f;
        }
	}

    void Disco()
    {
        if (victory.activeSelf)
        {
            lights[(int)Random.Range(0, 5)].SetActive(true);
            lights[(int)Random.Range(0, 5)].SetActive(false);
        }
    }
}
