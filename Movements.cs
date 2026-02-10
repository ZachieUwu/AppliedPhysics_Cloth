using UnityEngine;

public class Movements : MonoBehaviour
{
    public CharacterController controller;

    public float Speed = 5f;

    public Animator animator;

    private float moveX,moveY;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        Vector3 move = new Vector3 (moveX, moveY, 0);

        controller.Move(move * Time.deltaTime * Speed);

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);

        if (moveX == 0 && moveY == 0)
        {
            animator.SetBool("IsWalk", false);
        }
        else
        {
            animator.SetBool("IsWalk", true);
        }

        Death();
    }

    void Death()
    {
        if (Input.GetKey(KeyCode.E))
        {
            animator.enabled = false;
        }
    }
}
