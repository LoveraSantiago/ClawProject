using System.Collections;
using UnityEngine;

public abstract class SelecaoDeAlvos<T>
{
    private Coroutine coroutineOnSelecionado;

    public void ligarMiras(bool filtrarGaiolas)
    {
        HelperColetaveisInGame.ligarMirasNosColetaveis(filtrarGaiolas);        
    }

    public void ligarMiraFinal(Coletavel coletavelSelecionado)
    {
        if (coletavelSelecionado != null)
        {
            HelperColetaveisInGame.ligarMiraAlvoFinalNoColetavel(coletavelSelecionado.nome);
        }        
    }

    public void desligarMiras()
    {
        HelperColetaveisInGame.desligarMirasNosColetaveis();
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
            ContextoEstaticoUtils.monoBehaviour.StopCoroutine(coroutineOnSelecionado);
            coroutineOnSelecionado = null;
        }
    }
}
