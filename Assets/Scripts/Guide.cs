using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public GameObject GuideUI;
    public GameObject GuideCredits;
    public GameObject GuideSettings;
     void Update()
    {
        
    }
    public void GuideON()
    {
        GuideUI.SetActive(true);
        Debug.Log("Guide On");
    }
    public void GuideOff()
    {
        GuideUI.SetActive(false);
        Debug.Log("Guide Off");
    }
    public void CreditsON()
    {
        GuideCredits.SetActive(true);
        Debug.Log("Credits On");
    }
    public void CreditsOff()
    {
        GuideCredits.SetActive(false);
        Debug.Log("Credits Off");
    }
    public void SettingsON()
    {
        GuideSettings.SetActive(true);
        Debug.Log("Settings On");
    }
    public void SettingOff()
    {
        GuideSettings.SetActive(false);
        Debug.Log("Settings Off");
    }

}
