using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player;
    Vector3 distance;

    void Start()
    {
        distance = this.gameObject.transform.position - player.position;
    }

    void Update()
    {
        this.gameObject.transform.position = player.position + distance;
    }
}