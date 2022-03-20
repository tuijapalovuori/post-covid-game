using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DialogueMaster is a class in charge of
// displaying and navigating through dialogue.
// There should only be one of them.

public class DialogueMaster : MonoBehaviour {

    public UIHandler uiHandler;
    private List<string> lines;
    private int index;
    private Action afterDialogueAction;

    // Update is called once per frame
    void Update() {

        // If there is no dialogue, do nothing
        if (GameState.GetCurrentState() != GAMESTATE.DIALOGUE) {
            return;
        }

        // Check for space or enter
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) {

            Debug.Log("Space or enter pressed!");

            Advance();
        }

    }

    // Starts conversation of given lines and marks down the given action to be dispatched
    // once the conversation is over.
    // NOTE: At this point only allows for linear conversations.
    public void StartConversation(List<string> newLines, Action action = null) {

        if (newLines == null || newLines.Count == 0) {
            Debug.LogWarning("DialogueMaster.StartConversation called with null or empty list. Returning without change.");
            return;
        }

        // Set gamestate to dialogue
        GameState.SetNewState(GAMESTATE.DIALOGUE);

        // Store lines
        lines = newLines;

        // Init index
        index = 0;

        // Store action
        afterDialogueAction = action;

        // Enter dialogue UI with first line
        uiHandler.EnterDialogueMode(lines[index]);

    }

    // Advance conversation
    private void Advance() {

        if (lines == null || lines.Count == 0) {
            Debug.LogWarning("DialogueMaster.Advance called with null or empty list. Returning without change.");
            return;
        }

        index++;

        // If there are no more lines
        if (lines.Count == index) {
            EndConversation();
            return;
        }

        uiHandler.ShowDialogueText(lines[index]);
        
    }

    // Called by Advance when there are no more lines
    private void EndConversation() {

        // Flush lines
        lines = null;

        // Exit dialogue UI
        uiHandler.ExitDialogueMode();

        // Dispatch action if there is one and reset
        if (afterDialogueAction != null) {

            QuestSystem.UpdateQuests(afterDialogueAction);

            afterDialogueAction = null;
        }

        // Set gamestate back to playing
        GameState.SetNewState(GAMESTATE.PLAYING);

    }

}
