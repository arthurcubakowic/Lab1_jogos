using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    public AudioSource musica;
    public void paraMusica()
    {
        musica = GetComponent<AudioSource>();
        musica.Stop();
    }
}
