using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancefloorColors : MonoBehaviour {

    Vector3 p;
    public GameObject[] cubes;
    public List<Vector3> oneByOne;
    public List<Vector3> colors;
    int i;
    int phase;

    // Use this for initialization
    void Start () {
        cubes = GameObject.FindGameObjectsWithTag("cube");
        p = transform.position;
        i = 0;
        phase = 0;

        foreach (GameObject cube in cubes) {
            Vector3 objectPosition = cube.transform.position;
            oneByOne.Add(objectPosition);
            //print(oneByOne);
        }
        foreach (Vector3 v in oneByOne) {
            colors.Add(v);
        }
        
        /// 
    }

    public void Update() {
        //print(p.ToString() + oneByOne[i].ToString());
        if (i >= colors.Count && phase == 0) {
            i = 0;
            phase++;
        }
        else if (i >= colors.Count) {
            i = 0;
            phase = 0;
        }
        else if (p == oneByOne[i] && phase == 0) {

            GetComponent<Renderer>().material.color = new Color((5.0f + colors[i].x) * 0.07f, (5.0f + colors[i].x)*0.4f, 0.5f);
            //tämä muuttaa vektorin väriksi
            i++;
        }
        else if (p == oneByOne[i] && phase == 1) {
            GetComponent<Renderer>().material.color = new Color((5.0f + colors[i].x) * 0.6f, 0.5f, (5.0f + colors[i].x)*0.07f);
            //tämä muuttaa vektorin väriksi
            i++;
        }
        else {
            i++;
        }



    }
   
}
