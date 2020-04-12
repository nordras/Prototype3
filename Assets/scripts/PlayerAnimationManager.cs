using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
  private Animator animator;
  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    {
      animator.SetBool("turn_left", true);
      animator.SetBool("turn_right", false);
    }
    else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
    {
      animator.SetBool("turn_left", false);
    }
    
    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
    {
      animator.SetBool("turn_left", false);
      animator.SetBool("turn_right", true);
    } else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
    {
      animator.SetBool("turn_right", false);
    }
    //} else
    //{
    //  animator.SetBool("turn_left", false);
    //  animator.SetBool("turn_right", false);
    //}
    //animator.SetBool()
  }
}
