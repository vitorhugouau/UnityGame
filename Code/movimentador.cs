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
}
