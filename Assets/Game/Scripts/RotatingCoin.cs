using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCoin : MonoBehaviour
{
    

    private void FixedUpdate()
    {
        // make the coin rotate around the y-axis
        transform.Rotate(0, 5 , 0);
    }

    
}
