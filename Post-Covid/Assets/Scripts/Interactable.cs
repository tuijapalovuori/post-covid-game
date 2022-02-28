using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interactable is an abstract superclass of all interactable objects.
// Its methods are to be called by InteractionArea.

public abstract class Interactable : MonoBehaviour
{
    // Called by InteractionArea
    public abstract void InteractionAreaEntered();

    // Called by InteractionArea
    public abstract void InteractionAreaExited();

    protected abstract void TriggerInteraction();

}
