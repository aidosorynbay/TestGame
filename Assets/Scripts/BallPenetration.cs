using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPenetration : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            // Set the wall's collider to be a trigger to allow the ball to penetrate.
            other.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
