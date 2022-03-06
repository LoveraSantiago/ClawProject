using System.Collections;

public class HumAlvoGOSelecionado : SelecaoDeAlvos<GO>,
                                    Transformador<Coletavel, IEnumerator>,
                                    Transformador<InputGame, Gaiola>

{
    private Coletavel coletavelSelecionado;

    public override IEnumerator onSelecionar(
        bool filtrarGaiolas, InputGame inputGame, Transformador<GO, IEnumerator> coroutineOnSelecionado)
    {
        HumAlvoColetavelSelecionado alvoColetavelSelecionado = new HumAlvoColetavelSelecionado();
        yield return alvoColetavelSelecionado.onSelecionar(filtrarGaiolas, inputGame, this);

        if (coletavelSelecionado.isLivre())
        {
            yield return coroutineOnSelecionado.transformar(coletavelSelecionado);
        }
        else
        {
            string nomeGaiola = coletavelSelecionado.nomeGaiolaAprisionadora;
            HelperGaiolasInGame helperInGame = new HelperGaiolasInGame();
            Gaiola gaiolaSelecionada = helperInGame.getGaiolaInGameByGoName(nomeGaiola);
            yield return coroutineOnSelecionado.transformar(gaiolaSelecionada);
        }
    }

    public IEnumerator transformar(Coletavel entrada)
    {
        coletavelSelecionado = entrada;
        yield return null;
    }

    public Gaiola transformar(InputGame entrada)
    {
        return GaiolaInputHit.hit(entrada);
    }
}
