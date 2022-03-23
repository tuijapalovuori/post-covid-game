using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    // Attached interactable aka the interactable that this area belongs to
    public Interactable interactable;

    // When the collider is entered
    private void OnTriggerEnter(Collider other) {

        // Ignore if not the player
        if (other.gameObject.tag != "Player") {
            return;
        }

      //  Debug.Log("Interaction area entered!");

        interactable.InteractionAreaEntered();
    }

    // When the collider is exited
    private void OnTriggerExit(Collider other) {

        // Ignore if not the player
        if (other.gameObject.tag != "Player") {
            return;
        }

       // Debug.Log("Interaction area exited!");

        interactable.InteractionAreaExited();
    }
}
