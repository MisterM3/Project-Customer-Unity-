using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color c = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        material.SetColor("_EmissionColor", c);
        material.color = c;
        if (Input.GetKeyDown(KeyCode.V)) print(material.color);
    }
}
