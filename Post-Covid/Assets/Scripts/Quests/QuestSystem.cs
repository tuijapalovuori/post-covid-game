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
    // List of all Quests
    private static List<Quest> ALL_QUESTS = new List<Quest> {

        new Quest( "My First Quest", new List<QuestStage> {
            new QuestStage( "Find NPC 1 and talk to them.", new List<Action>{
                new Action( ACTION_TYPE.TALKED_TO, "NPC1" )
            } )
        } ),

        new Quest( "Find birthday guests", new List<QuestStage> {
            new QuestStage( "Find all 5 of your friends and tell them you're having a party.", new List<Action>{
                new Action( ACTION_TYPE.TALKED_TO, "FRIEND1" ),
                new Action( ACTION_TYPE.TALKED_TO, "FRIEND2" ),
                new Action( ACTION_TYPE.TALKED_TO, "FRIEND3" ),
                new Action( ACTION_TYPE.TALKED_TO, "FRIEND4" ),
                new Action( ACTION_TYPE.TALKED_TO, "FRIEND5" ),
            } )
        } ),

    };

    public static void UpdateQuests(Action action) {

        Debug.Log("QuestSystem.UpdateQuests called!");
        Debug.Log("Action type: " + action.Type);
        Debug.Log("Action target: " + action.TargetID);

        Debug.Log("Amount of quests in ALL_QUESTS: " + ALL_QUESTS.Count);

        foreach (Quest quest in ALL_QUESTS) {

            if ( quest.TryAdvanceQuest(action) ) {

                Debug.Log("Quest advanced! Quest name: " + quest.Title);

                // TODO: inform UI
            }

        }

    }
}
