using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour
{
    public static MissionUI Instance { get; private set; }

    [SerializeField] GameObject missionHint;
    [SerializeField] CanvasGroup missionCanvas;
    [SerializeField, Min(0)] float animationSpeed;
    [SerializeField] float secondsToDisappear;
    [SerializeField] List<string> missions;
    [SerializeField] TextMeshProUGUI text;
    Queue<string> missionsQueue;

    float timeLeft;
    bool isActive;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Can't be two MissionUI, Destroying" + gameObject);
            Destroy(this);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        if (missions.Count != 0) missionsQueue = new Queue<string>(missions);
        NextMission();
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
            ShowMission();
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


    public void ShowMission()
    {
        missionHint.SetActive(false);
        StartCoroutine(Show());
    }

    public void NextMission()
    {
        text.text = missionsQueue.Dequeue();
        ShowMission();
    }
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
