using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject P1Wins;
    [SerializeField] private GameObject P2Wins;
    public int PlayerScoreL = 0;
    public int PlayerScoreR = 0;

    // Buat UI Text untuk skor dan waktu
    // Buat UI Text untuk skor dan waktu
    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;
    public TMP_Text txtGameTime; // Tambahkan ini

    private float gameTime = 600.0f; // Waktu permainan dalam detik (10 menit)
    private bool isGameFinished = false;
    private bool isGameStarted = false;

    public string myName1;
    public string myName;

    public static GameManager instance;

    // Implementasi singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Hapus salinan ganda GameManager
        }
    }

    void Start()
    {
        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();

        // Tampilkan waktu awal di UI
        UpdateGameTimeUI();
    }

    void Update()
    {   
        if (!isGameFinished && isGameStarted)
        {
            // Kurangi waktu setiap frame
            gameTime -= Time.deltaTime;

/*            if (Input.anyKeyDown)
            {
                StartGame();
            }*/
            // Periksa jika waktu berakhir
            if (gameTime <= 0)
            {
                gameTime = 0; // Pastikan waktu tidak menjadi negatif
                pauseBreak();
                Invoke("Finish", 6f);
            }
            Debug.Log("TEST SBC");
            // Perbarui tampilan waktu di UI game Anda
            UpdateGameTimeUI();
        }
    }

    void StartGame()
    {
        isGameStarted = true;

    }

    void pauseBreak()
    {
        isGameFinished = true;
    }

    // ... (kode lainnya)

    public void StartButtonClicked()
    {
        // Memulai permainan saat tombol "Mulai" diklik
        StartGame();
        Debug.Log("Mulai-Game");
    }



    // ... (kode lainnya)
    public void Score(string wallName)
    {
        if (wallName == "Gawang_L")
        {
            PlayerScoreR = PlayerScoreR + 1; //Menambah score
            txtPlayerScoreR.text = PlayerScoreR.ToString(); //Mengisikan nilai integer PlayerScore ke UI
            ScoreCheck();
        }
        else
        {
            PlayerScoreL = PlayerScoreL + 1;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
            ScoreCheck();

        }
    }
    public void ScoreCheck()
    {
        if (PlayerScoreL == 11)
        {
            Debug.Log("Player 1 FINISH GAME!!!");
            P1Wins.SetActive(true);
            pauseBreak();
            Invoke("Finish", 6f);

        }
        else if (PlayerScoreR == 11)
        {
            Debug.Log("Player 2 FINISH GAME!!!");
            P2Wins.SetActive(true);
            pauseBreak();
            Invoke("Finish", 6f);

        }
    }
    public void Finish()
    {
        isGameFinished = true;
        string winner = DetermineWinnerByScore();
        Debug.Log("FINISH GAME!!!");

        // Hancurkan GameManager sebelum memuat scene baru
        Destroy(gameObject);

        SceneManager.LoadScene("Menu");
        Debug.Log("Game Selesai! Pemenang: " + winner);
    }

    void UpdateGameTimeUI()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(gameTime);
        string formattedTime = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
        txtGameTime.text = "Time: " + formattedTime; // Tampilkan waktu di UI
    }


    string DetermineWinnerByScore()
    {
        if (PlayerScoreL > PlayerScoreR)
        {
            return "Player Left Win!";
        }
        else if (PlayerScoreR > PlayerScoreL)
        {
            return "Player Right Win!";
        }
        else
        {
            return "Seri";
        }
    }
    public void canStart(float delay = 0f)
    {
        StartCoroutine(startGame(delay));
    }

    IEnumerator startGame(float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
            
    }



    // ... (kode lainnya)
}
