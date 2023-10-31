using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScorer : MonoBehaviour
{
    [SerializeField] private GameObject goals;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Ball"))
        {
            Debug.Log("Goals");
            string wallName = transform.name;
            // Memanggil method Score di GameManager.cs
            if (GameManager.instance != null)
            {
                GameManager.instance.Score(wallName);
            }
            //camera shake
            cameraShake.Shake();
            // Memanggil method RestartGame() di BallControl.cs
            StartCoroutine(Goals_P(2f, hitInfo));
            StartCoroutine(Goals(3f));
        }
        else
        {
      /*      Debug.LogWarning("Object with tag 'Ball' not found in trigger.");*/
        }
    }


    private IEnumerator Goals(float waitTime)
        {
            Debug.Log("UI_Goals");
            goals.gameObject.SetActive(true);
            yield return new WaitForSeconds(waitTime);
            goals.gameObject.SetActive(false);
        }
        private IEnumerator Goals_P(float waitTime2, Collider2D hitInfo)
        {
            Debug.Log("Goals_Pause 0");
            Time.timeScale = 0.75f;
            yield return new WaitForSeconds(waitTime2);
            Debug.Log("Goals_Pause 1");
            Time.timeScale = 1.0f;
            hitInfo.gameObject.SendMessage("RestartGame", 3.0f, SendMessageOptions.RequireReceiver);
        }

        private IEnumerator Goals_R(float waitTime2, Collider2D hitInfo)
        {
            yield return new WaitForSeconds(waitTime2);

        }

    public CameraShake cameraShake;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gawang")) // Ganti dengan tag objek yang Anda inginkan
        {
            cameraShake.Shake();
            Debug.Log("GETAR");
        }
    }


}
