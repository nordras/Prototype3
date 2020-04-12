using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
  [SerializeField]
  private GameObject EnemyPrefab;
  [SerializeField]
  private GameObject[] powerups;
  private GameManager gameManager;

  private float elapsed = 0f;

  // Start is called before the first frame update
  void Start()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

  }

  // Update is called once per frame
  void Update()
  {
    
  }

  public void startSPawnsRoutines()
  {
    StartCoroutine(spawnPowerUps());
    StartCoroutine(SpawnEnemy());
  }

  public void stopSPawnsRoutines()
  {
    StopAllCoroutines();
  }

  private IEnumerator spawnPowerUps()
  {
    while (!gameManager.gameOver)
    {
      Instantiate(powerups[Random.Range(0, 3)], transform.position + new Vector3(0, 7f, 0f), Quaternion.identity);
      yield return new WaitForSeconds(5.0f);
    }
    //foreach (GameObject powerup in powerups)
    //{
    //  Instantiate(powerup, transform.position + new Vector3(0, 7f, 0f), Quaternion.identity);
    //}
  }

  private IEnumerator SpawnEnemy()
  {
    while (!gameManager.gameOver)
    {
      Instantiate(EnemyPrefab, transform.position + new Vector3(0, 7f, 0f), Quaternion.identity);
      yield return new WaitForSeconds(5.0f);
    }
  }

  private void SpawnEnemy1()
  {
    elapsed += Time.deltaTime;
    if (elapsed >= 2f)
    {
      // Debug.Log(Time.deltaTime);
      elapsed = elapsed % 2f;
      Instantiate(EnemyPrefab, transform.position + new Vector3(0, 7f, 0f), Quaternion.identity);
    }
  }
}
