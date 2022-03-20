using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// UIPanel is a base class for scripts for panels in the UI

public class UIPanel : MonoBehaviour
{
    public TextMeshProUGUI panelText;

    // Make panel visible with given text
    // If no text is given, the text is what was last set
    public virtual void Show(string text = null) {

        gameObject.SetActive(true);

        if (text != null) {
            ChangeText(text);
        }
    }

    // Hide panel
    public virtual void Hide() {

        gameObject.SetActive(false);

    }

    // Change text in panel
    public virtual void ChangeText(string text) {

        panelText.text = text;

    }
}
