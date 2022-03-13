using UnityEngine;

public class ComponenteEstadoDeGO : ComponentePosicaoDeGO
{
    private bool ativo;

    public ComponenteEstadoDeGO(GameObject go) 
        : base(go){}

    public virtual void ligar()
    {
        ativo = true;
        getGo().SetActive(true);
    }

    public virtual void desligar()
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
