using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoverText : MonoBehaviour
{
    public string hoverText;
    public bool isHovering;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var touchPos = new Vector2(wp.x, wp.y);

        Collider2D hit = Physics2D.OverlapPoint(touchPos);

        hoverText = hit.transform.gameObject.name;

        if (hit.transform.gameObject.tag == "Doorways")
        {
            isHovering = true;
            
        }
     
    }
}
