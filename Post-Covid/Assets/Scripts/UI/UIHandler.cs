using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UIHandler is a class that works as an interface for the various
// UI elements, such as the dialogue panel, the quest panels
// and the prompt panel.

public class UIHandler : MonoBehaviour
{
    public UIPanel dialoguePanel;
    public QuestPanels questPanels;
    public TimedPanel promptPanel;

    // FOR DEMOS
    //private readonly string controlsString = "<b>Controls:</b> WASD to Walk, Space to Jump, E to Interact, Esc to Quit.";

    private void Awake() {

        // In case dialogue panel and prompt panel are not hidden, hide them
        dialoguePanel.Hide();
        promptPanel.Hide();

        // Show quest panels
        questPanels.Show();
    }

    // Update is called once per frame
    void Update() {

        // Check for Q, which collapses or expands quest list
        if (Input.GetKeyDown(KeyCode.Q)) {

            //Debug.Log("Q pressed!");

            if (questPanels.IsExpanded) {
                questPanels.Collapse();
            } else {
                questPanels.Expand();
            }
        }
    }

    // Shows prompt panel with given text
    public void ShowPrompt(string text) {
        promptPanel.Show(text);
    }

    // Hides prompt panel
    public void HidePrompt() {
        promptPanel.Hide();
    }

    // Enter dialogue mode of UI with given text
    public void EnterDialogueMode(string text) {

        // In case prompt and quest panels were visible, hide them
        promptPanel.Hide();
        questPanels.Hide();

        // Show dialogue panel with giveen text
        dialoguePanel.Show(text);
    }

    // Exit dialogue mode
    public void ExitDialogueMode() {

        // Hide dialogue
        dialoguePanel.Hide();

        // Show quest panels again
        questPanels.Show();
    }

    // Show given text in dialogue window
    // NOTE: should only be called after EnterDialogueMode
    public void ShowDialogueText(string text) {
        dialoguePanel.Show(text);
    }

}
