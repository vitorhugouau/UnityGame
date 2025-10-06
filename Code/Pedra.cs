using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedra : MonoBehaviour
{
	public AudioClip caindo;
	public AudioClip explosao;

	void Start()
	{
		TocadorAudio.Tocador.PlayOneShot(caindo);
	}
	void OnCollisionEnter2D(Collision2D collision2D)
	{
		TocadorAudio.Tocador.PlayOneShot(explosao);
		Destroy(gameObject);
	}
}
