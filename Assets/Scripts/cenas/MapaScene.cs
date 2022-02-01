using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class MapaScene : MonoBehaviour
{   
    [SerializeField] private ModalFaseDto modalFaseDto;
    [Space(5)]
    [SerializeField] private Button btnLevel1;
    [SerializeField] private Button btnLevel2;
    [SerializeField] private Button btnLevel3;
    [SerializeField] private Button btnLevel4;
    [Space(5)]
    [SerializeField] private TimerFichaDto[] timerFichaDto = new TimerFichaDto[3];   
    [Space(5)]
    [SerializeField] private BotoesCenasDto botoesCenasDto;

    private TimerFicha timerFichaOuro;
    private TimerFicha timerFichaPrata;
    private TimerFicha timerFichaBronze;

    private void Start()
    {
        ModalFase modalFase = new ModalFase(modalFaseDto);

        btnLevel1.onClick.AddListener(() => modalFase.ligar(Level.HUM));
        btnLevel2.onClick.AddListener(() => modalFase.ligar(Level.DOIS));
        btnLevel3.onClick.AddListener(() => modalFase.ligar(Level.TRES));
        btnLevel4.onClick.AddListener(() => modalFase.ligar(Level.QUATRO));

        new BotoesCenasMapa(botoesCenasDto);

        timerFichaOuro   = new TimerFicha(timerFichaDto[0], Ficha.OURO);
        timerFichaPrata  = new TimerFicha(timerFichaDto[1], Ficha.PRATA);
        timerFichaBronze = new TimerFicha(timerFichaDto[2], Ficha.BRONZE);        
    }

    private void Update()
    {
        timerFichaOuro.update();
        timerFichaPrata.update();
        timerFichaBronze.update();
    }

    private void OnDisable()
    {
        //PlayerPrefsFichas.consumirFicha(Ficha.BRONZE, 2);
        //PlayerPrefsFichas.consumirFicha(Ficha.PRATA, 1);
        //PlayerPrefsFichas.consumirFicha(Ficha.OURO, 1);
    }
}
