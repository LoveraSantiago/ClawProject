using System.Collections;

public class AteTresAlvosSelecionados : SelecaoDeAlvos<TrioDeColetaveis>,
                                        Transformador<InputGame, Coletavel>
{
    private int qtdDeSelecionados;

    public AteTresAlvosSelecionados(int qtdDeSelecionados)
    {
        this.qtdDeSelecionados = qtdDeSelecionados;
    }

    public override IEnumerator onSelecionado(bool filtrarGaiolas, InputGame inputGame, Transformador<TrioDeColetaveis, IEnumerator> coroutineConsumidora)
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

        ligarMiraFinal(coletavel1);

        TrioDeColetaveis trioDeColetaveis = new TrioDeColetaveis(coletavel1, coletavel2, coletavel3);
        yield return Utils.MonoBehaviour.StartCoroutine(coroutineConsumidora.transformar(trioDeColetaveis));
    }

    public Coletavel transformar(InputGame entrada)
    {
        return ColetavelHit.hit(entrada);
    }
}
