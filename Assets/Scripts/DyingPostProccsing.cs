using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DyingPostProcessingEffect : MonoBehaviour
{
    [SerializeField] private Volume deathVolume;

    Vignette vignette;

    Vignette currentStageVignette;

    [SerializeField] List<VolumeProfile> stagesOfDying = new List<VolumeProfile>();
    private int stages = 0;
    private void Start()
    {
        deathVolume.profile.TryGet<Vignette>(out vignette);
        NewEffectsStage();
    }

    private void Update()
    {
        if (vignette.intensity.value < currentStageVignette.intensity.value) vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, currentStageVignette.intensity.value, Time.deltaTime / 2f);
    }


    private void NewEffectsStage()
    {
        stagesOfDying[stages].TryGet<Vignette>(out currentStageVignette);
    }
}
