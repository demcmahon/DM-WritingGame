using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OK_CameraMove : MonoBehaviour
{

    public float turnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis

    private Vector3 mouseOrigin;    // Position of cursor when mouse dragging starts

    private bool isRotating;    // Is the camera being rotated?

    public float torsoRotation;

    private Vector2 V2_Mouselook;
    private Vector2 V2_SmoothV;

    public float fl_Sensitive;
    public float fl_Smooth;

    public GameObject mGO_PlayerCharacter;

    public bool bl_YClamp;
    public bool bl_XClamp;

    public bool bl_Stationary;

    //
    // UPDATE
    //

    /*void Update()
    {
        // Get the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }


        // Disable movements on button release
        if (!Input.GetMouseButton(0)) isRotating = false;


        // Rotate camera along X and Y axis
        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);


            transform.Rotate(0, 0, -torsoRotation, Space.Self);
            //transform.eulerAngles.y = Mathf.Clamp(transform.eulerAngles.y, -20, 20);

          


        }



    }*/

    void Start()
    {
        mGO_PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
    
;    }

    // Update is called once per frame
    void Update()
    {
        Station();

        if (bl_Stationary == false)
        {
            CamLook();
        }

    }

    void CamLook()
    {

        Vector2 V2_MousePos = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        V2_MousePos = Vector2.Scale(V2_MousePos, new Vector2(fl_Sensitive * fl_Smooth, fl_Sensitive * fl_Smooth));
        V2_SmoothV.x = Mathf.Lerp(V2_SmoothV.x, V2_MousePos.x, 1f / fl_Smooth);
        V2_SmoothV.y = Mathf.Lerp(V2_SmoothV.y, V2_MousePos.y, 1f / fl_Smooth);
        V2_Mouselook += V2_SmoothV;


        CamClamp();

        transform.localRotation = Quaternion.AngleAxis(-V2_Mouselook.y, Vector3.right);
        mGO_PlayerCharacter.transform.localRotation = Quaternion.AngleAxis(V2_Mouselook.x, mGO_PlayerCharacter.transform.up);


        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

    void CamClamp()
    {
        if (bl_YClamp == true)
        {
            V2_Mouselook.y = Mathf.Clamp(V2_Mouselook.y, -20, 20);
        }
        if (bl_XClamp == true)
        {
            V2_Mouselook.x = Mathf.Clamp(V2_Mouselook.x, -20, 20);
        }

    }

    void Station()
    {
        if (bl_Stationary == true)
        {
            bl_Stationary = true;
            V2_Mouselook.y = Mathf.Clamp(V2_Mouselook.y, 0, 0);
            V2_Mouselook.x = Mathf.Clamp(V2_Mouselook.x, 0, 0);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
