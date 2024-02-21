using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 kickoff;
    public Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controller.Score += 1;
        transform.position = kickoff;
        rb.velocity = Vector2.zero;
        
    }
}
