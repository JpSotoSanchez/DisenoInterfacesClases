using UnityEngine;

public class comboTrial : MonoBehaviour 
{
    public float comboWindow = 0.5f; 
    public string[] comboActions = { "Light Attack", "Heavy Attack", "Special Attack" }; 
    private float timeSinceLastPress = 0f; 
    private int currentComboStep = 0; 
    private bool isComboActive = false; 
    private Animator animator; 

    void Start() 
    {
        animator = GetComponent<Animator>(); 
    }

    void Update() 
    {
        timeSinceLastPress += Time.deltaTime; 

        if (Input.GetButtonDown("Fire1")) 
        {
            ExecuteCombo(); 
        }

        if (timeSinceLastPress > comboWindow && isComboActive) 
        {
            ResetCombo(); 
        }
    }

    void ExecuteCombo() 
    {
        if (timeSinceLastPress < comboWindow) 
        {
            currentComboStep++; 
        }
        else 
        {
            currentComboStep = 1; 
        }

        if (currentComboStep > comboActions.Length) 
        {
            currentComboStep = 1; 
        }

        PerformAttack(currentComboStep - 1); 
        timeSinceLastPress = 0f; 
        isComboActive = true; 
    }

    void PerformAttack(int comboIndex) 
    {
        string attackType = comboActions[comboIndex]; 
        animator.SetTrigger(attackType); 
    }

    void ResetCombo()
    {
        currentComboStep = 0;
        isComboActive = false;
    }
}