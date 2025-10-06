using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentador : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOver;
    private AudioSource tocadorAudio;
    public AudioClip pulo;
    public AudioClip gameover;

    private void Update()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.RightArrow))
        {

            float velocidadeX =
            Mathf.Clamp(
                    rb2D.linearVelocity.x + 0.5f,
                0,
                2
            );
            rb2D.linearVelocity = new Vector2(velocidadeX,
                rb2D.linearVelocity.y
            );

            transform.localScale = new Vector2(2, 2);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            float velocidadeX =
                Mathf.Clamp(
                    rb2D.linearVelocity.x - 0.5f,
                    -2,
                    0);

            rb2D.linearVelocity = new Vector2(velocidadeX,
                rb2D.linearVelocity.y
            );
            transform.localScale = new Vector2(-2, 2);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2D.AddForce(new Vector2(0, 250));
            tocadorAudio.PlayOneShot(pulo);
        }
    }
    private void LateUpdate()
    {
        //física    //var  //busca comp. //componenteDaFisica
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        Animator animator = GetComponent<Animator>();
        //variavel esquerda ou variavel direita
        if (rb2D.linearVelocity.x < 0 || rb2D.linearVelocity.x > 0)
        {
            //variavel usa a função Play que aponta pro comportamento
            animator.Play("Andando");
        }
        else
        {
            //variavel usa a função Play que aponta pro comportamento
            animator.Play("Parado");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.GetComponent<Pedra>() != null)
        {
            this.GameOver.SetActive(true);
            Time.timeScale = 0;
            tocadorAudio.PlayOneShot(gameover);
            //o jogo para de "rodar"
        }
    }

    public void ReiniciaJogo()
    {
        Time.timeScale = 1;
        //o jogo volta a "rodar"
        this.GameOver.SetActive(false);
        Application.LoadLevel(Application.loadedLevelName);
    }

    private void Awake()
    {
        tocadorAudio = GetComponent<AudioSource>();
    }
}
