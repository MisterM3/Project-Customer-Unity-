using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions_v2 : MonoBehaviour
{
    [SerializeField] GameObject obj;
    GeneralUI ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GetComponent<GeneralUI>();
        ui.Pause();
        ui.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ui.enabled = true;
            Destroy(obj);
            ui.Resume();
            Destroy(this);
        }
    }
}
