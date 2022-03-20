using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: move dialogue navigation and bookkeeping to DialogueMaster,
// have this only as an interface for showing things in the UI

public class UIHandler : MonoBehaviour
{
    public UIPanel dialoguePanel;
    public UIPanel questPanel;
    public TimedPanel promptPanel;

    // FOR DEMOS
    //private readonly string controlsString = "<b>Controls:</b> WASD to Walk, Space to Jump, E to Interact, Esc to Quit.";

    // Quest panel title (collapsed)
    private readonly string questString = "<b>Quests</b> (Q)";

    private void Awake() {

        // In case dialogue panel and prompt panel are not hidden, hide them
        dialoguePanel.Hide();
        promptPanel.Hide();

        // Show quest panel
        questPanel.Show(questString);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        // If there is no dialogue, do nothing
        if (GameState.GetCurrentState() != GAMESTATE.DIALOGUE) {
            return;
        }

        // Check for E key or enter
        if ( Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) {

            Debug.Log("Space or enter pressed!");

            ShowNextLine();
        }

    }*/

    // Shows prompt panel with given text
    public void ShowPrompt(string text) {
        promptPanel.Show(text);
    }

    // Hides prompt panel
    public void HidePrompt() {
        promptPanel.Hide();
    }

    /*
    private void ShowNextLine() {

        if (dialogueBuffer == null) {
            Debug.LogError("UIHandler.ShowNextLine called, but dialogueBuffer is null. Returning.");
            return;
        }

        string nextline = dialogueBuffer.GetNextLine();

        // If there is no next line, close dialogue and return gamestate to playing
        if (nextline == null) {

            Debug.Log("No more dialogue. Should hide dialogue panel.");

            dialoguePanel.Hide();
            dialogueBuffer = null;

            // Show quest panel again
            questPanel.Show();

            GameState.SetNewState(GAMESTATE.PLAYING);
            return;
        }

        // Otherwise show next line
        ShowDialogue(nextline);
    }*/

    // Enter dialogue mode of UI with given text
    public void EnterDialogueMode(string text) {

        // In case prompt and quest panels were visible, hide them
        promptPanel.Hide();
        questPanel.Hide();

        // Show dialogue panel with giveen text
        dialoguePanel.Show(text);
    }

    // Exit dialogue mode
    public void ExitDialogueMode() {

        // Hide dialogue
        dialoguePanel.Hide();

        // Show quest panel again
        questPanel.Show();
    }

    // Show given text in dialogue window
    // NOTE: should only be called after EnterDialogueMode
    public void ShowDialogueText(string text) {
        dialoguePanel.Show(text);
    }

    /*
    // Method that gets UIHandler to begin dialogue process.
    // Dialogue is read from given buffer.
    public void BeginDialogue(DialogueMaster buffer) {

        string firstline = buffer.GetNextLine();

        if (firstline == null) {
            Debug.LogWarning("UIHandler could not get first line from DialogueBuffer. Returning.");
            return;
        }

        // Store reference to buffer and set gamestate to dialogue
        dialogueBuffer = buffer;

        GameState.SetNewState(GAMESTATE.DIALOGUE);

        // Show first line
        ShowDialogue(firstline);

    }*/
}
