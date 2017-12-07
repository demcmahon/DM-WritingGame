using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAllyMove : MonoBehaviour {
    public Transform target;
    public Transform LaserStart;
    public float speed;
    public GameObject EnemyShip;
    public GameObject Laser;
    private bool bl_destination;

    public GameObject mGO_AllyShip;

    private void Start()
    {

    }

    void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    /*private void OnTriggerEnter (Collider _collision)
    {

        if(_collision.gameObject.tag == "waypoint")
        {
            Instantiate(Laser, EnemyShip.transform.position, EnemyShip.transform.rotation);
            print("I Work!");
        }
    }*/

    private void OnTriggerEnter(Collider cl_trigger)
    {
        if (cl_trigger.gameObject == mGO_AllyShip)
        {
            Instantiate(Laser, LaserStart.transform.position, target.transform.rotation);


        }
    }
}
