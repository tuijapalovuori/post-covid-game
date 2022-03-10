using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public DialoguePanel dialoguePanel;
    public HintPanel hintPanel;

    private bool dialogueOngoing = false;

    private void Awake() {

        // In case UI is not hidden, hide it
        dialoguePanel.Hide();
        hintPanel.Hide();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set quit hint panel
        hintPanel.Show("Press Esc to quit.", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO check inputs
    }
}
