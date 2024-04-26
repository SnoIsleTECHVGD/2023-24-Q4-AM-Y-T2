using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class HoverText : MonoBehaviour
{
    public string hoverText;
    public Text Text;
    public Image textBox;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Text.text = hoverText;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var touchPos = new Vector2(wp.x, wp.y);

        Collider2D hit = Physics2D.OverlapPoint(touchPos);

        if (hit && hit.transform.gameObject.tag == "Doorways")
        {
            textBox.gameObject.SetActive(true);
            Debug.LogWarning("WE DID SOMETHING CORRECT.");
            hoverText = hit.transform.gameObject.name;
            //Debug.Log(hit.transform.position);

            //if(hit.transform.position.x > 0)
            //{
            //    offset = new Vector3(8, 0,0);
            //}
            //if(hit.transform.position.x < 0)
            //{
            //    offset = new Vector3(, 0,0);
            //}


            textBox.transform.position = hit.transform.position - offset;
        }
        if(!hit)
            textBox.gameObject.SetActive(false);
    }
}
