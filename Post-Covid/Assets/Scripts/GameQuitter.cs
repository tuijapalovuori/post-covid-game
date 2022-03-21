using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows quitting the game by pressing the Esc key (in the build, not in the editor).

public class GameQuitter : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            //Debug.Log("Esc pressed, quitting");

            Application.Quit();
        }
    }
}
