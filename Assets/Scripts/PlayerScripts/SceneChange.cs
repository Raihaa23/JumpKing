using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private Scene _currentScene;
    private string _startingScene;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
        _startingScene = _currentScene.name;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        switch (_startingScene)
        {
            case "Level1":
                SceneManager.LoadScene(1);
                break;
            case "Level2":
                SceneManager.LoadScene(2);
                break;
        }
    }
}
