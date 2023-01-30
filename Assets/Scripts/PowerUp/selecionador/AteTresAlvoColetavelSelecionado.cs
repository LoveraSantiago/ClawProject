using System.Collections;
using UnityEngine;

public class AteTresAlvoColetavelSelecionado : SelecaoDeAlvosColetaveis<TrioDeColetaveis>
{
    private int qtdDeSelecionados;
    private MiraSelecionadoOnColetavel miraSelecionadoOnColetavel;

    public AteTresAlvoColetavelSelecionado(
        int qtdDeSelecionados, bool filtrarGaiolas, MiraSelecionadoOnColetavel miraSelecionadoOnColetavel)
        :base(filtrarGaiolas)
    {
        this.qtdDeSelecionados = qtdDeSelecionados;
        this.miraSelecionadoOnColetavel = miraSelecionadoOnColetavel;
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
            miraSelecionadoOnColetavel.coletavelSelecionado(1, coletavel3);
        }

        if(qtdDeSelecionados >= 2)
        {
            yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);
            coletavel2 = selecionadorDeAlvos.goSelecionado;
            coletavel2.ligarAnimacaoMiraSelecionado();
            miraSelecionadoOnColetavel.coletavelSelecionado(2, coletavel2);
        }

        if (qtdDeSelecionados >= 1)
        {
            yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);
            coletavel1 = selecionadorDeAlvos.goSelecionado;
            coletavel1.ligarAnimacaoMiraSelecionado();
            miraSelecionadoOnColetavel.coletavelSelecionado(3, coletavel1);
        }

        desligarMiras();

        TrioDeColetaveis trioDeColetaveis = new TrioDeColetaveis(coletavel1, coletavel2, coletavel3);
        Coroutine coroutine = ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineOnSelecionado.transformar(trioDeColetaveis));
        cacheCoroutineOnSelecionado(coroutine);
        yield return coroutine;
    }   
}
