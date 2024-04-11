using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class ErrorsForRooms : MonoBehaviour
{
    #region Variables
    public GameObject MapLayout;
    public GameObject Lamp;

    public Light2D[] _mapLights; //Lights for each room for when an error occurs there

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

    //All just for lighting, bro this sucks
    [SerializeField] private int _smoothing = 5;
    [SerializeField] private int _delay = 5;
    [SerializeField] private float _duration = 5;

    private float _maxIntensity;
    private float _minIntensity;
    private Queue<float> _smoothQueue;
    private float _lastSum = 0;
    private float _factor;
    private Coroutine _flickerCoroutine;
    private WaitForSeconds _seconds;
    #endregion
    public void Reset()
    {
        StopCoroutine(_flickerCoroutine);
        _smoothQueue.Clear();
        _lastSum = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        ErrorTimer = 10;
        _seconds = new WaitForSeconds(_delay);
        _maxIntensity = _mapLights[^1].intensity;
        _smoothQueue = new Queue<float>(_smoothing);
        _flickerCoroutine = StartCoroutine(Flicker());
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
                    Debug.Log("Ahhh we hit smth else but what is smth else.");
                    return;
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
                _mapLights[^1].enabled = true;
                MakingRoomErrors();
                return;
            }
        }
    }

    #region Lighting
    private void DoFlicker()
    {
        if (_mapLights == null)
            return;
        while(_smoothQueue.Count >= _smoothing)
        {

        }
    }

    private IEnumerator Flicker()
    {
        float t = 0.0f;
        yield return _seconds;
        while (t<_duration)
        {
            DoFlicker();
            t += Time.deltaTime;
            yield return null;
        }
        _flickerCoroutine = StartCoroutine(Flicker());
    }

    #endregion

    #region Interact Calls
    private void PuzzleDebuggerInteract()
    {
        if (IsThereError)
        {
            IsThereError = false;
            Debug.Log("Error resolved");
            foreach(Light2D blur in _mapLights)
            {
                if(blur.enabled)
                {
                    blur.enabled = false;
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
            _mapLights[^1].enabled = true;
    }

    private void MonitorInteract()
    {
        if (MapLayout.activeInHierarchy || isMontiorOn)
            return;

        MapLayout.SetActive(true);
        isMontiorOn = true;
        Lamp.SetActive(false);
        _mapLights[^1].enabled = false;

        if (IsThereError)
            _mapLights[RoomNumber].gameObject.SetActive(true);
        else
            _mapLights[RoomNumber].gameObject.SetActive(false);
    }
    #endregion

    void MakingRoomErrors()
    {
        #region Error Timer
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
        #endregion

        #region Room Randomizer
        int error = Random.Range(0, _rooms.Length);

        RoomError = _rooms[error].ToString(); //Just Debugging to see and make sure it is hitting the right room 
        IsThereError = true; //Bool that an error is happening, simplest part to understand i hope
        RoomNumber = error; // The indiactor of what room it is

        #endregion

        Debug.Log(RoomError); //Debugging
    }
}
