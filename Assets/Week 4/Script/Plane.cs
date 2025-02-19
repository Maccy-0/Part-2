using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D RB;
    public float Speed;
    public AnimationCurve Landing;
    float landingTimer;
    public SpriteRenderer spriteRenderer;
    public Sprite[] Planes;
    bool landing;
    public float Score;

    void Start()
    {
        Score = 0;
        landing = false;
        transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        Speed = Random.Range(1, 3);
        spriteRenderer.sprite = Planes[Random.Range(0, 3)];
        spriteRenderer.color = new Color(255, 255, 255);

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        RB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            RB.rotation = -angle;
        }
        RB.MovePosition(RB.position + (Vector2)transform.up * Speed * Time.deltaTime);
    }

    private void Update()
    {
        if (Physics2D.OverlapPoint(new Vector2(7, -2)))
        {
            landing = true;
        }
        if (landing == true)
        {
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = Landing.Evaluate(landingTimer);
            if(transform.localScale.z > 0.9f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
            Score += 1;
        }

        lineRenderer.SetPosition(0, transform.position);
        if(points.Count > 0)
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                
                lineRenderer.positionCount--;
            }
        }

        if (transform.position.y > 6 | transform.position.y < -6 | transform.position.x > 13 | transform.position.x < -13)
        {
            Destroy(gameObject);
        }


    }

    void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Vector2.Distance(lastPosition, newPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        spriteRenderer.color = new Color(255, 0, 0);
        if (Vector3.Distance(collision.transform.position, transform.position) < 1.5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = new Color(255, 255, 255);
    }

    
}
