using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRatio : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1600, 900, true);
    }

    public void ScreenSize()
    {
        Screen.SetResolution(1600, 900, true);
    }
}
