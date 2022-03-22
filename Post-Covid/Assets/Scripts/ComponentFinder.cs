using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ComponentFinder is a static class with methods designed to
// help components and objects find each other more easily
// and to lessen the amount of repeated code in components.

public static class ComponentFinder
{
    // Function that attempts to fetch the UI Handler and return it.
    // Returns null if unsuccessful.
    public static UIHandler FindUIHandler() {

        GameObject UIHandlerGO = GameObject.FindWithTag("UIHandler");

        if (UIHandlerGO == null) {
            Debug.LogError("InteractionMaster.FetchUIHandlerRef: UIHandler's GO could not be found.");
            return null;
        }

        UIHandler uiHandler = UIHandlerGO.GetComponent<UIHandler>();

        if (uiHandler == null) {
            Debug.LogError("InteractionMaster.FetchUIHandlerRef: UIHandler component could not be found from UIHandler's GO.");
            return null;
        }

        return uiHandler;
    }
}
