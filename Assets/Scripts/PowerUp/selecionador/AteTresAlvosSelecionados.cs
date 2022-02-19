using System.Collections;

public class AteTresAlvosSelecionados : SelecaoDeAlvos<TrioDeColetaveis>
{
    private int qtdDeSelecionados;

    public AteTresAlvosSelecionados(int qtdDeSelecionados)
    {
        this.qtdDeSelecionados = qtdDeSelecionados;
    }

    public IEnumerator onSelecionado(InputGame inputGame, Transformador<TrioDeColetaveis, IEnumerator> coroutineConsumidora)
    {
        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos()
           .ligarMiras();

        Coletavel coletavel1 = null;
        Coletavel coletavel2 = null;
        Coletavel coletavel3 = null;       

        if(qtdDeSelecionados == 3)
        {
            yield return selecionadorDeAlvos.selecionarAlvo(inputGame);
            coletavel3 = selecionadorDeAlvos.coletavelSelecionado;
            coletavel3.ligarAnimacaoMiraSelecionado();
        }

        if(qtdDeSelecionados >= 2)
        {
            yield return selecionadorDeAlvos.selecionarAlvo(inputGame);
            coletavel2 = selecionadorDeAlvos.coletavelSelecionado;
            coletavel2.ligarAnimacaoMiraSelecionado();
        }

        if (qtdDeSelecionados >= 1)
        {
            yield return selecionadorDeAlvos.selecionarAlvo(inputGame);
            coletavel1 = selecionadorDeAlvos.coletavelSelecionado;
            coletavel1.ligarAnimacaoMiraSelecionado();
        }

        TrioDeColetaveis trioDeColetaveis = new TrioDeColetaveis(coletavel1, coletavel2, coletavel3);
        yield return Utils.MonoBehaviour.StartCoroutine(coroutineConsumidora.transformar(trioDeColetaveis));
    }
}
