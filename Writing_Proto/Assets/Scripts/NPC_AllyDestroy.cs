using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AllyDestroy : MonoBehaviour {

    // Variables
    //public GameObject Laser;
    public GameObject NPC_Ally;
    public GameObject GO_Particles;

	// Use this for initialization
	void Start () {
        NPC_Ally = GameObject.FindGameObjectWithTag("ShipAll");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Laser)
        {
            DestroyObject(Laser);
            DestroyObject(NPC_Ally);
        }
    }*/

    private void OnTriggerEnter(Collider cl_trigger)
    {
        if (cl_trigger.gameObject == NPC_Ally)
        {
            DestroyObject(gameObject);
            DestroyObject(NPC_Ally);
            GO_Particles.SetActive(true);
            
        }
    }
}
