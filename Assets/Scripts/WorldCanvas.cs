using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldCanvas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMenuButton()
    {
        Debug.Log("Restart button pressed");
        SceneManager.LoadScene("MainMenu");
    }
}
