using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTriggerManager : MonoBehaviour {

    public List<MeshTrigger> triggerList = new List<MeshTrigger>();

	void Start () {
		
	}

    public void TriggerActivated(MeshTrigger trigger) {
        triggerList.Add(trigger);
        print("trigger added");
        if (triggerList.Count == 3) {
            print("xd");
            //dosomething
        }
    }
}
