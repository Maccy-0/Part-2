using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge;
    Vector2 direction;

    public static FootPlayer CurrentSelection{ get; private set; }
    public static float Score;
    public TextMeshProUGUI ScoreText;

    private void Start()
    {
        Score = 0;
    }
    public static void SerCurrentSelection(FootPlayer player)
    {
        if(CurrentSelection != null)
        {
            CurrentSelection.Selected(false);
        }
        CurrentSelection = player;
        CurrentSelection.Selected(true); 
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            CurrentSelection.Move(direction);
            direction = Vector2.zero;
        }
        ScoreText.text = "Score:" + Score;
    }
    private void Update()
    {
        if(CurrentSelection == null) { return; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
            chargeSlider.value = charge;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)CurrentSelection.transform.position).normalized * charge;
        }
    }
}
