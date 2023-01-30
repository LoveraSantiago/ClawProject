using System.Collections;
using UnityEngine;

public class DoisAlvoColetavelSelecionado : SelecaoDeAlvosColetaveis<DuplaDeColetaveisDto>
{
    private MiraSelecionadoOnColetavel miraSelecionadoOnColetavel;

    public DoisAlvoColetavelSelecionado(bool filtrarGaiolas, MiraSelecionadoOnColetavel miraSelecionadoOnColetavel) 
        : base(filtrarGaiolas)
    {
        this.miraSelecionadoOnColetavel = miraSelecionadoOnColetavel;
    }

    public override IEnumerator onSelecionar(
        InputGame inputGame, Transformador<DuplaDeColetaveisDto, IEnumerator> coroutineOnSelecionado)
    {
        ligarMiras(filtrarGaiolas);
        SelecionadorDeAlvos<Coletavel> selecionadorDeAlvos = new SelecionadorDeAlvos<Coletavel>();

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);

        Coletavel coletavel1 = selecionadorDeAlvos.goSelecionado;
        coletavel1.ligarAnimacaoMiraSelecionado();
        miraSelecionadoOnColetavel.coletavelSelecionado(1, coletavel1);

        yield return selecionadorDeAlvos.selecionarAlvo(inputGame, this);
        Coletavel coletavel2 = selecionadorDeAlvos.goSelecionado;
        miraSelecionadoOnColetavel.coletavelSelecionado(2, coletavel2);

        ligarMiraFinal(coletavel1);

        DuplaDeColetaveisDto duplaDeColetaveis = new DuplaDeColetaveisDto(coletavel1, coletavel2);

        Coroutine coroutine = ContextoEstaticoUtils.monoBehaviour.StartCoroutine(coroutineOnSelecionado.transformar(duplaDeColetaveis));
        cacheCoroutineOnSelecionado(coroutine);
        yield return coroutine;
    }    
}
