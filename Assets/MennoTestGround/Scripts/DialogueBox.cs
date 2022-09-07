using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public static DialogueBox Instance { get; private set; }

    [SerializeField] TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Already one DialogueBox in scene, deleting" + gameObject);
            Destroy(gameObject);
        }

        Instance = this;
    }

    public void Start()
    {
        SetDialogue("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
    }

    public void SetDialogue(string dialogue)
    {
        _textMeshPro.text = dialogue;
    }

}
