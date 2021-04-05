using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private Button btnZigZag;
    [SerializeField] private Button btnTeleguiado;
    [SerializeField] private Button btnZigZagTeleguiado;

    private void Start()
    {
        Camera.main.aspect = Utils.RATIO_SCREEN;

        btnZigZag.onClick.AddListener(() => irParaGameComMecanicaZigZag());
        btnTeleguiado.onClick.AddListener(() => irParaGameComMecanicaTeleguiada());
        btnZigZagTeleguiado.onClick.AddListener(() => irParaGameComMecanicaZigZagTeleguiado());
    }    

    private void irParaGameComMecanicaZigZag()
    {
        PlayerPrefsGarraMecanica.salvarMecanica(GarraManager.MECANICA_GARRA.ZIG_ZAG);
        irParaMainScene();
    }

    private void irParaGameComMecanicaTeleguiada()
    {
        PlayerPrefsGarraMecanica.salvarMecanica(GarraManager.MECANICA_GARRA.TELEGUIADA);
        irParaMainScene();
    }

    private void irParaGameComMecanicaZigZagTeleguiado()
    {
        PlayerPrefsGarraMecanica.salvarMecanica(GarraManager.MECANICA_GARRA.ZIG_ZAGTELEGUIADO);
        irParaMainScene();
    }

    public void irParaMainScene()
    {        
        SceneManager.LoadScene("MapScene");
    }
}
