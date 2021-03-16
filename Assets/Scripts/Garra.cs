using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Garra : MonoBehaviour, 
                     CommunicatorComGarra
{
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private float coletadoScale;
    [SerializeField] private GameObject[] coletadoPosicoes = new GameObject[3]; 

    private Vector2 posicaoInicial;
    private bool moveToPosition;

    private bool checkCombinacao = false;

    private GameObject[] coletados = new GameObject[3];
    private Vector2[] coletadosBackPosition = new Vector2[3];

    private int score = 0;
    private int maxScore = 4;

    [SerializeField] protected Text scoreTextField;

    private MovimentacaoDaGarra movimentacaoAtual;    
    private MovimentacaoDaGarra movimentacaoParaBaixo;
    private MovimentacaoParaCima movimentacaoParaCima;
    private MovimentacaoDaGarra movimentacaoLateral;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidBody2d = GetComponent<Rigidbody2D>();

        movimentacaoLateral = new MovimentacaoLateral(speed, rigidBody2d, this);
        movimentacaoParaCima = new MovimentacaoParaCima(gravity, rigidBody2d, this);
        movimentacaoParaBaixo = new MovimentacaoParaBaixo(gravity, rigidBody2d);
        movimentacaoAtual = movimentacaoLateral;
    }

    // Update is called once per frame
    void Update()
    {
        movimentacaoAtual.update();
    }

    private void FixedUpdate()
    {
        movimentacaoAtual.fixedUpdate();       

        if (checkCombinacao)
        {
            GameObject checkColetavel= coletados[1];
            bool resposta = false;

            foreach (GameObject coletavel in coletados)
            {                
                if(checkColetavel.gameObject.CompareTag(coletavel.tag))
                {
                    resposta = true;
                }
                else
                {
                    resposta = false;
                }
            }

            if (resposta)
            {
                Debug.Log("yes");

                for (int i = 0; i < coletados.Length; i++)
                {
                    Destroy(coletados[i]);
                }

                score += 1;
                scoreTextField.text = score.ToString();

                if(score == maxScore)
                {
                    OnClickPlay();
                }
            }
            else
            {
                Debug.Log("noooo");

                for (int i = 0; i < coletados.Length; i++)
                {
                    coletados[i].transform.localScale += Vector3.one * coletadoScale;
                    coletados[i].gameObject.transform.position = coletadosBackPosition[i];
                    //coletadoPosicoes[i].gameObject.transform.position = coletadoOldPosicoes[i].transform.position;
                }
            }           

            coletados = new GameObject[3];
            coletadosBackPosition = new Vector2[3];
            checkCombinacao = false;
        }

        
    }   

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.tag == "Gummy")
        //{            


        //other.transform.position = coletado1.transform.position;

        trocarParaAcaoSubindo();

            for (int i = 0; i < coletados.Length; i++)
            {
                if (coletados[i] == null)
                {
                //coletadoOldPosicoes[i] = other.gameObject;
                    coletados[i] = other.gameObject;
                    coletadosBackPosition[i] = other.gameObject.transform.position;

                    other.transform.localScale -= Vector3.one * coletadoScale;
                    other.transform.position = coletadoPosicoes[i].transform.position;
                                    
                    if ( i == coletados.Length - 1)
                    {
                        checkCombinacao = true;
                    }

                    moveToPosition = true;
                    //Destroy(other.gameObject);
                    return;
                }
            }                      
        //}
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA INICIO
    public void trocarParaAcaoDescendo(Vector2 posicaoInicial)
    {
        this.posicaoInicial = posicaoInicial;
        movimentacaoAtual   = movimentacaoParaBaixo;
    }

    public void trocarParaAcaoSubindo()
    {
        movimentacaoParaCima.setPosicalInicialDeReferencia(posicaoInicial);
        movimentacaoAtual = movimentacaoParaCima;
    }

    public void trocarParaAcaoNormal()
    {
        movimentacaoAtual = movimentacaoLateral;
    }
    //IMPLEMENTACAO INTERFACE COMMUNICATORCOMGARRA FIM
}
