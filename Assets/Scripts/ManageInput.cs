using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManageInput : MonoBehaviour

{
    public TMP_Text nameText;
    public string myName;
    // Start is called before the first frame update
    public void setName()
    {
        myName = GetComponent<InputFieldHandler>().tmpInputField.text;
        nameText.text = myName;
    }
}
