using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class has a very simple purpose: to dispatch a GAME_STARTED
// action to QuestSystem at the very beginning of the game.

public class StartActionDispatcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StartActionDispatcher.Start called, dispatching GAME_STARTED action");

        QuestSystem.UpdateQuests( new Action( ACTION_TYPE.GAME_STARTED ) );
    }

}
