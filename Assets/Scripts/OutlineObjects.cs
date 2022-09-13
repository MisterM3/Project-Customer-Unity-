using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OutlineObjects : MonoBehaviour

{

    [SerializeField] private Material outlineMaterial;

    [SerializeField] private float outlineScaleFactor = -1.1f;

    [SerializeField] private Color outlineColor;

    private Renderer outlineRenderer;



    void Start()
    {

        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);

        //IInteract interactableObject = GetComponent<IInteract>();
        //interactableObject.onObjectSelect += InteractableObject_onObjectSelect;
        //interactableObject.onObjectDeSelect += InteractableObject_onObjectDeSelect;

    }

    private void Update()
    {
        if (outlineRenderer.enabled)
        {
            DeActiveOutline();
        }
    }
    

    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)

    {

        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);

        Renderer rend = outlineObject.GetComponent<Renderer>();



        rend.material = outlineMat;

        rend.material.SetColor("_OutlineColor", color);

        rend.material.SetFloat("_Scale", scaleFactor);

        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;



        outlineObject.GetComponent<OutlineObjects>().enabled = false;

        outlineObject.GetComponent<Collider>().enabled = false;



        rend.enabled = false;



        return rend;

    }


    public void ActivateOutline()
    {
        outlineRenderer.enabled = true;
    }
    public void DeActiveOutline()
    {
        outlineRenderer.enabled = false;
    }

}
