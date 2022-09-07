using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAction : BaseAction
{

    [TextArea] [SerializeField] private string dialogue;
    

    public void Action()
    {
        DialogueBox.Instance.SetDialogue(dialogue);
    }


}
