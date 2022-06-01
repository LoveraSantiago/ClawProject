using System.Collections;
using UnityEngine;

public abstract class SelecaoDeAlvos<T>
{
    private Coroutine coroutineOnSelecionado;

    public void ligarMiras(bool filtrarGaiolas)
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.ligarMirasNosColetaveis(filtrarGaiolas);        
    }

    public void ligarMiraFinal(Coletavel coletavelSelecionado)
    {
        if (coletavelSelecionado != null)
        {
            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            helperInGame.ligarMiraAlvoFinalNoColetavel(coletavelSelecionado.nome);
        }        
    }

    public void desligarMiras()
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.desligarMirasNosColetaveis();
    }

    public abstract IEnumerator onSelecionar(InputGame inputGame, Transformador<T, IEnumerator> coroutineOnSelecionado);

    protected void cacheCoroutineOnSelecionado(Coroutine coroutine)
    {
        coroutineOnSelecionado = coroutine;
    }

    public void timeout()
    {
        if(coroutineOnSelecionado != null)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutineOnSelecionado);
            coroutineOnSelecionado = null;
        }
    }
}
