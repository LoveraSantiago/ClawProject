using System.Collections;

public class HumAlvoSelecionado : SelecaoDeAlvos<Coletavel>,
                                  Transformador<InputGame, Coletavel>
{   

    public override IEnumerator onSelecionar(
        bool filtrarGaiolas, InputGame inputGame, Transformador<Coletavel, IEnumerator> coroutineOnSelecionado)
    {
        ligarMiras(filtrarGaiolas);
        SelecionadorDeAlvos<Coletavel> selecionadorDeAlvos = new SelecionadorDeAlvos<Coletavel>();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);

        Coletavel coletavelSelecionado = selecionadorDeAlvos.goSelecionado;
        ligarMiraFinal(coletavelSelecionado);

        yield return Utils.MonoBehaviour.StartCoroutine(coroutineOnSelecionado.transformar(coletavelSelecionado));
    }

    public Coletavel transformar(InputGame entrada)
    {
        return ColetavelHit.hit(entrada);
    }
}