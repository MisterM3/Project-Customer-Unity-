using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralUI : MonoBehaviour
{
    bool isPaused;
    //Panels panels;
    public enum Panels { Navigation = 0,Options = 1, Controls = 2};
    [SerializeField]GameObject darkBackground;
    [SerializeField]GameObject navigationPanel;
    [SerializeField]GameObject optionsPanel;
    [SerializeField]GameObject controlsPanel;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;
                darkBackground.SetActive(true);
                navigationPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                isPaused = true;
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
        navigationPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
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
        navigationPanel.SetActive(false );
        optionsPanel.SetActive(false );
        controlsPanel.SetActive(false );
    }
}
