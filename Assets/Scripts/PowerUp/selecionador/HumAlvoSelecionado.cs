using System.Collections;

public class HumAlvoSelecionado : SelecaoDeAlvos<Coletavel>
{   

    public IEnumerator onSelecionado(bool filtrarGaiolas, InputGame inputGame, Transformador<Coletavel, IEnumerator> coroutineConsumidora)
    {
        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos()
           .ligarMiras(filtrarGaiolas);

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);

        Coletavel coletavelSelecionado = selecionadorDeAlvos.coletavelSelecionado;

        selecionadorDeAlvos.ligarMiraFinal();

        yield return Utils.MonoBehaviour.StartCoroutine(coroutineConsumidora.transformar(coletavelSelecionado));
    }
}