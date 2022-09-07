using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public static DialogueBox Instance { get; private set; }

    [SerializeField] TextMeshProUGUI _textMeshPro;
    [SerializeField] int CharactersPerSecond;
    IEnumerator WriteTextCoroutine;
    char[] letters;

    bool isTextPrinted = true;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Already one DialogueBox in scene, deleting" + gameObject);
            Destroy(gameObject);
        }

        Instance = this;
        WriteTextCoroutine = WriteText();
    }

    public void Start()
    {
        //SetDialogue("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTextPrinted)
        {
            SkipText();
        }
    }


    /// <summary>
    /// Stops the coroutine and prints out the whole text
    /// </summary>
    void SkipText()
    {
        StopCoroutine("WriteText");
        _textMeshPro.text = letters.ArrayToString();
        isTextPrinted = true;

    }

    /// <summary>
    /// Coroutine function to print text letter by letter
    /// </summary>
    /// <returns></returns>
    IEnumerator WriteText()
    {
        isTextPrinted = false;
        for (int i = 0; i < letters.Length; i++)
        {
            _textMeshPro.text += letters[i];
            yield return new WaitForSeconds(1f / CharactersPerSecond);
        }
        isTextPrinted = true;
    }

    /// <summary>
    /// Start dialogue print on the screen
    /// </summary>
    /// <param name="dialogue">String with the text to show</param>
    public void SetDialogue(string dialogue)
    {
        if (!isTextPrinted)
        {
            return;
        }
        _textMeshPro.text = " ";
        letters = dialogue.ToCharArray();
        StartCoroutine("WriteText");
    }
   

}
