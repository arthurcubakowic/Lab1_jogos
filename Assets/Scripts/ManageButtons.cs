using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class ManageButtons : MonoBehaviour
{
    public GameObject mainCamera; // Referencia o objeto main camera para porrar pausar a musica atrelada a ele
    public float durationOut;     // Tempo de duracao do Fade Out
    public float durationIn;      // Tempo de duracao do Fade In
    public string Scene;          // Cena que sera transicionada
    Image image;                  // Referencia de imagem para o Fader


    void Start()
    {
        PlayerPrefs.SetInt("score", 0);

        image = GetComponent<Image>(); // Clareia uma imagem preta em durationIn segundos
        image.color = new Color(0, 0, 0, 1);
        image.enabled = true;

        image.DOFade(0, durationIn)
            .OnComplete(() => { image.enabled = false; }); // Por fim desativa o componente imagem
    }

    public void StartMundo() // Fader para a cena da variavel Scene
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene(Scene); });
    }

    public void StartGame() // Fader para a cena Lab1
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene("Lab1"); });
    }

    public void StartCredits() // Fader para a cena dos creditos
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene("Lab1_credits"); });
    }

    public void StartSalvo() // Fader para a cena de voce ganhou
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene("Lab1_salvo"); });
    }

    public void StartForca() // Fader para a cena de Forca
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene("Lab1_forca"); });
    }

    public void RestartAudio() // Faz o Fader para a cena da variavel Scene, mas tambem da play em um audio armazenado no proprio gameObject
    {
        mainCamera.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().Play();


        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene(Scene); });
    }

    public void ExitGame() // Fecha o jogo, porem essa funcao so funciona se o codigo estiver exportado, pelo preview do Unity ele nao funciona
    {
        mainCamera.GetComponent<AudioSource>().Stop();
        Application.Quit();
    }
}
