using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OutlineObjects : MonoBehaviour

{

    [SerializeField] private Material outlineMaterial;

    [SerializeField] private float outlineScaleFactor = -1.1f;

    [SerializeField] private Color outlineColor;

    [SerializeField] private bool transformOfParent = false;
    [SerializeField] private bool invert = false;

    private Renderer outlineRenderer;



    void Start()
    {      
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);


    }



    private void Update()
    {
        if(outlineRenderer == null) return;
        if (outlineRenderer.enabled)
        {
            Debug.Log("help");
            DeActiveOutline();
        }
    }
    

    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)

    {


        Quaternion extrarotation;

        if (invert) extrarotation = Quaternion.Euler(0, 180, 0);
        else extrarotation = Quaternion.Euler(0, 0, 0);
        GameObject outlineObject;

        if (transformOfParent)
        {
           
            outlineObject = Instantiate(this.gameObject, transform.parent.position, transform.parent.rotation * extrarotation, transform.parent);
        }
        else
        {
            outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation * extrarotation, transform);
           // outlineObject = Instantiate(this.gameObject, Vector3.zero, transform.rotation * extrarotation, transform);
        }

        outlineObject.transform.localScale = new Vector3(1, 1, 1);

        Renderer rend = outlineObject.GetComponent<Renderer>();



        rend.material = outlineMat;

        rend.material.SetColor("_OutlineColor", color);

        rend.material.SetFloat("_Scale", scaleFactor);

        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;



        outlineObject.GetComponent<OutlineObjects>().enabled = false;
        outlineObject.TryGetComponent<Pickable>(out Pickable pick);
        Destroy(pick);
        outlineObject.TryGetComponent<Rigidbody>(out Rigidbody rb);
        Destroy(rb);

        outlineObject.GetComponent<Collider>().enabled = false;



        rend.enabled = false;



        return rend;

    }


    public void ActivateOutline()
    {
        if (outlineRenderer == null) return;
        Debug.Log("active");
        outlineRenderer.enabled = true;
    }
    public void DeActiveOutline()
    {
        outlineRenderer.enabled = false;
    }

}
