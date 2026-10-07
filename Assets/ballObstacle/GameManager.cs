using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int win = 0;
    public Canvas canva;
    public GameObject player;
    GameObject[] collectibles;

    public TextMeshProUGUI myTextLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     collectibles = GameObject.FindGameObjectsWithTag("collectible");
     Debug.Log(collectibles.Length);
     myTextLabel.SetText("collectibles: " + (collectibles.Length-win));
     canva.enabled = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add()
    {
        win++;
        myTextLabel.SetText("collectibles: " + (collectibles.Length-win));
        checkWin();
    }

    public void checkWin()
    {
        if(win >= collectibles.Length)
        {
            canva.enabled = true;
            ballMovement16 var = player.GetComponent<ballMovement16>();
            Destroy(var);
            player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

}
