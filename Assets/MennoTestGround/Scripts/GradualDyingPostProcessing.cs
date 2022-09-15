using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GradualDyingPostProcessing : MonoBehaviour
{

     float intensityVignette;
     float intensityGrain;
     float responseGrain;
     float saturationColorAdjustments;



    [SerializeField] private Volume deathVolume;

    Vignette vignette;
    FilmGrain grain;
    ColorAdjustments colorAdjustments;

    Vignette currentStageVignette;
    FilmGrain currentStageGrain;
    ColorAdjustments currentStageColorAdjustments;

    [SerializeField] VolumeProfile effectJustBeforeDying;

    private int stage = 8;
    [SerializeField] private int totalStages = 8;
    private void Start()
    {
        if (deathVolume == null)
        {
            Debug.LogError("No Volume selected to deathVolume: " + gameObject);
            return;
        }

        if (effectJustBeforeDying == null)
        {
            Debug.LogError("No Volume selected to effectJustBeforeDying: " + gameObject);
            return;
        }

        Setup();
        NewEffectsStage();
    }

    //
    private void Update()
    {
        float timeForLerp = Time.deltaTime / 2.0f;
        if (vignette.intensity.value - intensityVignette < 0.1f) vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, intensityVignette, timeForLerp);
        if (grain.intensity.value - intensityGrain < 0.1f) grain.intensity.value = Mathf.Lerp(grain.intensity.value, intensityGrain, timeForLerp);
        if (grain.response.value - responseGrain < 0.1f) grain.response.value = Mathf.Lerp(grain.response.value, responseGrain, timeForLerp);
        if (colorAdjustments.saturation.value - saturationColorAdjustments > 0.1f) colorAdjustments.saturation.value = Mathf.Lerp(colorAdjustments.saturation.value, saturationColorAdjustments, timeForLerp);
        Debug.Log(colorAdjustments.saturation.value);
    }

    private void Setup()
    {
        deathVolume.profile.TryGet<Vignette>(out vignette);
        deathVolume.profile.TryGet<FilmGrain>(out grain);
        deathVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments);

        effectJustBeforeDying.TryGet<Vignette>(out currentStageVignette);
        effectJustBeforeDying.TryGet<FilmGrain>(out currentStageGrain);
        effectJustBeforeDying.TryGet<ColorAdjustments>(out currentStageColorAdjustments);
    }
    private void NewEffectsStage()
    {
        intensityVignette = currentStageVignette.intensity.value / totalStages * stage;
        intensityGrain = currentStageGrain.intensity.value / totalStages * stage;
        responseGrain = currentStageGrain.response.value / totalStages * stage;
        saturationColorAdjustments = currentStageColorAdjustments.saturation.value / totalStages * stage;

    }

    public void nextStage()
    {
        stage++;
        NewEffectsStage();
    }
}



