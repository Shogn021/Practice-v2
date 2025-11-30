using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    #region Singleton
    public static Title instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public string sceneName;
    private PlayerManager thePlayer;

    private void Start()
    {
        thePlayer = FindAnyObjectByType<PlayerManager>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void Resume()
    {
        thePlayer.escTab.SetActive(false);
        thePlayer.canMove = true;
    }
}
