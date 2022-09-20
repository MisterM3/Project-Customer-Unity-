using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoyoteSound : MonoBehaviour
{

    [SerializeField] List<AudioClip> coyoteClips;
    [SerializeField] List<Transform> soundPositions;

    private float timer = 5f;

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            AudioSource.PlayClipAtPoint(coyoteClips[Random.Range(0, coyoteClips.Count)], soundPositions[Random.Range(0, soundPositions.Count)].position);
            timer = Random.Range(3f, 10f);
        }
        timer -= Time.deltaTime;

    }
}
