using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DialogueBuffer is a script that Interactables
// with dialogue give their dialogue to. It holds
// the full dialogue of the Interactable in memory
// and calls UIHandler to let it know there is new
// dialogue. The UIHandler will then call NextLine
// to get the next line of dialogue until it runs out.

public class DialogueBuffer : MonoBehaviour {

    public UIHandler uihandler;
    private List<string> lines;
    private int index;

    public void GiveLines(List<string> newlines) {

        index = 0;
        lines = newlines;

        uihandler.BeginDialogue(this);
    }

    // Return next line in buffer. Return null if there are
    // no further lines or no lines at all.
    public string GetNextLine() {

        if (lines == null || index >= lines.Count) {
            return null;
        }

        string line = lines[index];

        index++;

        return line;
        
    }

}
