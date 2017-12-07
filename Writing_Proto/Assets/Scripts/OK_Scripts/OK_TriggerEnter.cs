using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK_TriggerEnter : MonoBehaviour {

    public GameObject mGO_AllyShip;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider cl_trigger)
    {
         if (cl_trigger.gameObject == mGO_AllyShip)
        {
            print("I Work!!");

        }
    }
}
