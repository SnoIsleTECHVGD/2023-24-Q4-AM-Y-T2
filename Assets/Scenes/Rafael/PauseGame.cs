using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    bool paused = false;
    // Start is called before the first frame update
    void Start()
    {

       

        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = togglePause();




        }

        if (paused)
        {

            Debug.Log("Game is paused");

        }




    }

    bool togglePause()
    {

        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);


        }
        else
        {
            Time.timeScale = 0f;
            return (true);


        }




    }
}
