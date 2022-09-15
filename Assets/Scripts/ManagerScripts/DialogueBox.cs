using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public static DialogueBox Instance { get; private set; }

    [SerializeField] TextMeshProUGUI _textMeshPro;
    [SerializeField] int CharactersPerSecond;
    [SerializeField] int timeToDissapear;
    float timeLeft;
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTextPrinted)
        {
            SkipText();
        }
        if (isTextPrinted)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                _textMeshPro.text = " ";
            }
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
        timeLeft = timeToDissapear;

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
        timeLeft = timeToDissapear;
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
