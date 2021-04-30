using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    bool cStarted = false;
    public int count = 0;

    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogue);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cStarted == false)
        {
            TriggerDialogue();
            cStarted = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
            count++;
        }
    }
}