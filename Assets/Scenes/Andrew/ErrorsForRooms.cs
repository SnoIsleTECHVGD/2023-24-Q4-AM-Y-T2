using UnityEngine;
using UnityEngine.EventSystems;

public class ErrorsForRooms : MonoBehaviour
{
    public GameObject MainConsole;
    public GameObject MapLayout;

    //Don't ask why these are all Serialized, they just are
    [SerializeField]
    private GameObject[] _rooms; //Creates an array that allows for any # of rooms
    [SerializeField]
    private float ErrorTimer; //Timer for how often a error occurs, will scale as time progresses
    [SerializeField]
    private float RunTime; //How long the game is running
    [SerializeField]
    private float DeathTimer; //Once an error occurs this timer will start and if they dont complete in time, they maybe die?
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
                        if(IsThereError == true && MainConsole != null)
                        {
                            IsThereError = false;
                            MainConsole.SetActive(false);
                            Debug.Log("Error resolved");
                        }
                    }

                    if(hit.transform.tag == "EditorOnly")
                    {
                        if(MapLayout != null)
                        {
                            MapLayout.SetActive(true);
                            Debug.Log("No");
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
        else
        {
            Debug.Log("I lied it was actually nothing");
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

        if(RunTime >= 45)
        {
            ErrorTimer = 10;
            Debug.Log("10 second timer");
        }

        if(RunTime >= 80)
        {
            ErrorTimer = 8;
            Debug.Log("Decreasing to 8 seconds");
        }

        if (RunTime >= 150)
        {
            ErrorTimer = 6;
            Debug.Log("Decreasing to 6 seconds");
        }


        float error = Random.Range(0, _rooms.Length);
        switch(error%_rooms.Length)
        {
            case 1:
                RoomError = _rooms[0].ToString();  
                MainConsole.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                break;
            case 2:
                RoomError = _rooms[1].ToString();
                MainConsole.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                break;
            case 3:
                RoomError = _rooms[2].ToString();
                MainConsole.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                break;
            case 4:
                RoomError = _rooms[3].ToString();
                MainConsole.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                break;
            case 5:
                RoomError = _rooms[4].ToString();
                MainConsole.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                break;
            case 6:
                RoomError = _rooms[5].ToString();
                MainConsole.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                break;
            case 7:
                RoomError = _rooms[6].ToString();
                MainConsole.SetActive(true);
                IsThereError=true;
                DeathTimer = 8;
                break;
            default:
                RoomError = "None";
                if((MainConsole != null && IsThereError == false))
                {
                    MainConsole.SetActive(false);
                    Debug.Log("No error occuring");
                }
                else
                {
                    MainConsole.SetActive(true);
                    IsThereError = true;
                    Debug.Log("Error still occuring, please resolve it.");
                }
                break;
        }
        Debug.Log(RoomError);
    }
}
