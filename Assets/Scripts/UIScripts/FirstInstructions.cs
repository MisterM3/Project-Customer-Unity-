using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstInstructions : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    [SerializeField] bool showInstructions;
    MouseWorld m;
    [SerializeField] TextMeshProUGUI keyText;
    [SerializeField] TextMeshProUGUI instructionText;

    [SerializeField] CanvasGroup movementInstructions;
    [SerializeField]float timeTillDissapear = 4;


    bool hasShownPickup;
    bool hasShownInteraction;

    float cooldown = 2;
    float currentCooldown;

    LayerMask layerMask;

    private void Start()
    {
        if (!showInstructions)
        {
            Destroy(this);
        }
        m = FindObjectOfType<MouseWorld>();
        layerMask = LayerMask.GetMask("Interactable");
        currentCooldown = cooldown + Time.time;
    }
    private void Update()
    {
        if (timeTillDissapear > 0)
        {
            timeTillDissapear -= Time.deltaTime;
            if (timeTillDissapear <= 0)
            {
                StartCoroutine("Hide", movementInstructions);
            }
        }
        if (currentCooldown > Time.time) return;
        RaycastHit hit = m.GetObjectInDirection(Camera.main.transform.position, Camera.main.transform.forward, layerMask);
        if (hit.transform != null)
        {
            if (hit.transform.GetComponent<Pickable>() != null)
            {
                if (!hasShownPickup)
                    ShowPickup();
            }
            if (hit.transform.GetComponent<FuncExetion>() != null)
            {
                if (!hasShownInteraction) showInteraction();
            }
        }
        if (hasShownInteraction && hasShownPickup)
        {
            if (currentCooldown > Time.time - 2) return;
            parentObject.SetActive(false);
            Destroy(this);
        }
    }

    public void showInteraction()
    {
        parentObject.SetActive(true);
        keyText.text = "LMB";
        instructionText.text = "to inspect objects";
        hasShownInteraction = true;
        currentCooldown = cooldown + Time.time;
    }
    public void ShowPickup()
    {
        parentObject.SetActive(true);
        keyText.text = "E";
        instructionText.text = "to hold object";
        hasShownPickup = true;
        currentCooldown = cooldown + Time.time;
    }
    IEnumerator Hide(CanvasGroup canv)
    {
        print("doing");
        while (canv.alpha > 0)
        {
            canv.alpha -= .005f;
            yield return null;
        }
        Destroy(canv.transform.parent.gameObject);
    }
}