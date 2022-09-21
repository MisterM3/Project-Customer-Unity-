using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralUI : MonoBehaviour
{
    bool isPaused;
    [SerializeField] bool startScreen = false;
    public enum Panels { Navigation = 0, Options = 1, Controls = 2 };
    [Header("Panels")]
    [SerializeField] GameObject darkBackground;
    [SerializeField] GameObject navigationPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject controlsPanel;
    [SerializeField] GameObject ActiveUIPanel;

    [Header("Properties")]
    [SerializeField] bool hideCursor = true;
    Dictionary<Panels, GameObject> panels = new Dictionary<Panels, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        panels.Add(Panels.Navigation, navigationPanel);
        panels.Add(Panels.Options, optionsPanel);
        panels.Add(Panels.Controls, controlsPanel);

    }

    // Update is called once per frame
    void Update()
    {
        if (startScreen) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Resume()
    {

        Time.timeScale = 1;
        darkBackground.SetActive(false);
        TurnOffPanels();
        ActiveUIPanel.SetActive(true);
        //   Cursor.lockState = hideCursor ? CursorLockMode.Locked : CursorLockMode.None;
        isPaused = false;
        if (startScreen) return;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        darkBackground.SetActive(true);
        navigationPanel.SetActive(true);
        ActiveUIPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
    /// <summary>
    /// 0 = Main navigation panel
    /// 1 = Settings
    /// 2 = Controls
    /// </summary>
    /// <param name="UIvalue"></param>
    public void SwitchToPanel(int UIvalue)
    {
        TurnOffPanels();
        panels[(Panels)UIvalue].SetActive(true);
    }

    void TurnOffPanels()
    {
        navigationPanel.SetActive(false);
        optionsPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }
    public void TurnBackground(bool state)
    {
        darkBackground.SetActive(state);
    }
}
