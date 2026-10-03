using Unity.VisualScripting;
using UnityEngine;

public class collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameManager gameManager;

    void Start()
    {
       gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            gameManager.add();
            Debug.Log("touched");
            Destroy(this.gameObject);
        }
    }
}
