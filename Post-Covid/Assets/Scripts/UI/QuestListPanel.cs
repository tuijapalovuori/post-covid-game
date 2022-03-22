using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestListPanel : MonoBehaviour {

    // Panel text
    public TextMeshProUGUI panelText;

    // List of quests being displayed
    private List<Quest> quests;

    private readonly string NO_QUESTS_MESSAGE = "There are currently no ongoing quests.";

    public void Awake() {

        // No ongoing quests at beginning of lifetime
        panelText.text = NO_QUESTS_MESSAGE;
    }

    // Make panel visible
    public void Show() {

        gameObject.SetActive(true);
    }

    // Hide panel
    public void Hide() {

        gameObject.SetActive(false);
    }

    // Add quest
    public void AddQuest(Quest newQuest) {

        quests.Add(newQuest);
        UpdateQuests();
    }

    // Update display of quests
    // (checks the Quests directly, hence no arguments)
    public void UpdateQuests() {

        // TODO go through quests and construct
        // string to display
    }

}
