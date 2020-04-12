using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  // Serialized attributes, can be overwritted by unity
  [SerializeField] private GameObject _laserPrefab = null;
  [SerializeField] private GameObject _laserTripleShotPrefab = null;
  [SerializeField] private GameObject shieldObj = null;
  [SerializeField] private GameObject ExplosionPrefab = null;
  [SerializeField] private GameObject fire_left_engine = null;
  [SerializeField] private GameObject fire_right_engine = null;
  [SerializeField] private float _fireRate = 0.25f;

  // Public attributes
  public bool canTripleShot = false;

  // Internal attributes
  private float _canFire = 0.0f;
  private float speed = 10f;
  private int life = 3;
  private int shield = 0;

  private UIManager uiManager;
  private GameManager gameManager;

  // Start is called before the first frame update
  void Start()
  {
    uiManager = GameObject.Find("UI").GetComponent<UIManager>();
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    shieldObj.SetActive(false);
    if (uiManager)
      uiManager.UpdateLives(life);
  }

  // Update is called once per frame
  void Update()
  {
    this.movement();
    this.Shoot();
  }

  private void Shoot()
  {
    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
    {
      if (canTripleShot && Time.time >= _canFire)
      {
        Instantiate(_laserTripleShotPrefab, transform.position + new Vector3(0f, 3f, 0f), Quaternion.identity);
        _canFire = Time.time + _fireRate;
      } else if (Time.time >= _canFire)
      {
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
        _canFire = Time.time + _fireRate;
      }
    }
  }

  private void movement()
  {
    // Debug.Log("Speed: " + speed);
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    // Vertical and horizontal inputs
    transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

    // Prevent player to got out of map on Y axis
    if (transform.position.y > 4f)
    {
      transform.position = new Vector3(transform.position.x, 4f, 0);
    }
    else if (transform.position.y < -4.2f)
    {
      transform.position = new Vector3(transform.position.x, -4.2f, 0);
    }

    // Prevent player to got out of map on X axis
    if (transform.position.x > 9.5f)
    {
      this.resetAxisX();
    }
    else if (transform.position.x < -9.5f)
    {
      this.resetAxisX();
    }
  }
  
  void resetAxisX()
  {
    transform.position = new Vector3((transform.position.x * -1), transform.position.y, 0);
  }

  public void SpeedUpOn()
  {
    speed = 20f;
    StartCoroutine(SpeedUpOff());
  }

  private IEnumerator SpeedUpOff()
  {
    // wait for 5 second
    yield return new WaitForSeconds(5.0f);
    speed = 10f;
  }

  public void TripleShotOn()
  {
    canTripleShot = true;
    StartCoroutine(TripleShotOff());
  }

  private IEnumerator TripleShotOff()
  {
    // wait for 5 second
    yield return new WaitForSeconds(5.0f);
    canTripleShot = false;
  }

  public void riseShield()
  {
    shield = 1;
    shieldObj.SetActive(true);
  }
  // Set engines on fire
  public void updateDescrutState()
  {
    if (life == 2)
    {
      fire_left_engine.SetActive(true);
    } else if (life == 1) {
      fire_right_engine.SetActive(true);
    } else if (life == 3)
    {
      fire_left_engine.SetActive(false);
      fire_right_engine.SetActive(false);
    }
  }

  public void Damage(int damage)
  {
    if (shield < 1) {
      life -= damage;
      uiManager.UpdateLives(life);
      updateDescrutState();
      if (life < 1)
      {
        Instantiate(ExplosionPrefab, transform.position + new Vector3(0f, 0, 0f), Quaternion.identity);
        uiManager.ToggleTitleScren(true);
        gameManager.gameOver = true;
        Destroy(this.gameObject);
      }
    } else {
      shield--;
      if (shield < 1)
      {
        shieldObj.SetActive(false);
      }
    }
  }
}
