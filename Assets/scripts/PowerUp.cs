using UnityEngine;

public class PowerUp : MonoBehaviour
{
  [SerializeField]
  private float speed = 0.5f;

  [SerializeField]
  private float initialHeight;

  [SerializeField]
  private int powerID = 0;

  private void Start()
  {
    initialHeight = transform.position.y;
    //this.gameObject.anim.SetFloat("BowSpeedAnim", speed);
    transform.position = new Vector3(Random.Range(-8.24f, 8.24f), initialHeight, 0);
  }
  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector3.down * Time.deltaTime * speed);
    DestroyWhenOutOfMap();
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    //Debug.Log("Collided with: " + collision);

    // Access the player and change an attribute and later self destroy
    if (collision.tag == "Player")
    {
      Player player = collision.GetComponent<Player>();
      if (player != null)
      {
        if (powerID == 0)
        {
          player.TripleShotOn();
          Destroy(this.gameObject);
        }
        else if (powerID == 1)
        {
          player.SpeedUpOn();
          Destroy(this.gameObject);
        }
        else if (powerID == 2)
        {
          player.riseShield();
          Destroy(this.gameObject);
        }
      }
    }

    // Realocation
    if (transform.position.y < -6)
    {
      transform.position = new Vector3(Random.Range(-8, 8), initialHeight, 0);
    }
  }
  private void DestroyWhenOutOfMap()
  {
    if (transform.position.y < -6)
    {
      Destroy(this.gameObject);
    }
  }
}
