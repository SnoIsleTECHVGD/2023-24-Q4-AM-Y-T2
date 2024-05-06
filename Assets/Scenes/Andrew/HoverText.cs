using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class HoverText : MonoBehaviour
{
    public string hoverText;
    private TMP_Text text;
    private Image textBox;
    public Image LeftextBox;
    public Image RightextBox;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Break();
        }

        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var touchPos = new Vector2(wp.x, wp.y);

        Collider2D hit = Physics2D.OverlapBox(Input.mousePosition, new Vector2(5,5), 0);

        if(hit)
        {
            Debug.Log(hit.transform.name);
        }

        //if (hit && hit.transform.gameObject.tag == "Doorways")
        //{
        //    if (hit.transform.position.x > 0) //Left side door
        //    {
        //        textBox = LeftextBox;
        //        text = textBox.GetComponentInChildren<TMP_Text>();
        //    }
        //    if (hit.transform.position.x < 0) //Right side door
        //    {
        //        textBox = RightextBox;
        //        text = textBox.GetComponentInChildren<TMP_Text>();
        //    }

        //    textBox.gameObject.SetActive(true);
        //    Debug.LogWarning("WE DID SOMETHING CORRECT.");
        //    hoverText = hit.transform.gameObject.name;
        //    Debug.Log(hoverText);
        //}
        //if(!hit)
        //    textBox.gameObject.SetActive(false);
    }
}
