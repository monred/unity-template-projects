using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlatformerPlayer") || other.CompareTag("Player") || other.GetComponent<PlatformerMovement>() != null)
        {
            if (respawnPoint != null)
            {
                other.transform.position = respawnPoint.position;

                Rigidbody2D rb = other.attachedRigidbody;
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                }
            }
            else
            {
                Debug.LogWarning("DeathBox: respawnPoint is not set.", this);
            }
        }
    }
}
