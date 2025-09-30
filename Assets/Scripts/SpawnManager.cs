using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject enemyPrefab;
  public GameObject powerupPrefab;
  private float spawnRange = 9;
  public int enemyCount;
  public int totalEnemyCount;
  public int waveNumber = 1;

  public UIManager uiManager; 
  public SoundManager soundManager;  

  // Start is called before the first frame update
  void Start()
  {
    uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    uiManager.FinaleWaveText.gameObject.SetActive(false);
    soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>(); 
    SpawnEnemyWave(waveNumber);
    Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
  }

  void SpawnEnemyWave(int enemiesToSpawn)
  {
    for (int i = 0; i < enemiesToSpawn; i++)
    {
      Instantiate(enemyPrefab, GenerateSpawnPosition(),
       enemyPrefab.transform.rotation);
      totalEnemyCount++;
    }
  }

  // Update is called once per frame
  void Update()
  {
    enemyCount = FindObjectsOfType<Enemy>().Length;
    if(enemyCount ==0){
      waveNumber++;
      uiManager.IncrementWave();
      SpawnEnemyWave(waveNumber);
      Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
      Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
      soundManager.PlayNewWaveSound();
    }
  }

  private Vector3 GenerateSpawnPosition()
  {
    float spawnPosX = Random.Range(-spawnRange, spawnRange);
    float spawnPosZ = Random.Range(-spawnRange, spawnRange);
    Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
    return randomPos;
  }
}
