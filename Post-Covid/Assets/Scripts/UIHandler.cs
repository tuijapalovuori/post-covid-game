using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public UIPanel dialoguePanel;
    public UIPanel questPanel;
    public TimedPanel hintPanel;

    private DialogueBuffer dialogueBuffer;

    // For demos
    //private readonly string controlsString = "<b>Controls:</b> WASD to Walk, Space to Jump, E to Interact, Esc to Quit.";

    private readonly string questString = "<b>Quests</b> (Q to expand)";

    private void Awake() {

        // In case dialogue panel and hint panel are not hidden, hide them
        dialoguePanel.Hide();
        hintPanel.Hide();

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

        // In case hint and quest panels were visible, hide them
        hintPanel.Hide();
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
