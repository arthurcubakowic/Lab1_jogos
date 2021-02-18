using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ManageButtons fader; // Componente que ira fazer o Fade da cena lab1

    private int numTentativas;
    private int maxNumTentativas;
    int score = 0;

    public GameObject letra;
    public GameObject centro;

    private string palavraOculta = "";

    private int tamanhoPalavraOculta;
    char[] letrasOcultas;
    bool[] letrasDescobertas;
    

    void Start()
    {
        centro = GameObject.Find("centroDaTela");
        InitGame();
        InitLetras();
        numTentativas = 0;
        UpdateNumTentativas();
        UpdateScore();

    }


    void Update()
    {
        CheckTeclado();
    }

    void InitLetras()
    {
        int numLetras = palavraOculta.Length;
        for (int i = 0;  i<numLetras; i++)
        {
            Vector3 novaPosicao;
            novaPosicao = new Vector3(centro.transform.position.x + ((i - numLetras/2.0f) * 80), centro.transform.position.y, centro.transform.position.z);
            GameObject l = (GameObject)Instantiate(letra, novaPosicao, Quaternion.identity);
            l.name = "letra" + (i + 1);
            l.transform.SetParent(GameObject.Find("Canvas").transform);
        }
    }

    void InitGame()
    {

        palavraOculta = PegaUmaPalavraDoArquivo();
        tamanhoPalavraOculta = palavraOculta.Length;
        palavraOculta = palavraOculta.ToUpper();
        letrasOcultas = new char[tamanhoPalavraOculta];
        letrasDescobertas = new bool[tamanhoPalavraOculta];
        letrasOcultas = palavraOculta.ToCharArray();

        maxNumTentativas = palavraOculta.Length + 5; // se a palavra for muito grande é quase impossivel de ganhar com apenas 10 de max tentativas

    }

    void CheckTeclado()
    {
        if (Input.anyKeyDown)
        {
            char letraTeclada = Input.inputString.ToCharArray()[0];
            int letraTecladoComoInt = System.Convert.ToInt32(letraTeclada);

            if(letraTecladoComoInt >= 97 && letraTecladoComoInt <= 122)
            {
                numTentativas++;
                UpdateNumTentativas();

                if (numTentativas > maxNumTentativas)
                {
                    VerificaSePalavraDescoberta(); // O jogo tinha um bug em que o jogador podia escolher a ultima letra faltante e mesmo que acertasse ele perdia
                                                   // Outra solucao seria trocar o > por >= 
                    fader.StartForca();  // faz um fade para a cena de enforcado
                }

                for(int i = 0; i<=tamanhoPalavraOculta; i++)
                {
                    if (!letrasDescobertas[i])
                    {
                        letraTeclada = System.Char.ToUpper(letraTeclada);
                        if(letrasOcultas[i] == letraTeclada)
                        {
                            letrasDescobertas[i] = true;
                            GameObject.Find("letra" + (i + 1)).GetComponent<Text>().text = letraTeclada.ToString();
                            score = PlayerPrefs.GetInt("score");
                            score++;
                            PlayerPrefs.SetInt("score", score);
                            UpdateScore();
                            VerificaSePalavraDescoberta();
                        }
                    }
                }
            }
        }
    }

    void UpdateNumTentativas()
    {
        GameObject.Find("numTentativas").GetComponent<Text>().text = numTentativas + " | " + maxNumTentativas; 
    }

    void UpdateScore()
    {
        GameObject.Find("scoreUI").GetComponent<Text>().text = "SCORE " + score;
    }

    void VerificaSePalavraDescoberta()
    {
        bool condicao = true;
        for (int i = 0; i < tamanhoPalavraOculta; i++)
        {
            condicao = condicao && letrasDescobertas[i];
        }
        if (condicao)
        {
            PlayerPrefs.SetString("ultimaPalavraOculta", palavraOculta);
            fader.StartSalvo(); // Faz um Fade para a cena de voce ganhou
        }
    }

    string PegaUmaPalavraDoArquivo()
    {
        TextAsset t1 = (TextAsset)Resources.Load("palavras", typeof(TextAsset));
        string s = t1.text;
        string[] palavras = s.Split(' ');
        int palavraAleatoria = Random.Range(0, palavras.Length + 1);
        return (palavras[palavraAleatoria]);
    }
}
