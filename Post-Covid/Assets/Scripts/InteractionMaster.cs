using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// InteractionMaster is a singleton which is tasked with keeping track of 
// global information related to interactions, such as which interactable
// is currently in focus.

public static class InteractionMaster
{
    private static Interactable _interactable_in_focus = null;

    // Returns the current interactable in focus
    public static Interactable GetInteractableInFocus() {
        return _interactable_in_focus;
    }

    // By calling this method and passing itself, an interactable applies
    // for the position of the interactable in focus - it may or may not
    // get it. The return value is true if the interactablee gets focus
    // and false if not.
    // In the current implementation, any interactable that applies for focus
    // receives it, but it is possible to implement an algorithm that chooses
    // between the old focus and new focus based on something like distance or prirority.
    public static bool ApplyForFocus(Interactable interactable) {
        _interactable_in_focus = interactable;
        return true;
    }

    // By calling this method, an interactable signals that it should no longer
    // be in focus. If the current interactable in focus is not the interactable
    // that calls this function, no change is made.
    public static void LeaveFocus(Interactable interactable) {

        if (_interactable_in_focus == interactable) {
            _interactable_in_focus = null;
        }
    }
}
