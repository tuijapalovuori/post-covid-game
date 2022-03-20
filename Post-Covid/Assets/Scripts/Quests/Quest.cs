using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The quest object represents a single quest.
// It contains the steps of the quest (NOTE: this allows for linear quests only
// at the moment), the current step index, and the status of whether the quest
// has been completed or not.

public class Quest
{
    private bool isComplete;
    private int currentStep;
    private List<Action> questSteps;

    public Quest(List<Action> quest_steps) {
        questSteps = quest_steps;

        isComplete = false;
        currentStep = 0;
    }

    // Checks whether the given action would advance this quest at its current state
    public bool ActionAdvancesQuest(Action action) {

        if (isComplete) {
            Debug.LogWarning("Quest.ActionAdvancesQuest: This quest is already complete. Returning false.");
            return false;
        }

        if (action.Equals(questSteps[currentStep])) {
            return true;
        }

        return false;
    }

    // Advances quest with the given action (if it is valid)
    public void AdvanceQuest(Action action) {

        if (isComplete) {
            Debug.LogWarning("Quest.AdvanceQuest: This quest is already complete. Returning.");
            return;
        }

        if (!action.Equals(questSteps[currentStep])) {
            Debug.LogWarning("Quest.AdvanceQuest: Given action does not advance quest. Returning.");
            return;
        }

        currentStep++;

        if (currentStep == questSteps.Count) {
            isComplete = true;
            return;
        }

    }

    // Returns whether this quest is complete
    public bool IsComplete() {

        return isComplete;
    }
}
