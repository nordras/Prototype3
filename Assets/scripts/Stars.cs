using UnityEngine;

public class Stars : MonoBehaviour
{
  // Start is called before the first frame update
  //public GameObject cam;
  private float length, startpos;
  private float speed = 1f;
  //private Camera mainCamera;
  void Start()
  {
    startpos = transform.position.y;
    length = GetComponent<SpriteRenderer>().bounds.size.y;
    //mainCamera = gameObject.GetComponent<Camera>();
    //mainCamera = Camera.main;
    //Debug.Log("startpos: " + startpos);
    //Debug.Log("Stars legnthY: " + length);
    //Debug.Log("Camera: " + mainCamera.scaledPixelHeight);
    //Debug.Log("Camera: " + mainCamera.scaledPixelHeight);
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    //transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    //float dist = (cam.transform.position.x * parallaxEffect);
    transform.Translate(Vector3.down * speed * Time.deltaTime);
    if (transform.position.y <= (length * -1))
    {
      //Debug.Log("Reset position");
      transform.position = new Vector3(0, length, 0);
      //if (this.tag == "stars2")
      //{
      //  transform.position = new Vector3(0, 2, 0);
      //} else
      //{
      //  transform.position = new Vector3(0, 0, 0);
      //}
    }
  }
}
