using System.Collections;

public class DoisAlvosSelecionados : SelecaoDeAlvos<DuplaDeColetaveisDto>
{    
    public IEnumerator onSelecionado(bool filtrarGaiolas, InputGame inputGame, Transformador<DuplaDeColetaveisDto, IEnumerator> coroutineConsumidora)
    {
        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos()
           .ligarMiras(filtrarGaiolas);

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);

        Coletavel coletavel1 = selecionadorDeAlvos.coletavelSelecionado;
        coletavel1.ligarAnimacaoMiraSelecionado();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);
        Coletavel coletavel2 = selecionadorDeAlvos.coletavelSelecionado;

        selecionadorDeAlvos.ligarMiraFinal();

        DuplaDeColetaveisDto duplaDeColetaveis = new DuplaDeColetaveisDto(coletavel1, coletavel2);
        yield return Utils.MonoBehaviour.StartCoroutine(coroutineConsumidora.transformar(duplaDeColetaveis));
    }
}
