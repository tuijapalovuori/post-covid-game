using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Quest object represents a single quest.

// The Quest class keeps track of the status of the quest it
// represents: whether it has been started, what stage it is currently in
// and whether it has been completed.

// The construction of a Quest requires three things:
// 1. A title for the quest
// 2. An Action which starts the quest
// 3. A list of QuestStages the quest is made up of.

// NOTE: Only linear quests (sequence of QuestStages) are currently possible!

public class Quest
{
    public string Title { get; }
    public bool IsComplete { get; private set; }

    private Action startingAction;
    private bool started;

    private int currentStage;
    private List<QuestStage> questStages;

    public Quest(string questTitle, Action startAction, List<QuestStage> quest_stages) {

        Title = questTitle;
        startingAction = startAction;
        questStages = quest_stages;

        started = false;
        IsComplete = false;
        currentStage = 0;
    }

    // For UI
    public string GetCurrentStageDescription() {
        return questStages[currentStage].Description;
    }

    // For UI
    public string GetCurrentStageProgress() {
        return questStages[currentStage].GetProgressRendered();
    }

    // For UI
    public bool CurrentStageIsSingleAction() {
        return questStages[currentStage].IsSingleAction();
    }

    // Tries to advance quest with given action. Return value tells whether this was successful.
    // Out parameter was_started tells whether the action given started this quest.
    public bool TryAdvanceQuest(Action action, out bool was_started) {

        // Debug.Log("Quest.TryAdvanceQuest called. Quest name: " + Title);

        was_started = false;

        // If the quest is complete, don't bother checking
        if (IsComplete) {
            return false;
        }

        // If the quest has not been started, check if this action starts it
        if (!started) {

            // If the action starts it, mark quest as started and return
            // true with was_started flag up. Otherwise return false
            if ( startingAction.Equals(action) ) {

                Debug.Log("New quest started! Quest name: " + Title);

                started = true;

                was_started = true;

                return true;

            } else {

                return false;
            }
        }

        // Otherwise the quest is ongoing

        // Try to advance stage
        if (questStages[currentStage].TryAdvanceStage(action)) {

            //Debug.Log("Quest.TryAdvanceQuest: Stage was advanced! Stage description: " + questStages[currentStage].Description);

            // Check if stage is complete
            if (questStages[currentStage].IsComplete) {

                // Move to next stage
                currentStage++;

                // Check if quest is complete
                if (currentStage == questStages.Count) {

                    IsComplete = true;
                }
            }

            Debug.Log("Quest advanced! Quest name: " + Title);

            return true;
        }

        //Debug.Log("Quest.TryAdvanceQuest: Stage was not advanced. Stage description: " + questStages[currentStage].Description);

        return false;
    }

}
