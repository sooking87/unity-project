// using System.Collections;
// using System.Collections.Generic;
using MixedReality.Toolkit.Input;
using MixedReality.Toolkit.UX;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormInputKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    private TouchScreenKeyboard keyboard;
    private string previousText = "";

    // Start is called before the first frame update
    void Start()
    {
    }
    public void OpenSystemKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardToInputField();
    }

    private void KeyboardToInputField()
    {
        if (keyboard != null && inputField != null)
        {
            // Check if the keyboard text has changed
            if (keyboard.text != previousText)
            {
                // Assign the keyboard text to the input field text
                inputField.text = keyboard.text;

                // Update the previousText
                previousText = keyboard.text;
            }
        }
    }

    public void CloseSystemKeyboard()
    {
        if (keyboard != null)
        {
            keyboard.active = false;
            keyboard = null;
        }
    }
}
