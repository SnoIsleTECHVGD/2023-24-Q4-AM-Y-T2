using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ErrorsForRooms : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _rooms; //Creates a list that allows for any # of rooms
    [SerializeField]
    private GameObject mainConsole;
    [SerializeField]
    private float ErrorTimer; 
    [SerializeField]
    private float RunTime; //How long the game is running
    [SerializeField]
    private string RoomError; //7 rooms

    public bool IsThereError = false;

    // Start is called before the first frame update
    void Start()
    {
        ErrorTimer = 10;
    }

    // Update is called once per frame
    void Update()
    {

        RunTime += Time.deltaTime;

        if(RunTime <= 60)
        {
            ErrorTimer -= Time.deltaTime;

            if (ErrorTimer <= 0 )
            {
                MakingRoomErrors();
                return;
            }
        }
    }

    void MakingRoomErrors()
    {
        ErrorTimer = 10;
        float error = Random.Range(0, _rooms.Length);
        switch(error%_rooms.Length)
        {
            case 1:
                RoomError = _rooms[0].ToString();  
                mainConsole.SetActive(true);
                IsThereError=true;
                break;
            case 2:
                RoomError = _rooms[1].ToString();
                mainConsole.SetActive(true);
                IsThereError=true;
                break;
            case 3:
                RoomError = _rooms[2].ToString();
                mainConsole.SetActive(true);
                IsThereError=true;
                break;
            case 4:
                RoomError = _rooms[3].ToString();
                mainConsole.SetActive(true);
                IsThereError=true;
                break;
            case 5:
                RoomError = _rooms[4].ToString();
                mainConsole.SetActive(true);
                IsThereError=true;
                break;
            case 6:
                RoomError = _rooms[5].ToString();
                mainConsole.SetActive(true);
                IsThereError=true;
                break;
            case 7:
                RoomError = _rooms[6].ToString();
                mainConsole.SetActive(true);
                IsThereError=true;
                break;
            default:
                RoomError = "None";
                if((mainConsole != null || IsThereError == false))
                {
                    mainConsole.SetActive(false);
                }
                break;
        }
        Debug.Log(RoomError);
    }
}
