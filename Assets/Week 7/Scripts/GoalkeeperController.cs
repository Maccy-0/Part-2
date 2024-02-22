using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D goalKeeper;
    public float distance = 2.5f;
    public Vector2 goalpoint;
    Vector2 placeholder;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        placeholder = (Vector2)Controller.CurrentSelection.transform.position / Controller.CurrentSelection.transform.position.normalized;
        if (placeholder.x>4)
        {
            goalKeeper.position = ((Vector2)Controller.CurrentSelection.transform.position).normalized * distance;
        }
        else
        {
            goalKeeper.position = ((Vector2)Controller.CurrentSelection.transform.position).normalized * placeholder / 2;
        }
        
    }
}
