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

        new Quest( "Getting Out There", new Action( ACTION_TYPE.GAME_STARTED ), new List<QuestStage> {

            new QuestStage(
                
                "You haven't seen Mike face to face in a long time. Go greet him.",

                new List<Action>{
                    new Action( ACTION_TYPE.TALKED_TO, "MIKE" )
                },

                new List<DialogueChange>{

                    new DialogueChange(
                        "MIKE",
                        new List<string>{ "Did you give Jane her mask yet?" }
                    ),

                    new DialogueChange(
                        "JANE",
                        new List<string>{
                            "(You give her the tiger-patterned mask.)",
                            "Oh! My mask! Thank you so much!",
                            "Mike was the one that picked it up? Well, thank him for me, then.",
                            "See you at the party tonight!"
                        }
                    )
                }
            ),

            new QuestStage(

                "Find Jane and give her her mask back.",

                new List<Action>{
                    new Action( ACTION_TYPE.TALKED_TO, "JANE" )
                },

                new List<DialogueChange>{

                    new DialogueChange(
                        "MIKE",
                        new List<string>{
                            "You gave Jane her mask back? That's great! I knew I could count on you.",
                            "Listen, I gotta go soon, but I'll see you again at the party. Bye for now!"
                        }
                    ),

                    new DialogueChange(
                        "JANE",
                        new List<string>{ "(She doesn't seem to have anything else to say.)" }
                    )
                }
            ),

            new QuestStage(
                
                "Tell Mike you gave the mask to Jane.",
                
                new List<Action>{ new Action( ACTION_TYPE.TALKED_TO, "MIKE" )},

                new DialogueChange( "MIKE", new List<string>{ "(He doesn't seem to have anything else to say.)" } )
            ),

        } ),

        new Quest( "Find birthday guests", new Action( ACTION_TYPE.GAME_STARTED ), new List<QuestStage> {
            new QuestStage( "Find three more of your friends and tell them you're having a party. (Mike and Jane are already coming!)", new List<Action>{
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
