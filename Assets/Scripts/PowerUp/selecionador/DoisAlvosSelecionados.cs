using System.Collections;

public class DoisAlvosSelecionados 
{
    public IEnumerator onSelecionados(InputGame inputGame, BiTransformadorUnario<Coletavel, IEnumerator> coroutineConsumidora)
    {
        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos()
           .ligarMiras();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);

        Coletavel coletavel1 = selecionadorDeAlvos.coletavelSelecionado;
        coletavel1.ligarAnimacaoMiraSelecionado();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);
        Coletavel coletavel2 = selecionadorDeAlvos.coletavelSelecionado;

        selecionadorDeAlvos.ligarMiraFinal();

        yield return Utils.MonoBehaviour.StartCoroutine(coroutineConsumidora.transformar(coletavel1, coletavel2));
    }
}
