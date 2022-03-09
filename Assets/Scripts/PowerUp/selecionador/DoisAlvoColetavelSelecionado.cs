using System.Collections;

public class DoisAlvoColetavelSelecionado : SelecaoDeAlvosColetaveis<DuplaDeColetaveisDto>
{
    public DoisAlvoColetavelSelecionado(bool filtrarGaiolas) 
        : base(filtrarGaiolas){}

    public override IEnumerator onSelecionar(
        InputGame inputGame, Transformador<DuplaDeColetaveisDto, IEnumerator> coroutineOnSelecionado)
    {
        ligarMiras(filtrarGaiolas);
        SelecionadorDeAlvos<Coletavel> selecionadorDeAlvos = new SelecionadorDeAlvos<Coletavel>();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);

        Coletavel coletavel1 = selecionadorDeAlvos.goSelecionado;
        coletavel1.ligarAnimacaoMiraSelecionado();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);
        Coletavel coletavel2 = selecionadorDeAlvos.goSelecionado;

        ligarMiraFinal(coletavel1);

        DuplaDeColetaveisDto duplaDeColetaveis = new DuplaDeColetaveisDto(coletavel1, coletavel2);
        yield return Utils.MonoBehaviour.StartCoroutine(coroutineOnSelecionado.transformar(duplaDeColetaveis));
    }    
}
