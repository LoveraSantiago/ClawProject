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
            SelecionadorDeAlvos<Gaiola> selecionadorDeAlvos = new SelecionadorDeAlvos<Gaiola>();
            yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);
        }
    }

    public IEnumerator transformar(Coletavel entrada)
    {
        coletavelSelecionado = entrada;
        yield return null;
    }

    public Gaiola transformar(InputGame entrada)
    {
        return GaiolaHit.hit(entrada);
    }
}
