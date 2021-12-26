using System.Collections;

public class DoisAlvosSelecionados 
{
    public IEnumerator onSelecionados(InputGame inputGame, BiTransformadorUnario<ColetavelTile, IEnumerator> coroutineConsumidora)
    {
        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos()
           .ligarMiras();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);

        ColetavelTile coletavel1 = selecionadorDeAlvos.coletavelSelecionado;
        coletavel1.ligarAnimacaoMiraSelecionado();

        yield return selecionadorDeAlvos.selecionarAlvoDiferenteDe(inputGame, coletavel1.nome);
        ColetavelTile coletavel2 = selecionadorDeAlvos.coletavelSelecionado;

        selecionadorDeAlvos.ligarMiraFinal();

        Utils.MonoBehaviour.StartCoroutine(coroutineConsumidora.transformar(coletavel1, coletavel2));
    }
}
