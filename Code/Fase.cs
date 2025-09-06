using UnityEngine;

public class Fase : MonoBehaviour
{
    public GameObject _pedra;
    private float largura;
    private float altura;

    private void Awake()
    {
        Camera camera = GameObject.FindObjectOfType<Camera>();
        altura = camera.orthographicSize * 2;
        largura = altura * (Screen.width / (Screen.height * 1.0f));
    }

    void Start()
    {
        float metadeLargura = largura / 2;
        float metadeAltura = altura / 2;

        for (int numeroPedra = 1; numeroPedra <= 5; numeroPedra++)
        {
            GameObject pedraClonada = GameObject.Instantiate(_pedra);

            float x = Random.Range(-metadeLargura, metadeLargura);
            float y = metadeAltura;

            Vector3 posicaoAtual = pedraClonada.transform.position;
            pedraClonada.transform.position = new Vector3(x,y);
        }
    }

    void Update()
    {

    }
}
