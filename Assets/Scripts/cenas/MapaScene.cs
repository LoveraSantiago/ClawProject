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

    private ContadorDeTempo contadorTempo;
    private int contadorSegundosParaMinutos;
    private int contadorSegundosParaHoras;

    private void Start()
    {
        btnLevel1.onClick.AddListener(() => goToLevelFase(Level.HUM   , new Level1()));
        btnLevel2.onClick.AddListener(() => goToLevelFase(Level.DOIS  , new Level2()));
        btnLevel3.onClick.AddListener(() => goToLevelFase(Level.TRES  , new Level3()));
        btnLevel4.onClick.AddListener(() => goToLevelFase(Level.QUATRO, new Level4()));

        new BotoesCenasMapa(botoesCenasDto);

        contadorTempo = new ContadorDeTempo(1.0f);
    }

    private void Update()
    {
        bool contou1Segundo = contadorTempo.contarTempoFDT();
        if (contou1Segundo)
        {
            Vector3 result = transformSegundos.rotation.eulerAngles - new Vector3(0, 0, 6);
            Quaternion rotacao = Quaternion.Euler(result);
            transformSegundos.rotation = rotacao;

            contadorSegundosParaMinutos++;
            if(contadorSegundosParaMinutos == 60)
            {
                Vector3 resultMinuto = transformMinutos.rotation.eulerAngles - new Vector3(0, 0, 6);
                Quaternion rotacaoMinuto = Quaternion.Euler(resultMinuto);
                transformMinutos.rotation = rotacaoMinuto;

                contadorSegundosParaMinutos = 0;
            }

            contadorSegundosParaHoras++;
            if(contadorSegundosParaHoras == 3600)
            {
                Vector3 resultHora = transformHoras.rotation.eulerAngles - new Vector3(0, 0, 6);
                Quaternion rotacaoHora = Quaternion.Euler(resultHora);
                transformHoras.rotation = rotacaoHora;

                contadorSegundosParaHoras = 0;
            }

            contadorTempo.resetContador();
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
