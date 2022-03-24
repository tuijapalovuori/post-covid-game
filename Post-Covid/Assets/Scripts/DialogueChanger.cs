using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A DialogueChange object describes
// a change in dialogue for a character
public class DialogueChange {

    public string TargetID { get; }
    public List<string> Dialogue { get; }

    public DialogueChange(string targetID, List<string> dialogue) {
        TargetID = targetID;
        Dialogue = dialogue;
    }
}

// DialogueChanger is a public static class which is used to
// dynamically change the dialogue of characters.

public static class DialogueChanger
{
    // Execute one dialogue change
    public static void ChangeDialogue( DialogueChange dialogueChange ) {

        if (dialogueChange == null) {
            Debug.LogWarning("DialogueChanger.ChangeDialogue: Given change is null. Returning.");
            return;
        }

        NPCInteractable npc = FindCharacter(dialogueChange.TargetID);

        if (npc == null) {
            Debug.LogWarning("DialogueChanger.ChangeDialogue: NPC with target ID " + dialogueChange.TargetID + " was not found. Returning.");
            return;
        }

        npc.ChangeDialogue(dialogueChange.Dialogue);
    }

    // Execute a list of dialogue changes (in order)
    public static void ChangeDialogue(List<DialogueChange> dialogueChanges) {

        if (dialogueChanges == null) {
            Debug.LogWarning("DialogueChanger.ChangeDialogue: Given change list is null. Returning.");
            return;
        }

        foreach (DialogueChange change in dialogueChanges) {
            ChangeDialogue(change);
        }
    }

    // Help method to find the NPCInteractable of a specific
    // character programmatically. Returns null if character
    // could not be found.
    private static NPCInteractable FindCharacter(string ID) {

        GameObject[] npcGOs = GameObject.FindGameObjectsWithTag("InteractableNPC");

        Debug.Log("DialogueChanger.FindCharacter: Found " + npcGOs.Length + "GOs with tag InteractableNPC.");

        for (int i = 0; i < npcGOs.Length; i++) {

            NPCInteractable npc = npcGOs[i].GetComponent<NPCInteractable>();

            if (npc == null) {
                Debug.LogWarning("DialogueChanger.FindCharacter: There is a GameObject tagged InteractableNPC without a InteractableNPC component. Skipping it in search.");
                continue;
            }

            // If this is the character
            if (npc.id == ID) {
                return npc;
            }

        }

        return null;
    }
}
