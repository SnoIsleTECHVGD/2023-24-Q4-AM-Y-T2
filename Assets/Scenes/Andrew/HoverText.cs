using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class HoverText : MonoBehaviour
{
    public string hoverText;
    public TMP_Text text;
    public Image textBox;
    public Canvas potatoCanvas;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        ////var screenPoint = Vector3(Input.mousePosition);
        //screenPoint.z = 10.0f;
        //textBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);


        if (hit.collider == null)
        {
            textBox.gameObject.SetActive(false);
        }
        if(hit.collider != null)
        {
            textBox.gameObject.SetActive(true);
            hoverText = hit.transform.gameObject.name;
            Debug.Log(hit.transform.gameObject.name);

            text.SetText(hoverText);
        }

    }
}
