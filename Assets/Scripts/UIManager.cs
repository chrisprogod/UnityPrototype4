using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI waveCounterText;
    public TextMeshProUGUI enemyCounterText;
    public TextMeshProUGUI FinaleWaveText;
    public GameObject restartButton;
    public SpawnManager spawnManager;

    public int waveCount = 1;
    private int enemyCount;



    void Update()
    {
        waveCounterText.text = "Wave: " + waveCount;

        enemyCount = spawnManager.totalEnemyCount - FindObjectsOfType<Enemy>().Length;
        enemyCounterText.text = "" + enemyCount;
        if (restartButton.activeSelf)
        {
            FinaleWaveText.text = "Waves Played: " + waveCount + "\n Enemies Killed: " + enemyCount;
        }
    }

    public void IncrementWave()
    {
        waveCount++;
    }

    public void ShowRestartText()
    {
        FinaleWaveText.gameObject.SetActive(true);
    }

    public void HideRestartText()
    {
        FinaleWaveText.gameObject.SetActive(false);
    }
}