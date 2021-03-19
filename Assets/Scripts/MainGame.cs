using UnityEngine;

public class MainGame : MonoBehaviour
{
    [SerializeField] ComponentesDaGarraDto componentesDaGarra;
    [Space(5)]
    [SerializeField] ColetaveisDto coletaveisDto;

    private Garra garra;
    private Coletaveis coletaveis;

    void Start()
    {
        garra = new Garra(componentesDaGarra);
        coletaveis = new Coletaveis(coletaveisDto);
    }

    
    void Update()
    {
        garra.Update();
        //coletaveis.Update();
    }

    private void FixedUpdate()
    {
        garra.FixedUpdate();
        coletaveis.FixedUpdate();
    }
}
