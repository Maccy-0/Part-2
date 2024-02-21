using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPlayer : MonoBehaviour
{
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        Selected(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Selected(true);
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
}
