using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPlayer : MonoBehaviour
{
    public SpriteRenderer sr;
    Rigidbody2D rb;
    public float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        Selected(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Controller.SerCurrentSelection(this);
    }

    public void Selected(bool clicked)
    {
        if (clicked == false)
        {
            sr.color = new Color(0.5f, 0, 0);
        }
        else
        {
            sr.color = new Color(1, 1, 0);
        }
    }

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
