using UnityEngine;
using UnityEngine.SceneManagement;

public class restartLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());

    }
    
}
