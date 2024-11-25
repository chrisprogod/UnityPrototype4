using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject restartButton;
    public UIManager uiManager;
    public SoundManager soundManager;

    private bool gameOverSoundPlayed = false;  
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void ShowRestartButton()
    {
        if (!gameOverSoundPlayed)
        {
            uiManager.ShowRestartText();
            restartButton.SetActive(true);
            soundManager.GameOverSound();
            gameOverSoundPlayed = true;  
            Time.timeScale = 0;  
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        uiManager.HideRestartText();
        gameOverSoundPlayed = false;  // Reset the flag when the game restarts
    }
}