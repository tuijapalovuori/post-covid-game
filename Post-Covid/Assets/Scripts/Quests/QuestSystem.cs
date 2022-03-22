using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// QuestSystem is a global static class which
// 1. Lists all quests in the game
// 2. Keep track of the status of each quest
// 3. Advances quests if it receives an action
// that may advance a quest
// 4. Informs the UI about this

public static class QuestSystem
{
    private static UIHandler uiHandler = null;

    // List of all Quests
    private static List<Quest> ALL_QUESTS = new List<Quest> {

        new Quest( "Test Quest", new Action( ACTION_TYPE.GAME_STARTED ), new List<QuestStage> {
            new QuestStage( "Find NPC 1 and talk to them.", new List<Action>{
                new Action( ACTION_TYPE.TALKED_TO, "NPC1" )
            } ),
            new QuestStage( "Find NPC 2 and talk to them.", new List<Action>{
                new Action( ACTION_TYPE.TALKED_TO, "NPC2" )
            } ),
            new QuestStage( "Find NPC 3 and talk to them.", new List<Action>{
                new Action( ACTION_TYPE.TALKED_TO, "NPC3" )
            } )
        } ),

        new Quest( "Find birthday guests", new Action( ACTION_TYPE.GAME_STARTED ), new List<QuestStage> {
            new QuestStage( "Find all 3 of your friends and tell them you're having a party.", new List<Action>{
                new Action( ACTION_TYPE.TALKED_TO, "FRIEND1" ),
                new Action( ACTION_TYPE.TALKED_TO, "FRIEND2" ),
                new Action( ACTION_TYPE.TALKED_TO, "FRIEND3" )
            } )
        } ),

    };

    // Function that attempts to fetch the UI Handler.
    // Returns true if successful, false if there was a failure.
    private static bool FetchUIHandler() {

        uiHandler = ComponentFinder.FindUIHandler();

        if (uiHandler == null) {
            return false;
        }

        return true;
    }

    public static void UpdateQuests(Action action) {

        // Make sure UI Handler is found
        if (uiHandler == null && !FetchUIHandler()) {
            Debug.LogError("QuestSystem.UpdateQuests: UI Handler could not be found. Returning without change.");
            return;
        }

        /*
        Debug.Log("QuestSystem.UpdateQuests called!");
        Debug.Log("Action type: " + action.Type);
        Debug.Log("Action target: " + action.TargetID);
        */

        // Debug.Log("Amount of quests in ALL_QUESTS: " + ALL_QUESTS.Count);

        bool was_started = false;

        foreach (Quest quest in ALL_QUESTS) {

            if ( quest.TryAdvanceQuest(action, out was_started) ) {

                // If the quest was just started, add it to the UI
                if (was_started) {

                    uiHandler.AddQuest(quest);
                }
            }
        }

        // Update quests in UI
        uiHandler.UpdateQuests();

    }
}
