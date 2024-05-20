using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
   public GameObject panelPrefab;

    void Awake()
    {
        panelPrefab = GameObject.FindGameObjectWithTag("SettingsPanel");
        panelPrefab.SetActive(false);
    }

    public void ActivateSettingsPanel()
    {
        panelPrefab.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackToGame()
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
