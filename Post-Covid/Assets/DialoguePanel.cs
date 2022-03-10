using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// DialoguePanel is a script for the dialogue panel that allows
// for easy showing and hiding of the panel as well as
// changing of its text

public class DialoguePanel : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    // TODO text writing effect?

    // Make panel visible with given text
    // If no text is given, the text is what was last set
    public void Show(string text = null) {

        Debug.Log("DialoguePanel.Show called.");

        gameObject.SetActive(true);

        if (text != null) {
            ChangeText(text);
        }
    }

    // Hide panel
    public void Hide() {

        Debug.Log("DialoguePanel.Hide called.");

        gameObject.SetActive(false);  // TODO why does this not work?

    }

    // Change text in panel
    public void ChangeText(string text) {

        dialogueText.text = text;

    }
}
