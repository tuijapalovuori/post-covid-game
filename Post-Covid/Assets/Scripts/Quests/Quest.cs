using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The quest object represents a single quest.
// It contains the stages of the quest (NOTE: this allows for linear quests only
// at the moment), the current stage index, and the status of whether the quest
// has been completed or not.

public class Quest
{
    public string Title { get; }
    public bool IsComplete { get; private set; }

    private int currentStage;
    private List<QuestStage> questStages;

    public Quest(string questTitle, List<QuestStage> quest_stages) {

        Title = questTitle;
        questStages = quest_stages;

        IsComplete = false;
        currentStage = 0;
    }

    // Tries to advance quest with given action. Return value tells whether this was successful.
    public bool TryAdvanceQuest(Action action) {

        // Debug.Log("Quest.TryAdvanceQuest called. Quest name: " + Title);

        // If the quest is complete, don't bother checking
        if (IsComplete) {
            return false;
        }

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

            return true;
        }

        //Debug.Log("Quest.TryAdvanceQuest: Stage was not advanced. Stage description: " + questStages[currentStage].Description);

        return false;
    }

}
