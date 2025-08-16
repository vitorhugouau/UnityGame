using UnityEngine;
using UnityEngine.InputSystem;

public class movimentador : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    { 
        
        transform.position = new Vector3(transform.position.y + Time.deltaTime, transform.position.y);
    }

}
