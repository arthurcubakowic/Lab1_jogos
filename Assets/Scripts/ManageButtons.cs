using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class ManageButtons : MonoBehaviour
{
    public GameObject mainCamera;
    Image image;
    public float durationOut;
    public float durationIn;    
    public string Scene;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score", 0);

        image = GetComponent<Image>();
        image.color = new Color(0, 0, 0, 1);
        image.enabled = true;

        image.DOFade(0, durationIn)
            .OnComplete(() => { image.enabled = false; });
    }

    public void StartMundo()
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene(Scene); });
    }

    public void StartGame()
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene("Lab1"); });
    }

    public void StartCredits()
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene("Lab1_credits"); });
    }

    public void StartSalvo()
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene("Lab1_salvo"); });
    }

    public void StartForca()
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene("Lab1_forca"); });
    }

    public void RestartAudio()
    {
        mainCamera.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().Play();


        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, durationOut)
            .OnComplete(() => { SceneManager.LoadScene(Scene); });
    }
}
