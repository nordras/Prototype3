using UnityEngine;

public class GameManager : MonoBehaviour
{
  public bool gameOver = true;
  private UIManager uiManager;
  public GameObject player;
  private Spawn spawn;
  void Start()
  {
    uiManager = GameObject.Find("UI").GetComponent<UIManager>();
    spawn = GameObject.Find("Spawn").GetComponent<Spawn>();
  }

  // Update is called once per frame
  void Update()
  {
    StartGame();
  }
  public void StartGame()
  {
    if (gameOver) { 
      if (Input.GetKeyDown(KeyCode.Space))
      {
        gameOver = false;
        Instantiate(player, Vector3.zero, Quaternion.identity);
        if (spawn)
          spawn.startSPawnsRoutines();
        uiManager.ToggleTitleScren(false);
      }
    }
  }
  public void StopGame()
  {
    if (spawn)
      spawn.stopSPawnsRoutines();
  }
}
