using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// TimedPanel inherits UIPanel but adds a timed functionality:
// the panel can be given an amount of time that it is shown,
// after which it disappears.

public class TimedPanel : UIPanel
{
    private bool timerOn;
    private float timer;

    // Make panel visible with given text and shows it for given time (seconds).
    // If no text is given, the text is what was last set.
    // If no time is given or the time is negative, nothing is done
    // (which isn't sensible use but the time parameter needs a default value
    // in order to come after the optional text parameter)
    public void ShowForSeconds(string text = null, float time = -1f) {

        if (time > 0f) {
            return;
        }

        gameObject.SetActive(true);

        if (text != null) {
            ChangeText(text);
        }

        timerOn = true;
        timer = time;
    }

    // Hide panel (resets timer)
    public override void Hide() {

        // Stop timing, reset timer
        timerOn = false;
        timer = 0f;

        gameObject.SetActive(false);

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
