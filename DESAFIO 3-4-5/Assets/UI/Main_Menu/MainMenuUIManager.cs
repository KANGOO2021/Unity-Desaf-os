using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    //public GameObject SelectDifficultyPanel;

    /*public void Awake()
    {
        SelectDifficultyPanel.SetActive(false); 
    }

    public void OnStartButtonClicked()
    {
        SelectDifficultyPanel.SetActive(true);
    }

    public void OnCloseButtonClicked()
    {
        SelectDifficultyPanel.SetActive(false);
    }*/

    public void OnStartLevelButtonClicked() {
        SceneManager.LoadScene(1);
    }
    public void OnQuitLevelButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnExitButtonClicked() {
        Application.Quit();
    }

}
