using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TocadorAudio : MonoBehaviour
{
    private static AudioSource tocador;
	public static AudioSource Tocador
	{
		get {return tocador;}
	}
	static TocadorAudio()
	{
		GameObject gameObject = new GameObject("TocadorAudio");
		gameObject.AddComponent<TocadorAudio>();
		//A cena é recarregada e todos os objetos são destruídos, para evitar:
		GameObject.DontDestroyOnLoad(gameObject);
	}

    private void Awake()
    {
        tocador = gameObject.AddComponent<AudioSource>();
        //genérico para o COMPONENTE
        AudioClip musica = Resources.Load<AudioClip>("musica");

        AudioSource tocadorMusica = gameObject.AddComponent<AudioSource>();
        tocadorMusica.clip = musica;
        //generico p/ tomar as propriedades do audioSource
        tocadorMusica.loop = true;
        //habilita que seja feito N vezes
        tocadorMusica.Play();
        //permite a execução
	}
}
