using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Garra : MonoBehaviour, 
                     CommunicatorComGarra
{

    private Rigidbody2D rgbd2d;
    //private float move;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float gravity;
    private bool movingDown;
    
    private Vector2 posicaoInicial;
    private bool moveToPosition;

    private bool movingEnable = true;
    private bool checkCombinacao = false;

    [SerializeField]
    private float coletadoScale;
    [SerializeField]
    private GameObject[] coletadoPosicoes = new GameObject[3]; 
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
        rgbd2d = GetComponent<Rigidbody2D>();

        movimentacaoLateral = new MovimentacaoLateral(speed, rgbd2d, this);
        movimentacaoParaCima = new MovimentacaoParaCima(gravity, rgbd2d, this);
        movimentacaoParaBaixo = new MovimentacaoParaBaixo(gravity, rgbd2d);
        movimentacaoAtual = movimentacaoLateral;
    }

    // Update is called once per frame
    void Update()
    {
        movimentacaoAtual.update();
        //move = Input.GetAxis("Horizontal");

        //if (Input.GetButtonDown("Jump"))
        //{
        //    moveToTarget = rgbd2d.transform.position;            
        //    movingEnable = false;
        //    movingDown = true;
        //}

        //Debug.Log(movimentacaoAtual);
    }

    private void FixedUpdate()
    {
        //if (movingEnable)
        //{
        //    rgbd2d.velocity = new Vector2(move * speed, rgbd2d.velocity.y);
        //}       

        movimentacaoAtual.fixedUpdate();       

        //if (movingDown)
        //{                        
        //    rgbd2d.gravityScale = gravity;            
        //    movingDown = false;
        //}

        //if (moveToPosition)
        //{
        //    rgbd2d.position = posicaoInicial;
        //    moveToPosition = false;
        //    movingEnable = true;
        //}

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
        //rgbd2d.gravityScale = 0.0f;


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
