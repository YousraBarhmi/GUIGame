using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject panelPrefab;

    void Awake()
    {
        panelPrefab = GameObject.FindGameObjectWithTag("PausePanelTag");
        panelPrefab.SetActive(false);
    }

    public void ActivatePausePanel()
    {
        panelPrefab.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        panelPrefab.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
