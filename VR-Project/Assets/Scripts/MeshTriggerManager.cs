using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTriggerManager : MonoBehaviour {

    bool triggersActivated = false;
    public List<MeshTrigger> triggerList = new List<MeshTrigger>();
    public DoorOpener dooropener;

	void Start () {
		
	}

    void Update() {
        //tähän joku timeri
        if (triggersActivated) {
            dooropener.OpenDoor();
        }    
    }

    public void TriggerActivated(MeshTrigger trigger) {
        triggerList.Add(trigger);
        print("trigger added");
        if (triggerList.Count == 3) {
            print("xd");
            triggersActivated = true;
            //dosomething
        }
    }
}
