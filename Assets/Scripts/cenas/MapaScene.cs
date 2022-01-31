using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649
public class MapaScene : MonoBehaviour
{
    [SerializeField] private GameObject modalObjetivo;
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
        btnLevel1.onClick.AddListener(() => goToLevelFase(Level.HUM   , new Level1()));
        btnLevel2.onClick.AddListener(() => goToLevelFase(Level.DOIS  , new Level2()));
        btnLevel3.onClick.AddListener(() => goToLevelFase(Level.TRES  , new Level3()));
        btnLevel4.onClick.AddListener(() => goToLevelFase(Level.QUATRO, new Level4()));

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
        //PlayerPrefsFichas.consumirFicha(Ficha.BRONZE, 5);
        //PlayerPrefsFichas.consumirFicha(Ficha.PRATA, 1);
        //PlayerPrefsFichas.consumirFicha(Ficha.OURO, 1);
    }

    private void goToLevelFase(Level levelEnum, AbstractLevel level)
    {
        modalObjetivo.SetActive(true);
        PlayerPrefsLevel.salvarLevel(levelEnum);
        showModalParaOLevel(level);
    }

    private void showModalParaOLevel(AbstractLevel level)
    {
        string nivelName = level.getLevelName();
        string objetivo = level.getMsgObjetivoLevel();

        GameObject nivelText    = GameObject.Find("NivelText");
        GameObject objetivoText = GameObject.Find("ObjetivoText");

        nivelText.GetComponent<Text>().text = nivelName;
        objetivoText.GetComponent<Text>().text = objetivo;
    }
}
