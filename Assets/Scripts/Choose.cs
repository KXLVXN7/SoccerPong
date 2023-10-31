using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose : MonoBehaviour
{

    public GameObject ChooseUI;

    public void ChooseON()
    {
        ChooseUI.SetActive(true);
        Debug.Log("Choose Button On");
    }

    public void ChooseOFF()
    {
        ChooseUI.SetActive(false);
        Debug.Log("Choose Button Off");
    }
}
