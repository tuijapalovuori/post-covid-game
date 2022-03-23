using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StrangerDialogueBank {

    private static List<string> DIALOGUE = new List<string> {
        "Hey, watch where you're going.",
        "Nice weather we're having today.",
        "Finally, we can go back to normal life.",
        "It would be a great idea to have party tonight...",
        "Did you see those awful videos on TikTok?",
        "The pandemic's finally over. High time.",
        "Can't talk now. Busy.",
    };

    // Get random quote from pool of quotes
    public static string GetRandomQuote() {
        return DIALOGUE[ Random.Range( 0, DIALOGUE.Count ) ];
    }

    
}
