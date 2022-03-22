using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// InteractionMaster is a singleton which is tasked with keeping track of
// which interactable is currently in focus and either allowing or disallowing
// the focus to change to another interactable. It also takes care of showing
// the UI interaction prompt respectively.
// It also provides constants like prompt text strings.

public static class InteractionMaster
{
    public static readonly string TALK_PROMPT = "Talk (E)";
    public static readonly string INTERACT_PROMPT = "Interact (E)";

    private static Interactable _interactable_in_focus = null;

    private static UIHandler _ui_handler = null;

    // Function that attempts to fetch the UI Handler's reference.
    // Returns true if successful, false if there was a failure.
    private static bool FetchUIHandler() {

        _ui_handler = ComponentFinder.FindUIHandler();

        if (_ui_handler == null) {
            return false;
        }

        return true;
    }

    // Returns the current interactable in focus
    public static Interactable GetInteractableInFocus() {
        return _interactable_in_focus;
    }

    // By calling this method and passing itself and an interaction prompt string,
    // an interactable applies for the position of the interactable in focus
    // - it may or may not get it. The return value is true if the interactable gets focus
    // and false if not. If there is no promptText provided, no change will be made to the 
    // prompt panel in the UI.
    // In the current implementation, any interactable that applies for focus
    // receives it (unless an error occurs), but it is possible to implement an algorithm that chooses
    // between the old focus and new focus based on something like distance or priority.
    public static bool ApplyForFocus(Interactable interactable, string promptText = null) {

        _interactable_in_focus = interactable;

        // If there is no UI handler ref and fetching it fails,
        // log a warning and return failure
        if (_ui_handler == null && !FetchUIHandler()) {

            Debug.LogError("Interaction.ApplyForFocus: UI Handler could not be found. Return failure.");

            return false;
        }

        if (promptText == null) {

            // If no promptText was given, hide prompt panel
            _ui_handler.HidePrompt();

        } else {

            // If promptText was given, show the panel with promptText
            _ui_handler.ShowPrompt(promptText);

        }

        return true;
    }

    // By calling this method, an interactable signals that it should no longer
    // be in focus. If the current interactable in focus is not the interactable
    // that calls this function, no change is made.
    public static void LeaveFocus(Interactable interactable) {

        if (_interactable_in_focus == interactable) {

            _interactable_in_focus = null;

            // Hide prompt panel
            _ui_handler.HidePrompt();
        }
    }
}
