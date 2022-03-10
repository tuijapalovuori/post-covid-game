using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Concrete interactable used for testing.

public class TestInteractable : Interactable
{
    public override void InteractionAreaEntered() {
        InteractionMaster.ApplyForFocus(this);
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

        // Check for E key
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("E key pressed!");
            TriggerInteraction();
        }
    }

    protected override void TriggerInteraction() {
        Debug.Log("Interaction triggered!");
        // TODO functionality
    }
}
