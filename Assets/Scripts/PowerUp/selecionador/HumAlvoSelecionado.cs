using System.Collections;

public class HumAlvoSelecionado : SelecaoDeAlvos<Coletavel>
{   

    public override IEnumerator onSelecionado(bool filtrarGaiolas, InputGame inputGame, Transformador<Coletavel, IEnumerator> coroutineConsumidora)
    {
        ligarMiras(filtrarGaiolas);
        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);

        Coletavel coletavelSelecionado = selecionadorDeAlvos.coletavelSelecionado;
        ligarMiraFinal(coletavelSelecionado);

        yield return Utils.MonoBehaviour.StartCoroutine(coroutineConsumidora.transformar(coletavelSelecionado));
    }
}