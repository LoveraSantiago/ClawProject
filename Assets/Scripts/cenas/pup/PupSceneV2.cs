using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PupSceneV2 : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private GameObject cardDetalhe;
    [SerializeField] private Button[] cardBtns = new Button[13];
    [SerializeField] private Animator animator;

    private Vector3 posOriginal;
    private bool isClicado;    

    // Start is called before the first frame update
    void Start()
    {
        for(int contador = 0; contador < cardBtns.Length; contador++)
        {
            cardBtns[contador].onClick.AddListener(() => clicado());
        }
        posOriginal = cardDetalhe.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicado)
        {           
            Vector3 result = Vector3.MoveTowards(cardDetalhe.transform.position, posOriginal, velocidade * Time.deltaTime);
            cardDetalhe.transform.position = result;
            float distancia = Vector3.Distance(cardDetalhe.transform.position, posOriginal);            
            if(distancia < 0.1f)
            {
                animator.Play("flip-down");
                cardDetalhe.transform.position = posOriginal;
                isClicado = false;                
            }
        }
    }

    public void clicado()
    {
        if(isClicado == false)
        {
            animator.Play("flip-up-stop");

            GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
            cardDetalhe.transform.position = goSelecionado.transform.position;
            cardDetalhe.SetActive(true);
            isClicado = true;            
        }
    }
}
