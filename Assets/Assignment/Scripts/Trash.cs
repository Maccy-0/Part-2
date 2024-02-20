using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Trash : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    int Rad;
    public AnimationCurve Acceleration;
    public float speed;
    float time;
    bool falling;
    Vector2 mouse;
    Vector2 follow;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(-8, 2.5f), 6);
        time = 0;
        animator = GetComponent<Animator>();
        Rad = Random.Range(1, 5);
        animator.SetInteger("Rad_Trash", Rad);
        falling = true;
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        

        float weight = Acceleration.Evaluate(time * 0.1f);
        if (falling == true)
        {
            time += Time.deltaTime;
            transform.position = new Vector2(transform.position.x, transform.position.y + -speed * Time.deltaTime * weight);
        }
        else
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            follow = mouse - (Vector2)transform.position;
            rb.MovePosition(rb.position + follow.normalized * 8 * Time.deltaTime);

        }
        
        if (transform.position.y < -6) 
        {
            Destroy(gameObject);
            
        }
    }

    private void OnMouseDown()
    {
        falling = false;
    }

    private void OnMouseUp()
    {
        falling = true;
    }

    public void byebye()
    {
        Destroy(gameObject);
    }
}
