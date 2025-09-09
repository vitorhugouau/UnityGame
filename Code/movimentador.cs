using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimentador : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb2D;
    private Animator animator;

    private Vector2 movement;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;

        if (movement.magnitude > 0)
        {
            animator.Play("Andando");
        }
        else
        {
            animator.Play("Parado");
        }
    }

    private void FixedUpdate()
    {
        
        rb2D.MovePosition(rb2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Pedra>() != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
