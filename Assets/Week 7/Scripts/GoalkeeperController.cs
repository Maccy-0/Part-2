using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D goalKeeper;
    public float distance = 2.5f;
    public Vector2 goalpoint;
    Vector2 placeholder;
    Vector2 target = new Vector2(0,0);
    float speed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        goalKeeper.position = Vector2.MoveTowards(goalKeeper.position, target, speed*Time.deltaTime);

        placeholder = (Vector2)Controller.CurrentSelection.transform.position / Controller.CurrentSelection.transform.position.normalized;
        if (placeholder.x>4)
        {
            target = ((Vector2)Controller.CurrentSelection.transform.position).normalized * distance;
        }
        else
        {
            target = ((Vector2)Controller.CurrentSelection.transform.position).normalized * placeholder / 2;
        }
        
    }
}
