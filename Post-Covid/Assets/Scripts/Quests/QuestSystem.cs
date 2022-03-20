using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// QuestSystem is a global static class which
// 1. Lists all quests in the game
// 2. Keep track of the status of each quest
// 3. Advances quests if it receives an action
// that may advance a quest

public static class QuestSystem
{

    public static void UpdateQuests(Action action)
    {

        Debug.Log("QuestSystem.UpdateQuests called!");
        Debug.Log("Action type: " + action.Type);
        Debug.Log("Action target: " + action.TargetID);

        // TODO go through quests, see if the action advances any of them,
        // advance them if so, inform player if any was completed (debug print for now)
    }
}
