using UnityEngine;

public class ComponenteEstadoDeGO : ComponentePosicaoDeGO
{
    private bool ativo;

    public ComponenteEstadoDeGO(GameObject go) 
        : base(go){}

    public void ligar()
    {
        ativo = true;
        getGo().SetActive(true);
    }

    public void desligar()
    {
        ativo = false;
        getGo().SetActive(false);
    }

    public bool isAtivo()
    {
        return ativo;
    }

    public bool isNotAtivo()
    {
        return !isAtivo();
    }
}
