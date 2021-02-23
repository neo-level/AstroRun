using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private float gameSpeed = -3.0f;
    private void FixedUpdate()
    {
        transform.position += PlayerController.Player.transform.forward * (gameSpeed * Time.deltaTime);

        if (PlayerController.CurrentPlatform == null)
        {
            return;
        }

        // moves the platforms up or down respectively.
        if (PlayerController.CurrentPlatform.CompareTag("stairsUp"))
        {
            transform.Translate(0,-0.06f,0);
        }
        
        if (PlayerController.CurrentPlatform.CompareTag("stairsDown"))
        {
            transform.Translate(0,0.06f,0);
        }

    }
}
