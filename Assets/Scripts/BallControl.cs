using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public AudioSource WasitSounds;
    public AudioSource GoalSounds;
    public AudioSource EFXSounds;
    public AudioSource CrowdSounds;
    private Rigidbody2D rb2d;
    private bool isPlayerColliding = false;
    private bool isBoosting = false;
    private float boostedSpeed = 12f;
    private float boostCooldown = 2f;
    private float cooldownTimer = 0f;
    private int restartCount = 0; // Variabel untuk melacak jumlah restart
    public PlayerControls playerControls; // Variabel untuk menyimpan referensi ke script playerControls

/*    private bool hasCalledGoBall = false;*/



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //mengambil rigidbody component dari sebuah bole
        Invoke("GoBall", 2); //memanggil function GoBall dalam 2 detik

    }

/*    void CheckPosition()
    {
        float currPosX = transform.position.x;
        float currPosY = transform.position.y;

        if (!hasCalledGoBall && currPosY < 0.3f && Time.time > 7f)
        {
            Debug.Log(!hasCalledGoBall && currPosY < 2f && Time.time > 7f);
            rb2d.AddForce(new Vector2(-3, 15));
            hasCalledGoBall = true; // Set hasCalledGoBall menjadi true agar GoBall tidak dipanggil lagi
        }
    }*/
    void Update()
        {
            if (isBoosting)
            {
                cooldownTimer -= Time.deltaTime;

                if (cooldownTimer <= 0f)
                {
                    isBoosting = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
                    Debug.Log("SPS Availaible");
                }
            }
            else if (isPlayerColliding && Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.velocity = new Vector2(boostedSpeed, rb2d.velocity.y);
                isBoosting = true;
                cooldownTimer = boostCooldown;
                Debug.Log("SPS Used");
            }
            else
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
                Debug.Log("CD TOD!");
            }
/*        
        InvokeRepeating("CheckPosition", 0, 1f); // Ubah interval menjadi 1 detik*/
    }
        void GoBall()
        {
            int rand = Random.Range(0, 4); // Akan menghasilkan nilai acak antara 0-3

            switch (rand)
            {
                case 0:
                    // Bergerak ke kiri atas
                    rb2d.AddForce(new Vector2(-35, 15));
                    break;
                case 1:
                    // Bergerak ke kanan atas
                    rb2d.AddForce(new Vector2(35, 15));
                    break;
                case 2:
                    // Bergerak ke kiri bawah
                    rb2d.AddForce(new Vector2(-35, -15));
                    break;
                case 3:
                    // Bergerak ke kanan bawah
                    rb2d.AddForce(new Vector2(35, -15));
                    break;
                default:
                    break;
            }
        }

        void ResetBall() //ini kita buat nilai transform jadi 0
        {
            rb2d.velocity = Vector2.zero;
            transform.position = Vector2.zero;
            /*Invoke("GoBall", 2);*/
        }

        void RestartGame()
        {
            Debug.Log("Restart!");
            ResetBall();
            Invoke("GoBall", 4);
            WasitSounds.enabled = true;
            WasitSounds.Play();
        }

        void OutBall()
        {
            Debug.Log("Out Ball dan Restart!");
            ResetBall();
            Invoke("GoBall", 4);
            WasitSounds.enabled = true;
            WasitSounds.Play();
            restartCount++; // Tambahkan jumlah restart setiap kali permainan di-restart

            // Jika jumlah restart mencapai 3, kurangi kecepatan playerControls
            if (restartCount >= 5)
            {
                playerControls.speed -= 1.0f; // Kurangi kecepatan sebanyak 2
                restartCount = 0; // Reset jumlah restart agar bisa dimulai kembali
                Debug.Log("PlayerControl -1 speed");
            }
        }

        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.collider.CompareTag("Player")) //jika terkena player
            {
                // StartCoroutine(FireTriggger());
                isPlayerColliding = true;
                Debug.Log("COLLIDING");
                Debug.Log("Bola Kena Player");
                Vector2 vel;
                vel.x = rb2d.velocity.x;
                vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3); //mengambil nilai velocity player
                rb2d.velocity = vel;
                EFXSounds.enabled = true;
                EFXSounds.Play();
            }
        }
        void OnCollisionExit2D(Collision2D coll)
        {
            if (coll.collider.CompareTag("Player"))
            {
                isPlayerColliding = false;
                Debug.Log("GAK COLLIDING ");

            }
        }


        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Gawang")) //jika terkena Gawang
            {
                Debug.Log("Kena Gawang!");
                Vector2 vel;
                vel.x = 0;
                vel.y = 0;
                rb2d.velocity = vel;
                GoalSounds.enabled = true;
                GoalSounds.Play();
            }
            else if (collision.gameObject.CompareTag("Tiang"))
            {
                CrowdSounds.enabled = true;
                CrowdSounds.Play();
            }
        }
    }