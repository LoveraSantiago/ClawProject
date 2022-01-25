using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Transform transformSegundos;
    [SerializeField] private Transform transformMinutos;
    [SerializeField] private Transform transformHoras;
    [Space(5)]
    [SerializeField] private BotoesCenasDto botoesCenasDto;

    private ContadorDeTempo contadorSegundos;
    private ContadorDeTempo contadorMinutos;
    private ContadorDeTempo contadorHoras;

    private void Start()
    {
        btnLevel1.onClick.AddListener(() => goToLevelFase(Level.HUM   , new Level1()));
        btnLevel2.onClick.AddListener(() => goToLevelFase(Level.DOIS  , new Level2()));
        btnLevel3.onClick.AddListener(() => goToLevelFase(Level.TRES  , new Level3()));
        btnLevel4.onClick.AddListener(() => goToLevelFase(Level.QUATRO, new Level4()));

        new BotoesCenasMapa(botoesCenasDto);

        contadorSegundos = new ContadorDeTempo(1.0f);
        contadorMinutos = new ContadorDeTempo(60.0f);
        contadorHoras = new ContadorDeTempo(3600.0f);
    }

    private void Update()
    {
        bool contou1Segundo = contadorSegundos.contarTempoFDT();
        if (contou1Segundo)
        {
            Vector3 result = transformSegundos.rotation.eulerAngles - new Vector3(0, 0, 6);
            Quaternion rotacao = Quaternion.Euler(result);
            transformSegundos.rotation = rotacao;

            contadorSegundos.resetContador();
        }

        bool contou1Minuto = contadorMinutos.contarTempoFDT();
        if (contou1Minuto)
        {
            Vector3 result = transformMinutos.rotation.eulerAngles - new Vector3(0, 0, 6);
            Quaternion rotacao = Quaternion.Euler(result);
            transformMinutos.rotation = rotacao;

            contadorMinutos.resetContador();
        }

        bool contou1Hora = contadorHoras.contarTempoFDT();
        if (contou1Hora)
        {
            Vector3 result = transformHoras.rotation.eulerAngles - new Vector3(0, 0, 6);
            Quaternion rotacao = Quaternion.Euler(result);
            transformHoras.rotation = rotacao;

            contadorHoras.resetContador();
        }
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
