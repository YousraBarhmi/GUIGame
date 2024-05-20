using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject panelPrefab;

    void Awake()
    {
        GameObject panelPrefab = GameObject.FindGameObjectWithTag("GameOverTag");
        panelPrefab.SetActive(false);
    }

     public void GameOver()
    {
        panelPrefab.SetActive(true);
        Time.timeScale = 0;
    }

}
