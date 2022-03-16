using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public UIPanel dialoguePanel;
    public UIPanel questPanel;
    public TimedPanel promptPanel;

    private DialogueBuffer dialogueBuffer;

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

    }

    // Shows prompt panel with given text
    public void ShowPrompt(string text) {
        promptPanel.Show(text);
    }

    // Hides prompt panel
    public void HidePrompt() {
        promptPanel.Hide();
    }

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
    }

    private void ShowDialogue(string text) {

        // In case prompt and quest panels were visible, hide them
        promptPanel.Hide();
        questPanel.Hide();

        dialoguePanel.Show(text);
    }

    // Method that gets UIHandler to begin dialogue process.
    // Dialogue is read from given buffer.
    public void BeginDialogue(DialogueBuffer buffer) {

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

    }
}
