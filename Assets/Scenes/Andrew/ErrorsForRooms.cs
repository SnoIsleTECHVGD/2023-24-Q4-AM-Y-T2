using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class ErrorsForRooms : MonoBehaviour
{
    public GameObject ErrorLight;
    public GameObject MapLayout;
    public GameObject Lamp;

    //Don't ask why these are all Serialized, they just are
    [SerializeField]
    private GameObject[] _rooms; //Creates an array that allows for any # of rooms

    public GameObject[] _mapLights; //Lights for each room for when an error occurs there
    [SerializeField]
    private float RunTime; //How long the game is running

    public float ErrorTimer; //Timer for how often a error occurs, will scale as time progresses
    public float DeathTimer; //Once an error occurs this timer will start and if they dont complete in time, they maybe die?

    public string RoomError; //7 rooms
    [HideInInspector]
    public int RoomNumber; 

    public bool IsThereError = false;
    public bool isMontiorOn;

    // Start is called before the first frame update
    void Start()
    {
        ErrorTimer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var touchPos = new Vector2 (wp.x, wp.y);

            Collider2D hit = Physics2D.OverlapPoint(touchPos);

            if ((hit != null))
            {
                if(!EventSystem.current.IsPointerOverGameObject()) 
                {
                    Debug.Log("We actaully hit: " + hit.transform.name);

                    if(hit.transform.tag == "GameController")
                    {
                        if(IsThereError == true && ErrorLight != null)
                        {
                            IsThereError = false;
                            ErrorLight.SetActive(false);
                            Debug.Log("Error resolved");
                        }
                    }

                    if(hit.transform.tag == "EditorOnly")
                    {
                        if(MapLayout.activeInHierarchy == false && isMontiorOn == false)
                        {
                            MapLayout.SetActive(true);
                            Debug.Log("No");
                            isMontiorOn = true;
                            Lamp.SetActive(false);

                            if(ErrorLight.activeInHierarchy == true)
                            {
                                ErrorLight.SetActive(false);
                            }

                            if(IsThereError == true)
                            {
                                _mapLights[RoomNumber].gameObject.SetActive(true);
                            }
                            else
                            {
                                _mapLights[RoomNumber].gameObject.SetActive(false);
                            }    
                        }   
                        else
                        {
                            MapLayout.SetActive(false);
                            Debug.Log("Huh?");
                            isMontiorOn = false;
                            Lamp.SetActive(true);
                            if(ErrorLight.activeInHierarchy == false && IsThereError == true)
                            {
                                ErrorLight.SetActive(true);
                            }
                        }
                    }

                    return;
                }   
                else
                {
                    Debug.Log("Ahhh we hit smth else but what is smth else.");
                }
            }                
        }

        RunTime += Time.deltaTime;

        if(IsThereError == true)
        {
            DeathTimer -= Time.deltaTime;
        }

        if(RunTime >= 10)
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

        if(RunTime >= 45) //As time progress it will shorten the timer 
        {
            ErrorTimer = 10;
            Debug.Log("10 second timer");
        }

        if(RunTime >= 80)
        {
            ErrorTimer = 8;
            Debug.Log("Decreasing to 8 seconds");
        }

        if (RunTime >= 150) //Can add more if need be, or make it a large number
        {
            ErrorTimer = 6;
            Debug.Log("Decreasing to 6 seconds");
        }

        //How this works is weird but simple
        //All it does it will roll a dice that has any number of sides. It just depends on our number of rooms.
        //Then what it will do it will divide that by the number of room again to make sure it will be one of the rooms
        float error = Random.Range(0, _rooms.Length);
        switch(error%_rooms.Length)
        {
            case 1:
                RoomError = _rooms[0].ToString(); //Just Debugging to see and make sure it is hitting the right room
                ErrorLight.SetActive(true); //Setting the error light off 
                IsThereError=true; //Bool that an error is happening, simplest part to understand i hope
                DeathTimer = 8; // A timer that can change if needed, it will need to be changed
                RoomNumber = 0; // The indiactor of what room it is
                break;
            case 2:
                RoomError = _rooms[1].ToString();
                ErrorLight.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                RoomNumber = 1;
                break;
            case 3:
                RoomError = _rooms[2].ToString();
                ErrorLight.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                RoomNumber = 2;
                break;
            case 4:
                RoomError = _rooms[3].ToString();
                ErrorLight.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                RoomNumber = 3;
                break;
            case 5:
                RoomError = _rooms[4].ToString();
                ErrorLight.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                RoomNumber = 4;
                break;
            case 6:
                RoomError = _rooms[5].ToString();
                ErrorLight.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                RoomNumber = 5;
                break;
            case 7:
                RoomError = _rooms[6].ToString();
                ErrorLight.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                RoomNumber = 6;
                break;
            default:
                RoomError = "None";
                if((ErrorLight != null && IsThereError == false))
                {
                    ErrorLight.SetActive(false);
                    Debug.Log("No error occuring");
                }
                else
                {
                    ErrorLight.SetActive(true);
                    IsThereError = true;
                    Debug.Log("Error still occuring, please resolve it.");
                }
                break;
        }
        Debug.Log(RoomError); //Debugging
    }
}
