using UnityEngine;

public class ComponenteEstadoDeGO : ComponentePosicaoDeGO
{
    private bool ativo;

    public ComponenteEstadoDeGO(GameObject go) 
        : base(go){}

    public virtual void ligarComEstado()
    {
        ativo = true;
        ligar();
    }

    public virtual void desligarComEstado()
    {
        ativo = false;
        desligar();
    }

    public void ligar()
    {
        getGo().SetActive(true);
    }

    public void desligar()
    {
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
