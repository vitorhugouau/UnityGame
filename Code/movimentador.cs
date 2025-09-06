using UnityEngine;
using UnityEngine.InputSystem;

public class Movimentador : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized;

        transform.position += movement * moveSpeed * Time.deltaTime;

    }
    private void LateUpdate()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        Animator animator = GetComponent<Animator>();
        if (rb2D.linearVelocity.x < 0 || rb2D.linearVelocity.x > 0)
        {
            animator.Play("Andando");
        }
        else
        {
            animator.Play("Parado");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.GetComponent<Pedra>() != null)
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
