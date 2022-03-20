using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Concrete interactable used for testing.

public class TestInteractable : Interactable {

    [SerializeField]
    public string interactionPrompt = InteractionMaster.TALK_PROMPT;

    [SerializeField]
    public List<string> dialogue;

    private DialogueMaster dialogueMaster;

    private void Awake() {

        // Find dialogue master

        GameObject dialogueMasterGO = GameObject.FindWithTag("DialogueMaster");

        if (dialogueMasterGO == null) {
            Debug.LogError("TestInteractable.Awake: DialogueMaster's GO could not be found.");
        }

        dialogueMaster = dialogueMasterGO.GetComponent<DialogueMaster>();

        if (dialogueMaster == null) {
            Debug.LogError("TestInteractable.Awake: DialogueMaster component could not be found from DialogueMaster's GO.");
        }

    }

    public override void InteractionAreaEntered() {
        InteractionMaster.ApplyForFocus(this, interactionPrompt);
    }

    public override void InteractionAreaExited() {
        InteractionMaster.LeaveFocus(this);
    }

    // Method for finding out if this interactable
    // is the one currently in focus
    private bool IsInFocus() {
        return InteractionMaster.GetInteractableInFocus() == this;
    }

    private void Update() {

        // If this object isn't in focus, do nothing
        if (!IsInFocus()) {
            return;
        }

        // Check for E key (if inputs allowed)
        if ( Input.GetKeyDown(KeyCode.E) && ( GameState.GetCurrentState() == GAMESTATE.PLAYING) ) {
            Debug.Log("E key pressed!");
            TriggerInteraction();
        }
    }

    protected override void TriggerInteraction() {
        Debug.Log("Interaction triggered!");

        dialogueMaster.StartConversation(dialogue);
    }
}
