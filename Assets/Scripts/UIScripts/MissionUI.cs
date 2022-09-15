using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour
{
    [SerializeField] GameObject missionHint;
    [SerializeField] CanvasGroup missionCanvas;
    [SerializeField, Min(0)] float animationSpeed;
    [SerializeField] float secondsToDisappear;
    [SerializeField] List<string> missions;
    [SerializeField] TextMeshProUGUI text;
    Queue<string> missionsQueue;

    float timeLeft;
    bool isActive;

    void Start()
    {
        if (missions.Count != 0) missionsQueue = new Queue<string>(missions);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(Hide());
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            missionHint.SetActive(false);
            StartCoroutine(Show());
        }
        if (isActive)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                isActive = false;
                StartCoroutine(Hide());
            }
        }
    }

    void NextMission() => text.text = missionsQueue.Dequeue();

    IEnumerator Show()
    {
        while (missionCanvas.alpha < 1)
        {
            missionCanvas.alpha += animationSpeed;
            yield return 0;
        }
        missionCanvas.alpha = 1;
        isActive = true;
        timeLeft = secondsToDisappear;
    }
    IEnumerator Hide()
    {
        while (missionCanvas.alpha > 0)
        {
            missionCanvas.alpha -= animationSpeed;
            yield return 0;
        }
        missionCanvas.alpha = 0;
        isActive = false;
    }
}