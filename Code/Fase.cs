using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fase : MonoBehaviour
{
	private TocadorAudio Tocador;
    public GameObject _pedra;
    private float altura;
    private float largura;

	private void Awake()
	{
		Camera camera = GameObject.FindObjectOfType<Camera>();
		altura = camera.orthographicSize * 2;
		largura = altura * (Screen.width / (Screen.height * 1.0f));
	}

    void Start () {
		StartCoroutine(CriarPedras());
	}
	IEnumerator CriarPedras()
	{
		CriarPedra();
		yield return new WaitForSeconds(1.0f);
		StartCoroutine(CriarPedras());
		
	}

	private void CriarPedra(){
		
		float metadeLargura = largura / 2;
		float metadeAltura = altura / 2;

		GameObject pedraClonada = GameObject.Instantiate(_pedra);

		float x = Random.Range(-metadeLargura,metadeLargura);
		float y = metadeAltura;
		pedraClonada.transform.position = new Vector2(x,y);
	}
}
