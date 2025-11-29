using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion Singleton

    public GameObject escTab;

    private bool isEscTabOpen = false;

    public void GoToTile()
    {
        SceneManager.LoadScene("Title");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isEscTabOpen == false)
            {
                escTab.SetActive(true);
                isEscTabOpen = true;
            }
            else
            {
                escTab.SetActive(false);
                isEscTabOpen = false;
            }
        }
    }
}
