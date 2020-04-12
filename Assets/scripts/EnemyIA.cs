using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour
{

  private float speed = 1f;
  private float initialHeight;
  [SerializeField]
  private GameObject ExplosionPrefab = null;
  private UIManager uiManager;
  // Start is called before the first frame update
  void Start()
  {
    initialHeight = transform.position.y;
    uiManager = GameObject.Find("UI").GetComponent<UIManager>();
    transform.position = new Vector3(Random.Range(-8.24f, 8.24f), initialHeight, 0);
  }

  // Update is called once per frame
  void Update()
  {

    // Movment down
    transform.Translate(Vector3.down * speed * Time.deltaTime);
    
    // Realocation
    if (transform.position.y < -6)
    {
      transform.position = new Vector3(Random.Range(-8.24f, 8.24f), initialHeight, 0);
    }
  }

  public void DestroyEnemy()
  {
    if (uiManager)
      uiManager.UpdateScore(1);
    Instantiate(ExplosionPrefab, transform.position + new Vector3(0f, 0, 0f), Quaternion.identity);
    Destroy(this.gameObject);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    // Access the player and change an attribute and later self destroy
    if (collision.tag == "Player")
    {
      Player player = collision.GetComponent<Player>();
      player.Damage(1);
      this.DestroyEnemy();
    }
  }
}
