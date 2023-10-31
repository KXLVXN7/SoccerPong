using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiang : MonoBehaviour
{
    public AudioSource Crowd;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("TIANG CROWD!");
            Crowd.enabled = true;
            Crowd.Play();
        }
    }
}
