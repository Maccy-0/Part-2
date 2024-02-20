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

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(-8, 2.5f), 6);
        time = 0;
        animator = GetComponent<Animator>();
        Rad = Random.Range(1, 5);
        Debug.Log(Rad);
        animator.SetInteger("Rad_Trash", Rad);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        float weight = Acceleration.Evaluate(time * 0.1f);
        
        transform.position = new Vector2(transform.position.x, transform.position.y + -speed * Time.deltaTime * weight);
        if (transform.position.y < -6) 
        {
            Destroy(gameObject);
        }
    }
}
