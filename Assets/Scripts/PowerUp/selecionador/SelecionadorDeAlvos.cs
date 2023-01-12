using System.Collections;
using System.Collections.Generic;

public class SelecionadorDeAlvos<T> where T : GO
{
    public T goSelecionado { get; private set; }
    private List<T> gosJaSelecionados;

    public SelecionadorDeAlvos()
    {
        gosJaSelecionados = new List<T>();
    }   

    public IEnumerator selecionarAlvo(InputGame inputGame, Transformador<InputGame, T> tranformadorHit)
    {
        goSelecionado = null;
        T go = null;
        while (goSelecionado == null)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                go = tranformadorHit.transformar(inputGame);
                if (go != null && isGoNaoSelecionadoAntes(go))
                {
                    goSelecionado = go;
                    gosJaSelecionados.Add(go);
                }
            }
            yield return null;
        }
        yield return null;
    }    

    private bool isGoNaoSelecionadoAntes(T coletavel)
    {
        return !gosJaSelecionados.Contains(coletavel);        
    }
}
