using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public DialoguePanel dialoguePanel;
    public HintPanel hintPanel;

    private DialogueBuffer dialogueBuffer;

    private readonly string controlsString = "<b>Controls:</b> WASD to Walk, Space to Jump, E to Interact, Esc to Quit.";

    private void Awake() {

        // In case UI is not hidden, hide it
        dialoguePanel.Hide();
        hintPanel.Hide();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set quit hint panel (no expiration)
        hintPanel.Show(controlsString);
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

          //  Debug.Log("Space or enter pressed!");

            ShowNextLine();
        }

    }

    private void ShowNextLine() {

        if (dialogueBuffer == null) {
          //  Debug.LogError("UIHandler.ShowNextLine called, but dialogueBuffer is null. Returning.");
            return;
        }

        string nextline = dialogueBuffer.GetNextLine();

        // If there is no next line, close dialogue and return gamestate to playing
        if (nextline == null) {

        //    Debug.Log("No more dialogue. Should hide dialogue panel.");

            dialoguePanel.Hide();
            dialogueBuffer = null;

            // TODO: FOR THE SECOND PLAYABLE, THE HINT PANEL IS SHOWN AGAIN
            // AFTER DIALOGUE BECAUSE IT SHOWS THE CONTROLS. REMOVE
            // THIS AFTER THE SECOND PLAYABLE HAS BEEN SUBMITTED
            hintPanel.Show(controlsString);

            GameState.SetNewState(GAMESTATE.PLAYING);
            return;
        }

        // Otherwise show next line
        ShowDialogue(nextline);
    }

    private void ShowDialogue(string text) {

        // In case hint panel was visible, hide it
        hintPanel.Hide();

        dialoguePanel.Show(text);
    }

    // Method that gets UIHandler to begin dialogue process.
    // Dialogue is read from given buffer.
    public void BeginDialogue(DialogueBuffer buffer) {

        string firstline = buffer.GetNextLine();

        if (firstline == null) {
          //  Debug.LogWarning("UIHandler could not get first line from DialogueBuffer. Returning.");
            return;
        }

        // Store reference to buffer and set gamestate to dialogue
        dialogueBuffer = buffer;

        GameState.SetNewState(GAMESTATE.DIALOGUE);

        // Show first line
        ShowDialogue(firstline);

    }
}
