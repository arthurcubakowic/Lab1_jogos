using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject mainCamera;

    // Start is called before the first frame update
    public void ExitOnClick()
    {
        mainCamera.GetComponent<AudioSource>().Stop();
        Application.Quit();
    }

    /*public void ExitOnClick3s()
    {
        mainCamera.GetComponent<AudioSource>().Stop();
        System.Threading.Thread.Sleep(3000);
        Application.Quit();
    }*/


}
