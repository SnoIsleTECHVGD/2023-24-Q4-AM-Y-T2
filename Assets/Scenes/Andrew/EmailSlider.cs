using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class EmailSlider : MonoBehaviour
{
    public GameObject[] emails;
    private int CurrentSlide;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var touchPos = new Vector2(wp.x, wp.y);

            Collider2D hit = Physics2D.OverlapPoint(touchPos);

            if (hit != null)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("Nah, i dont want to work.");
                    //return;
                }

                Debug.Log("We actaully hit: " + hit.transform.name);

                switch (hit.transform.tag)
                {
                    case "Previous":
                        PreviousInteract();
                        return;
                    case "Next":
                        NextInteract();
                        return;
                    default:
                        return;
                }
            }
        }
}

    private void NextInteract()
    {
        if (CurrentSlide >= emails.Length)
            return;
        if (CurrentSlide <= emails.Length)
        {
            CurrentSlide++;

            foreach (GameObject blur in emails)
            {
                if (blur.gameObject.activeSelf)
                {
                    blur.gameObject.SetActive(false);
                }
            }
            emails[CurrentSlide].SetActive(true);
        }
    }

    private void PreviousInteract()
    {
        CurrentSlide--;
        foreach (GameObject blur in emails)
        {
            if (blur.gameObject.activeSelf)
            {
                blur.gameObject.SetActive(false);
            }
        }
        emails[CurrentSlide].SetActive(true);
    }
}
