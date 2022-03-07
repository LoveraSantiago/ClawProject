using System.Collections;

public class HumAlvoColetavelSelecionado : SelecaoDeAlvosColetaveis<Coletavel>
{
    public HumAlvoColetavelSelecionado(bool filtrarGaiolas)
        : base(filtrarGaiolas){}

    public override IEnumerator onSelecionar(
        InputGame inputGame, Transformador<Coletavel, IEnumerator> coroutineOnSelecionado)
    {
        ligarMiras(filtrarGaiolas);
        SelecionadorDeAlvos<Coletavel> selecionadorDeAlvos = new SelecionadorDeAlvos<Coletavel>();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);

        Coletavel coletavelSelecionado = selecionadorDeAlvos.goSelecionado;
        ligarMiraFinal(coletavelSelecionado);

        yield return Utils.MonoBehaviour.StartCoroutine(coroutineOnSelecionado.transformar(coletavelSelecionado));
    }    
}