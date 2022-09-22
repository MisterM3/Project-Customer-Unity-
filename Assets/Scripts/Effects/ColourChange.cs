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
        //int[] rgb = new int[3];
        //rgb[0] = 
        Color colour = Random.ColorHSV(0, 360, 99, 100, 99, 100);
        //colour = Color.HSVToRGB(Random.Range(0, 360), 100, 100,true);
        //return Color.HSVToRGB(Random.Range(0f,360f),100f,100f);
        colour = Random.ColorHSV(0,1,1,1,1,1);
        return colour;
        //Color colour = Color.HSVToRGB(Random.Range(0,360),99,99,true);
    }
}
