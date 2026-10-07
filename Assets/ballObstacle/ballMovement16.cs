using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ballMovement16 : MonoBehaviour
{
    public float jumpForce = 5f;

    public float torque = 150f;
    public int counter = 1;   

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            rb.AddTorque(Vector3.left * torque  * Time.fixedDeltaTime);
            Debug.Log(Vector3.left);
            Debug.Log("a");        

        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            rb.AddTorque(Vector3.right * torque * Time.fixedDeltaTime);        

        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            rb.AddTorque(Vector3.forward * torque * Time.fixedDeltaTime);        

        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            rb.AddTorque(Vector3.back * torque * Time.fixedDeltaTime);        

        }

        
        if (Input.GetKeyDown("space"))
        {
            jump();
        }
        
    }

    public void jump()
    {
        if (counter >= 1)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            counter = 0;
            StartCoroutine(DoAfterDelay(1.0f));
        }
    }


    IEnumerator DoAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        counter = 1;
    }
}