using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzlePiece: MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    //[SerializeField] private AudioSource _source;
    //[SerializeField] private AudioClip _pickUpClip, _dropClip;

    public bool _placed;
    public bool _dragging;
    public bool win;

    public Vector2 _offset, _originalPosition;

    private PuzzleSlot _slot;
    public DoorCode doorgood;

    public void Init(PuzzleSlot slot)
    {
        _renderer.sprite = slot.Renderer.sprite;
        _slot = slot;
    }


    private void Awake()
    {
        _originalPosition = transform.position;
        
    }

    private void Update()
    {
        doorgood = GameObject.Find("MainOffice").GetComponent<DoorCode>();

        if (doorgood.upclosed)
        {
            transform.position = _slot.transform.position;
            _placed = false;
            _dragging = false;
        }
        else if (!doorgood.upclosed && _slot.pubnumber == 0)
        {
            transform.position = _originalPosition;


        }
        if (_placed) return;
        if (!_dragging) return;


        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;

        //if (_slot.SlotIndex == 4)
        //{
        //    win = true;

        //}
       
       

    }


    public void OnMouseDown()
    {
        _dragging = true;
        //_source.PlayOneShot(_pickUpClip);

        _offset = GetMousePos() - (Vector2)transform.position;
    }

    public void OnMouseUp()
    {
        if(Vector2.Distance(transform.position,_slot.transform.position) < 0.5 )
        {
            transform.position = _slot.transform.position;
            _slot.Placed();
            _placed = true;
        }
        else
        {
            transform.position = _originalPosition;
           // _source.PlayOneShot(_dropClip);
            _dragging = false;
        }
        //if (_placed == true)
        //{
        //    win = true;
        //}
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    
}
