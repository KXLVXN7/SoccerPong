using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMain : MonoBehaviour
{
    //fungsi mengganti scene melalui suatu dengan memakai parameter suatu nama scene
    public void PlayChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    //fungsi untuk keluar dari aplikasi
    public void QuitApp()
    {
        Application.Quit();
    }
    public void Finish(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}