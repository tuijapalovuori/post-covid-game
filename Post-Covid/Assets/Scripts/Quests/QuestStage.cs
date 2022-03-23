using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A QuestStage object represents one stage of a quest.
// It has a list of required actions (may be simply 1)
// and a list that keeps track of the completed actions.
// NOTE: Sets would probably be better than lists for performance

public class QuestStage
{
    // Textual description of stage objective
    public string Description { get; }

    // Whether this stage is complete
    public bool IsComplete { get; private set; }

    // List of actions required to pass this stage
    private readonly List<Action> requiredActions;

    // List of actions that have been completed
    private List<Action> completedActions;

    public QuestStage(string desc, List<Action> required_actions) {

        Description = desc;

        requiredActions = required_actions;
        completedActions = new List<Action>();

        IsComplete = false;
    }

    // Checks whether the given action would advance this quest at its current state
    public bool TryAdvanceStage(Action action) {

        //Debug.Log("QuestStage.TryAdvanceStage called. Quest name: " + Description);

        if (IsComplete) {
            Debug.LogWarning("QuestStage.TryAdvanceStage: This stage is already complete. Returning false.");
            return false;
        }

        // Check if the action would advance the current stage of the quest

        bool would_advance = false;

        foreach ( Action req_action in requiredActions ) {

            /*
            Debug.Log("QuestStage.TryAdvanceStage: Comparing incoming action to required actions.");
            Debug.Log("Incoming action: " + action.Type + ", " + action.TargetID);
            Debug.Log("Required action: " + req_action.Type + ", " + req_action.TargetID);
            */

            if ( req_action.Equals(action) ) {

                //Debug.Log("Match!");

                would_advance = true;
            } /*else {
                Debug.Log("No match.");
            }*/
        }

        // If the action did not match any required action
        if (!would_advance) {
            return false;
        }

        // If the action was a match, we still need to make sure it has not already happened.
        // If it has, return false.
        foreach (Action comp_action in completedActions) {

            if (comp_action.Equals(action)) {
                return false;
            }
        }

        // If the action is a match and it has not happened yet, mark it as having happened

        completedActions.Add(action);

        Debug.Log("QuestStage.TryAdvanceStage: Stage advanced. Stage progress: " + GetProgressRendered());

        // If the amount of required and completed actions are equal, the stage is complete
        // NOTE: This assumes that the completed actions only include actions from the
        // required actions and that there are no multiples of the same action,
        // which should always be the case in this architecture, but it's worth noting
        if ( requiredActions.Count == completedActions.Count ) {

            Debug.Log("QuestStage.TryAdvanceStage: Stage completed. Stage description: " + Description);
            IsComplete = true;
        }

        // Return true as the action did advance the stage
        return true;
    }

    // A method to return a textual representation of the current progress (in form (x/y))
    public string GetProgressRendered() {
        return "(" + completedActions.Count + "/" + requiredActions.Count + ")";
    }

    // Returns whether this stage only requires one action
    // (Used by UI to decide whether or not to show stage progress)
    public bool IsSingleAction() {
        return requiredActions.Count == 1;
    }
}
