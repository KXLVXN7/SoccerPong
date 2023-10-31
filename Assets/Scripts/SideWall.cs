using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.name == "Ball")
        {
            Debug.Log("Keluar");
            string wallName = transform.name;
            //memanggil method Score di GameManager.cs
           /* GameManager.instance.Score(wallName);*/
            //memanggil method RestartGame() di BallControl.cs
            hitInfo.gameObject.SendMessage("OutBall", 1.0f, SendMessageOptions.RequireReceiver);
            
        }
      
    }
}