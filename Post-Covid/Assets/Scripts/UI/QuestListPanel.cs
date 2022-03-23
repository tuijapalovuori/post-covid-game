using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestListPanel : MonoBehaviour {

    // Panel text
    public TextMeshProUGUI panelText;

    // List of quests being displayed
    private List<Quest> quests = new List<Quest>();

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

        Debug.Log("QuestListPanel.AddQuest called. New quest title: " + newQuest.Title);

        quests.Add(newQuest);
        UpdateQuests();
    }

    // Update display of quests
    // (checks the Quests directly, hence no arguments)
    public void UpdateQuests() {

        Debug.Log("QuestListPanel.UpdateQuests called!");

        // Remove all completed quests
        // TODO test!
        quests.RemoveAll( IsComplete );

        // Render quests
        RenderQuests();
    }

    // Help method for removal
    private bool IsComplete(Quest quest) {
        return quest.IsComplete;
    }

    // Renders current quests in text form in the quest panel
    private void RenderQuests() {

        // If there are no quests, display no quests message
        if (quests.Count == 0) {
            panelText.text = NO_QUESTS_MESSAGE;
            return;
        }

        // Create text representation of each quest

        List<string> questsInText = new List<string>();

        foreach (Quest quest in quests) {
            questsInText.Add(RenderQuest(quest));
        }

        // Join text representations together with newlines
        string finalText = string.Join("\n\n", questsInText);

        Debug.Log(finalText);

        // Show final text in panel
        panelText.text = finalText;
    }

    // Returns string representation of single quest
    private string RenderQuest(Quest quest) {

        string titleText = "<b>" + quest.Title + "</b>";

        string stageDesc = quest.GetCurrentStageDescription();

        string finalText = titleText + "\n" + stageDesc;

        // Only add progress if there is more than one action required (in total)
        // to progress the current stage
        if (!quest.CurrentStageIsSingleAction()) {
            finalText = finalText + " " + quest.GetCurrentStageProgress();
        }

        return finalText;
    }

}
