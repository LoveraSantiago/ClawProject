using System.Collections;
using UnityEngine;

public class HumAlvoSelecionado 
{   
    private Coroutine coroutineAtual;    

    public IEnumerator onSelecionado(InputGame inputGame, Transformador<ColetavelTile, IEnumerator> coroutineConsumidora)
    {
        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos()
           .ligarMiras();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);

        ColetavelTile coletavelSelecionado = selecionadorDeAlvos.coletavelSelecionado;

        selecionadorDeAlvos.ligarMiraFinal();

        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(coroutineConsumidora.transformar(coletavelSelecionado));
    }

    public void stopCoroutine()
    {
        if(coroutineAtual != null)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutineAtual);
        }
        coroutineAtual = null;
    }
}
