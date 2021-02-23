using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    /// <summary>
    /// Deactivate the platforms when the player exits it.
    /// </summary>
    private void OnCollisionExit(Collision player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(SetInactive), 5.0f);
        }

    }
    private void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
