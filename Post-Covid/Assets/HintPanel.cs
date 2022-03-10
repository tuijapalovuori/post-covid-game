using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// HintPanel is a script for the hint panel that allows
// for easy showing and hiding of the panel as well as
// changing of its text

public class HintPanel : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    private bool timerOn;
    private float timer;

    // Make panel visible with given text and shows it for given time (seconds).
    // If no text is given, the text is what was last set.
    // If no time is given or the time is 0, no timer is set.
    public void Show(string text = null, float time = 0f) {

        gameObject.SetActive(true);

        if (text != null) {
            ChangeText(text);
        }

        if (time > 0f) {
            timerOn = true;
            timer = time;
        }
    }

    // Hide panel (resets timer)
    public void Hide() {

        // Stop timing, reset timer
        timerOn = false;
        timer = 0f;

        gameObject.SetActive(false);

    }

    // Change text in panel
    public void ChangeText(string text) {

        hintText.text = text;

    }

    public void Update() {

        // If there is a timer on
        if (timerOn) {

            // Subtract elapsed time from timer
            timer -= Time.deltaTime;

            // If timer has expired, hide (automatically stops timing and resets timer)
            if (timer <= 0f) {
                Hide();
            }
        }

    }
}
