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
        btnZigZag.onClick.AddListener(() => irParaGameComMecanicaZigZag());
        btnTeleguiado.onClick.AddListener(() => irParaGameComMecanicaTeleguiada());
        btnZigZagTeleguiado.onClick.AddListener(() => irParaGameComMecanicaZigZagTeleguiado());
    }    

    private void irParaGameComMecanicaZigZag()
    {
        irParaMainScene();
    }

    private void irParaGameComMecanicaTeleguiada()
    {
        irParaMainScene();
    }

    private void irParaGameComMecanicaZigZagTeleguiado()
    {
        irParaMainScene();
    }

    private void irParaMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
