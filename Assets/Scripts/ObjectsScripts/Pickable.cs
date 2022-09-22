using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour
{
    Rigidbody rb;
    enum Weight { Light, Medium, Heavy };
    //[ContextMenu("apply to children", "ThisChildrenApply")]
    [SerializeField] Weight weight;
    [SerializeField, Tooltip("Use this to tweak at what difference of speed of an object sound" +
        " is supposed to play")] float velocityTreshold;
    Vector3 oldVelocity;


    AudioManager audioPlayer;
    bool isDropped;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void MoveToPos(Vector3 vec)
    {
        Vector3 verticalDrag = .5f * Vector3.down;
        Vector3 velocity = vec - transform.position;
        switch (weight)
        {
            case Weight.Light:
                rb.velocity = velocity * 4;
                break;
            case Weight.Medium:
                velocity.y = velocity.y < 0 ? rb.velocity.y + velocity.y : velocity.y + verticalDrag.y;
                rb.velocity = new Vector3(velocity.x * 2, velocity.y, velocity.z * 2);
                break;
            case Weight.Heavy:
                rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
                break;
        }
    }
    private void Update()
    {
        if (isDropped) return;
        if (GetAudioManager() == null) return;
        if (oldVelocity.magnitude > rb.velocity.magnitude + velocityTreshold)
        {
            GetComponent<AudioManager>().PlaySound();
            isDropped = true;
        }
        oldVelocity = rb.velocity;
    }
    public void PickedUp()
    {
        isDropped = false;
    }
    AudioManager GetAudioManager()
    {
        if (audioPlayer != null) return audioPlayer;
        if (TryGetComponent<AudioManager>(out audioPlayer))
        {
            return audioPlayer;
        }
        return null;
    }


}
