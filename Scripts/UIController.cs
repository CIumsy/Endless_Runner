using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;

    void Update()
    {
        
    }
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        score.text = ((player.score)/10).ToString();
    }
    public void GameRestart()
    {
        SceneManager.LoadScene("EndlessRunner");
    }
}
