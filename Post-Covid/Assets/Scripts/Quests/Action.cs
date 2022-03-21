using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ACTION_TYPE describes the type of an action
public enum ACTION_TYPE {
    TALKED_TO,
    INTERACTED_WITH,
    BOUGHT_ITEM
}

// The Action object describes an individual action
// which may advance a quest or quests
public class Action
{
    public ACTION_TYPE Type { get; }
    public string TargetID { get; }

    public Action(ACTION_TYPE type, string targetID = "") {
        Type = type;
        TargetID = targetID;
    }

    // Returns whether the given action is equal to this one
    public bool Equals(Action action) {
        return (Type == action.Type) && (TargetID == action.TargetID);
    }
}
