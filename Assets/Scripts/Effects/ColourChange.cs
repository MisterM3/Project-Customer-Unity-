using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    [SerializeField] Material material;

    [SerializeField] float timeTillChange;
    float currentTime;
    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            Color color = CreateColour();

            material.color = color;
            material.SetColor("_EmissionColor", color);
            currentTime = timeTillChange;
        }
    }
    Color CreateColour()
    {
        return Random.ColorHSV(0, 1, 1, 1, 1, 1);
    }
}
