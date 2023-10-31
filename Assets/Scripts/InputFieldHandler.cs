using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputFieldHandler : MonoBehaviour
{
    public TMP_InputField tmpInputField; // Assign your TMP_InputField in the Unity Inspector.
    public TMP_InputField tmpInputField2; // Assign your TMP_InputField in the Unity Inspector.
    public TMP_Text displayText; // Assign your TMP_Text UI element in the Unity Inspector.
    public TMP_Text displayText2; // Assign your TMP_Text UI element in the Unity Inspector.
    public Button btnName;
    void Start()
    {
        // Pastikan displayText kosong saat aplikasi dimulai.
        displayText.text = "";
        btnName.interactable = false;
    }

    public void checkEmpty()
    {
        if (tmpInputField.text == "")
        {
            btnName.interactable = false;
        }
        else
        {
            btnName.interactable = true;
        }
    }

    public void OnButtonClick()
    {
        // Ambil teks dari TMP_InputField dan tampilkan di displayText
        string inputText = tmpInputField.text;
        displayText.text =  inputText;

        string inputText2 = tmpInputField2.text;
        displayText2.text = inputText2;
        Debug.Log("Keluarin Text");
    }
}
