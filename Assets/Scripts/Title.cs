using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string sceneName;
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
