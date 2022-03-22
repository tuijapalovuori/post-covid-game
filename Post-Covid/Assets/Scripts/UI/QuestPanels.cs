using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// QuestPanels is a script with an interface for showing, updating
// and hiding the quest panels.

public class QuestPanels : MonoBehaviour
{
    public QuestListPanel questListPanel;

    public bool IsExpanded { get; private set; }

    public void Awake() {

        // Collapse at beginning
        Collapse();
    }

    // Make panels visible
    public virtual void Show() {

        gameObject.SetActive(true);
    }

    // Hide panels
    public virtual void Hide() {

        gameObject.SetActive(false);
    }

    // Show quest list panel
    public virtual void Expand() {

        IsExpanded = true;
        questListPanel.Show();
    }

    // Show quest list panel
    public virtual void Collapse() {

        IsExpanded = false;
        questListPanel.Hide();
    }

    // Getter for QuestListPanel so its methods can be used directly
    // instead of having to go through an additional level of interface
    public QuestListPanel GetQuestListPanel() {
        return questListPanel;
    }
}
