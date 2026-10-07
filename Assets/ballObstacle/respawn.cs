using Unity.VisualScripting;
using UnityEngine;

public class respawn : MonoBehaviour
{   
    public GameObject respawnPoint; 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            other.transform.position = respawnPoint.transform.position + new Vector3(0,2,0);
            other.GetComponent<Rigidbody>().linearVelocity=Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity=Vector3.zero;

        }
    }
}
