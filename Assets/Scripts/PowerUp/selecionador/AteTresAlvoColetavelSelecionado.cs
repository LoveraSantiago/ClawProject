using System.Collections;
using UnityEngine;

public class AteTresAlvoColetavelSelecionado : SelecaoDeAlvosColetaveis<TrioDeColetaveis>
{
    private int qtdDeSelecionados;

    public AteTresAlvoColetavelSelecionado(int qtdDeSelecionados, bool filtrarGaiolas)
        :base(filtrarGaiolas)
    {
        this.qtdDeSelecionados = qtdDeSelecionados;
    }

    public override IEnumerator onSelecionar(
        InputGame inputGame, Transformador<TrioDeColetaveis, IEnumerator> coroutineOnSelecionado)
    {
        ligarMiras(filtrarGaiolas);
        SelecionadorDeAlvos<Coletavel> selecionadorDeAlvos = new SelecionadorDeAlvos<Coletavel>();

        Coletavel coletavel1 = null;
        Coletavel coletavel2 = null;
        Coletavel coletavel3 = null;       

        if(qtdDeSelecionados == 3)
        {
            yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);
            coletavel3 = selecionadorDeAlvos.goSelecionado;
            coletavel3.ligarAnimacaoMiraSelecionado();
        }

        if(qtdDeSelecionados >= 2)
        {
            yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);
            coletavel2 = selecionadorDeAlvos.goSelecionado;
            coletavel2.ligarAnimacaoMiraSelecionado();
        }

        if (qtdDeSelecionados >= 1)
        {
            yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);
            coletavel1 = selecionadorDeAlvos.goSelecionado;
            coletavel1.ligarAnimacaoMiraSelecionado();
        }

        desligarMiras();

        TrioDeColetaveis trioDeColetaveis = new TrioDeColetaveis(coletavel1, coletavel2, coletavel3);
        Coroutine coroutine = Utils.MonoBehaviour.StartCoroutine(coroutineOnSelecionado.transformar(trioDeColetaveis));
        cacheCoroutineOnSelecionado(coroutine);
        yield return coroutine;
    }   
}
