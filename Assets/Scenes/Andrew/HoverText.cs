using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class HoverText : MonoBehaviour
{
    public string hoverText;
    public Text Text;
    public Image textBox;

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
            textBox.gameObject.SetActive(true);
            Debug.LogWarning("WE DID SOMETHING CORRECT.");
            Text.text = hoverText;
        }
        else
            textBox.gameObject.SetActive(false);
    }
}
