using UnityEngine;

public class Laser : MonoBehaviour
{
  [SerializeField]
  private float _speed = 10;

  [SerializeField]
  private AudioSource laserSound;

  // Start is called before the first frame update
  void Start()
  {
    laserSound.Play();
  }

  // Update is called once per frame
  void Update()
  {    

    transform.Translate(Vector3.up * _speed * Time.deltaTime);
    if (transform.position.y > 6)
    {
      Destroy(this.gameObject);
      if (transform.parent) {
        Destroy(transform.parent.gameObject);
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    //Debug.Log("Collided with: " + collision);
    // Access the player and change an attribute and later self destroy
    if (collision.tag == "Enemy")
    {
      EnemyIA enemy = collision.GetComponent<EnemyIA>();
      enemy.DestroyEnemy();
      Destroy(this.gameObject);
      if (transform.parent)
      {
        Destroy(transform.parent.gameObject);
      }
    }
  }
}
