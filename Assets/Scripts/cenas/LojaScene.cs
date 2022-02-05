using TMPro;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class LojaScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lblQtdFichasOuro;
    [SerializeField] private TextMeshProUGUI lblQtdFichasPrata;
    [SerializeField] private TextMeshProUGUI lblQtdFichasBronze;
    [Space(5)]
    [SerializeField] private Button btnOuro;
    [SerializeField] private Button btnPrata;
    [SerializeField] private Button btnBronze;
    [Space(5)]
    [SerializeField] private Button btnAssinatura;

    // Start is called before the first frame update
    void Start()
    {
        lblQtdFichasOuro.text   = PlayerPrefsFichas.getQtdFichas(Ficha.OURO).ToString();
        lblQtdFichasPrata.text  = PlayerPrefsFichas.getQtdFichas(Ficha.PRATA).ToString();
        lblQtdFichasBronze.text = PlayerPrefsFichas.getQtdFichas(Ficha.BRONZE).ToString();

        btnOuro.onClick.AddListener(()=> {
            PlayerPrefsFichas.adicionarFicha(Ficha.OURO, 1);
            lblQtdFichasOuro.text = PlayerPrefsFichas.getQtdFichas(Ficha.OURO).ToString();
        });

        btnPrata.onClick.AddListener(() => {
            PlayerPrefsFichas.adicionarFicha(Ficha.PRATA, 1);
            lblQtdFichasPrata.text = PlayerPrefsFichas.getQtdFichas(Ficha.PRATA).ToString();
        });

        btnBronze.onClick.AddListener(() => {
            PlayerPrefsFichas.adicionarFicha(Ficha.BRONZE, 1);
            lblQtdFichasBronze.text = PlayerPrefsFichas.getQtdFichas(Ficha.BRONZE).ToString();
        });

        btnAssinatura.onClick.AddListener(() =>
        {
            PlayerPrefsFichas.adicionarFicha(Ficha.OURO, 10);
            lblQtdFichasOuro.text = PlayerPrefsFichas.getQtdFichas(Ficha.OURO).ToString();

            PlayerPrefsFichas.adicionarFicha(Ficha.PRATA, 20);
            lblQtdFichasPrata.text = PlayerPrefsFichas.getQtdFichas(Ficha.PRATA).ToString();

            PlayerPrefsFichas.adicionarFicha(Ficha.BRONZE, 30);
            lblQtdFichasBronze.text = PlayerPrefsFichas.getQtdFichas(Ficha.BRONZE).ToString();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
