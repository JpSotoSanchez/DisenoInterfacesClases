using UnityEngine;
using UnityEngine.InputSystem;

public class comboTrial : MonoBehaviour 
{
    public float comboWindow = 1.0f; 
    public string[] comboActions = { "Left Jump", "Jump", "Right Jump" }; 
    public string currentAction = "";
    private float timeSinceLastPress = 0f; 

    public GameObject player;
    private bool isComboActive = false; 

    void Start() 
    {
    }

    void Update() 
    {
        timeSinceLastPress += Time.deltaTime; 

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            ExecuteCombo("q");

        }
        if(Keyboard.current.aKey.wasPressedThisFrame)
        {
                        ExecuteCombo("a");

        }
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
                        ExecuteCombo("u");

        }
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
                        ExecuteCombo("d");

        }

        if (timeSinceLastPress > comboWindow && isComboActive) 
        {
            ResetCombo(); 
        }
    }

    void ExecuteCombo(string key) 
    {
        if (timeSinceLastPress < comboWindow)
        {
            Debug.Log("onTime");
        }
        else
        {
            ResetCombo();
        }
        currentAction += key;
        Debug.Log(currentAction);
        timeSinceLastPress = 0f; 
        isComboActive = true; 
    }

    void JumpRight()
    {
        
    }
    void JumpLeft()
    {
        
    }

    void Jump()
    {
        
    }

    void ResetCombo()
    {
        if (currentAction== "uuu")
        {
            JumpLeft();
        }
        if(currentAction == "uuddqa")
        {
            JumpRight();
        }
        if(currentAction == "uuudqa")
        {
            Jump();
        }

        isComboActive = false;
        currentAction = "";
        Debug.Log("Reseted COmbo");
        Debug.Log(currentAction);
    }
}