using System.Collections;

public class DoisAlvosSelecionados : SelecaoDeAlvos<DuplaDeColetaveisDto>
{    
    public override IEnumerator onSelecionado(bool filtrarGaiolas, InputGame inputGame, Transformador<DuplaDeColetaveisDto, IEnumerator> coroutineConsumidora)
    {
        ligarMiras(filtrarGaiolas);
        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);

        Coletavel coletavel1 = selecionadorDeAlvos.coletavelSelecionado;
        coletavel1.ligarAnimacaoMiraSelecionado();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);
        Coletavel coletavel2 = selecionadorDeAlvos.coletavelSelecionado;

        ligarMiraFinal(coletavel1);

        DuplaDeColetaveisDto duplaDeColetaveis = new DuplaDeColetaveisDto(coletavel1, coletavel2);
        yield return Utils.MonoBehaviour.StartCoroutine(coroutineConsumidora.transformar(duplaDeColetaveis));
    }
}
