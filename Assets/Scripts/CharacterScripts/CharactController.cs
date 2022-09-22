using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharactController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] int speed;

    UserSettings settings;
    float xInput, yInput;
    float xRotation;

    AudioManager walkingSound;

    bool isInCar = false;

    // Start is called before the first frame update
    void Start()
    {
        xRotation = 90;
        walkingSound = GetComponent<AudioManager>();
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        settings = FindObjectOfType<UserSettings>();
    }
    private void FixedUpdate()
    {
        if (isInCar) return;
        Vector3 velocity = (transform.forward * yInput) + (transform.right * xInput);
        velocity = speed * Time.deltaTime * velocity.normalized;
        rb.velocity = velocity + new Vector3(0, rb.velocity.y, 0);
        
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        transform.rotation = Quaternion.Euler(new Vector3(0, xRotation));
        PlaySounds();
    }

    void GetInput()
    {
        if (!isInCar)
        {
            yInput = Input.GetAxisRaw("Vertical");
            xInput = Input.GetAxisRaw("Horizontal");
            if (xInput != 0 || yInput != 0) walkingSound.PlaySound();
        }
        

        xRotation += Input.GetAxisRaw("Mouse X") * (settings.GetSetting(UserSettings.FloatSettings.sensetivity) + .5f) * Time.timeScale;
    }
    void PlaySounds()
    {
        if (rb.velocity.magnitude > 1) walkingSound.PlaySound("concrete");
    }

    public void SetIsInCar(bool inCar)
    {
        isInCar = inCar;
    }

    public bool IsInCar()
    {
        return isInCar;
    }
}
