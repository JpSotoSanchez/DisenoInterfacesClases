using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeMovement : MonoBehaviour
{
    private float torque = 32;
    private Rigidbody rb;

    private Boolean activado = true;

    CharacterController character;

    private AudioSource audioSource;
    public AudioClip jump1;
    public AudioClip jump2;
    public AudioClip jump3;
                        
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        character = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void FixedUpdate()
    {
        if (Keyboard.current.upArrowKey.isPressed && activado)
        {
            audioSource.PlayOneShot(jump1);
            activado = false;
            rb.AddForce(new Vector3(0,1,0) * 600);
            StartCoroutine(Wait(200));
            rb.AddTorque(new Vector3(0,1,0) * 285 * Time.fixedDeltaTime);
            StartCoroutine(Activar());
            Debug.Log("Salto");
        }

        if (Keyboard.current.rightArrowKey.isPressed && activado)
        {
            audioSource.PlayOneShot(jump2);
            activado = false;
            rb.AddForce(new Vector3(0,1,0) * 400);
            StartCoroutine(Wait(50));
            rb.AddForce(new Vector3(1,0,0) * 60);
            StartCoroutine(Wait(50));
            rb.AddTorque(new Vector3(0,0,1) * -520 * Time.fixedDeltaTime);
            StartCoroutine(Activar());
            Debug.Log("Salto");
        }

        if (Keyboard.current.leftArrowKey.isPressed && activado)
        {
            audioSource.PlayOneShot(jump3);
            activado = false;
            rb.AddForce(new Vector3(0,1,0) * 400);
            StartCoroutine(Wait(50));
            rb.AddForce(new Vector3(-1,0,0) * 60);
            StartCoroutine(Wait(50));
            rb.AddTorque(new Vector3(0,0,1) * 520 * Time.fixedDeltaTime);
            StartCoroutine(Activar());
            Debug.Log("Salto");
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.05f);
    }

    IEnumerator Wait(float i)
    {
        yield return new WaitForSeconds(i/1000);
        yield return null;
    }

    IEnumerator Activar()
    {
        yield return new WaitForSeconds(0.5f);
        activado = true;
        yield return null;
    }
}
