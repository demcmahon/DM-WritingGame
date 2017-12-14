using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK_LaserMove : MonoBehaviour {

    public float fl_speed;
    public GameObject mGO_Ship;
    public Vector3 V3_ShipPos;
    
    // Use this for initialization
	void Start () {

        mGO_Ship = GameObject.FindGameObjectWithTag("ShipAll");
        V3_ShipPos = mGO_Ship.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        float step = fl_speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,V3_ShipPos, step);

    }
}
