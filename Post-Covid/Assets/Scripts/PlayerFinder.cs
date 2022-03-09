using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerFinder
{
    // Static method for finding the player. Returns the player GameObject or null if it was not found.
    public static GameObject FindPlayer() {

        GameObject player = GameObject.FindWithTag("Player");

        //Debug.Log("FindPlayer called! Player found:");
        //Debug.Log(player);

        return player;
    }
}
