using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK_Play_Click : MonoBehaviour
{

    public GameObject Idle;
    public AudioSource ThisOne;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PointScreen();
    }


    // Raycast when click to display objects.
    void PointScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.gameObject.layer == 8)
                {
                    print("Hit something!");

                    //ThisOne.Play();

                    Idle.SetActive(true);
                    Destroy(gameObject);

                }

            }

        }

    }

}
