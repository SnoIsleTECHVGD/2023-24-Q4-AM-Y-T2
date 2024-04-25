using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using System.Linq;

public class ErrorsForRooms : MonoBehaviour
{
    #region Variables
    public GameObject MapLayout;
    public GameObject Lamp;

    public Light2D[] _mapLights; //Lights for each room for when an error occurs there
    public Light2D errorLight;
    public GameObject[] _puzzles;

    [SerializeField]
    private GameObject[] _rooms; //Creates an array that allows for any # of rooms
    [SerializeField]
    private float RunTime; //How long the game is running

    public float ErrorTimer; //Timer for how often a error occurs, will scale as time progresses

    public string RoomError; //7 rooms

    public bool IsThereError = false;
    public bool isMontiorOn;
    [HideInInspector]
    public int RoomNumber;

    public float flickerIntenisty;
    public float flickerPerSecond;

    private float startingIntensity;
    private float time;

    private GameManager gm;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ErrorTimer = 10;
        startingIntensity = errorLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var touchPos = new Vector2 (wp.x, wp.y);

            Collider2D hit = Physics2D.OverlapPoint(touchPos);

            if (hit != null)
            {
                if(EventSystem.current.IsPointerOverGameObject()) 
                {
                    Debug.Log("Nah, i dont want to work.");
                    //return;
                }

                Debug.Log("We actaully hit: " + hit.transform.name);

                switch(hit.transform.tag)
                {
                    case "Monitor":
                        MonitorInteract();
                        return;
                    case "Map":
                        MapInteract();
                        return;
                    case "PuzzleDebugger":
                        PuzzleDebuggerInteract();
                        return;
                    default:
                        return;
                }
            }                
        }

        RunTime += Time.deltaTime;

        
        if(RunTime > 0)
        {
            ErrorTimer -= Time.deltaTime;
            //When the timer hits below zero then it will roll some dice to see if it will error out
            if (ErrorTimer <= 0 )
            {
                errorLight.enabled = true;
                MakingRoomErrors();
                return;
            }

            if(IsThereError)
            {
                float broski = 1; //Shhhhhhhh.....this isn't named poorly....

                if (isMontiorOn)
                {
                    _mapLights[RoomNumber].gameObject.SetActive(true);
                }
                flickerPerSecond = _mapLights.Count(item => item.gameObject.activeSelf);
                time += Time.deltaTime * (1 + Random.Range(0, broski)) * Mathf.PI;
                errorLight.intensity = startingIntensity + (Mathf.Sin(time * flickerPerSecond) + 1) * flickerIntenisty;
            }
            if(Input.GetKeyDown(KeyCode.S))
            {
                errorLight.enabled = false;
                foreach (Light2D blur in _mapLights)
                {
                    if (blur.gameObject.activeSelf)
                    {
                        blur.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    #region Interact Calls
    private void PuzzleDebuggerInteract()
    {
        if (IsThereError)
        {
            IsThereError = false;
            errorLight.enabled = false;
            Debug.Log("Error resolved");
            foreach(Light2D blur in _mapLights)
            {
                if(blur.gameObject.activeSelf)
                {
                    blur.gameObject.SetActive(false);
                }
            }
        }
    }

    private void MapInteract()
    {
        MapLayout.SetActive(false);
        isMontiorOn = false;
        Lamp.SetActive(true);
        if (IsThereError)
            errorLight.enabled = true;
    }

    private void MonitorInteract()
    {
        if (MapLayout.activeInHierarchy || isMontiorOn)
            return;

        MapLayout.SetActive(true);
        isMontiorOn = true;
        Lamp.SetActive(false);
        errorLight.enabled = false;
    }
    #endregion

    void MakingRoomErrors()
    {
        #region Error Timer
        ErrorTimer = 60;

        if(RunTime >= 45) //As time progress it will shorten the timer 
        {
            ErrorTimer = 60;
            Debug.Log("10 second timer");
        }

        if(RunTime >= 80)
        {
            ErrorTimer = 60;
            Debug.Log("Decreasing to 8 seconds");
        }

        if (RunTime >= 150) //Can add more if need be, or make it a large number
        {
            ErrorTimer = 60;
            Debug.Log("Decreasing to 6 seconds");
        }
        #endregion

        #region Room Randomizer
        int error = Random.Range(0, _rooms.Length);

        RoomError = _rooms[error].ToString(); //Just Debugging to see and make sure it is hitting the right room 
        IsThereError = true; //Bool that an error is happening, simplest part to understand i hope
        RoomNumber = error; // The indiactor of what room it is
        _mapLights[RoomNumber].gameObject.SetActive(true);
        _puzzles[RoomNumber].gameObject.SetActive(true);

        #endregion

        Debug.Log(RoomError); //Debugging
    }
}
