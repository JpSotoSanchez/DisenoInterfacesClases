using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ballMovement : MonoBehaviour
{
    public float jumpForce = 5f;

    private float torque = 150f;
    public int counter = 1;   

    private Rigidbody rb;
    public int powerIndex = 0;

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