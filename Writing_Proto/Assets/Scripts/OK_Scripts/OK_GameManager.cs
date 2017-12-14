using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK_GameManager : MonoBehaviour {


    // Var for timer

    private float startTime;
    private float fl_Time;


    // Var Gameobjects that turn on/off

    public GameObject Console_Idle;
    public GameObject Console1;
    public GameObject Console2;
    public GameObject Console3;
    public GameObject Console4;
    public GameObject ScreenIdle;
    public GameObject Screen;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        TimerScene();

    }

    #region Timer
    // Allows for us to time the scene.
    void TimerScene()
    {
        fl_Time = Time.time - startTime;

        string minutes = ((int)fl_Time / 60).ToString();
        string seconds = (fl_Time % 60).ToString("f2");

        Debug.Log(minutes + ":" + seconds);


        if (fl_Time >= 180)
        {
            Screen.SetActive(true);
            ScreenIdle.SetActive(false);
        }
        else if (fl_Time >= 120)
        {
            Console4.SetActive(true);
            Console_Idle.SetActive(false);
        }
        else if (fl_Time >= 90)
        {
            Console3.SetActive(true);
            Console_Idle.SetActive(false);
        }
        else if (fl_Time >= 60)
        {
            Console2.SetActive(true);
            Console_Idle.SetActive(false);
        }
        else if (fl_Time >= 30)
        {
            Console1.SetActive(true);
            Console_Idle.SetActive(false);
        }










    }
#endregion
}
