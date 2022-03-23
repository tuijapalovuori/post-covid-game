using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAMESTATE {
    PLAYING,
    DIALOGUE,
    BAD_STATE
}

// GameState is a static class which keeps track of the game's current state.
// Right now this basically means that it keeps track of whether dialogue
// is ongoing or not.

public static class GameState
{
    private static GAMESTATE currentState = GAMESTATE.PLAYING;

    public static GAMESTATE GetCurrentState() {
        return currentState;
    }

    public static void SetNewState( GAMESTATE newState ) {

    //    Debug.Log("Setting new game state: " + newState);

        currentState = newState;
    }

}
