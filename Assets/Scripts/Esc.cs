using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Esc : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject Escape;
    public GameObject ScoreC;
    public AudioSource EscapeIntroSounds;

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameIsPaused)
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        Escape.SetActive(false);
        ScoreC.SetActive(true);
        Debug.Log("Lanjut");
        Time.timeScale = 1f;
        GameIsPaused = false;
        EscapeIntroSounds.enabled = false;
        EscapeIntroSounds.Pause();
    }

    void Pause()
    {
        Escape.SetActive(true);
        Debug.Log("Sedang Melakukan Pause !");
        /*ScoreC.SetActive(false);*/
        Time.timeScale = 0f;
        GameIsPaused = true;
        EscapeIntroSounds.enabled = true;
        EscapeIntroSounds.Play();

    }
    public void ChangeScenee(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Resume();
        Destroy(gameObject); // Hapus salinan ganda GameManager
    }
    public void QuitApp()
    {
        Application.Quit();
    }

    public void ChangeLoadScene(string sceneName)
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Ganti LoadScene");
        Resume();
        Destroy(gameObject); // Hapus salinan ganda GameManager
    }

    public void OnPlayButtonClicked()
    {
        Resume();
    }





}