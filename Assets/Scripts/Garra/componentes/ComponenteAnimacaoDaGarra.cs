using UnityEngine;

public class ComponenteAnimacaoDaGarra : ComponenteEfeitosDaGarra
{
    private AbstractGarraAnimacao animacao;

    public ComponenteAnimacaoDaGarra(GarraDto garraDto, SomGarra somGarra) : 
        base(garraDto, somGarra){}

    public void animacaoParaDireita()
    {
        animacao.irParaDireita(getAnimator());
    }

    public void animacaoParaEsquerda()
    {
        animacao.irParaEsquerda(getAnimator());
    }

    public void animacaoParaBaixo()
    {
        animacao.irParaBaixo(getAnimator());
    }

    public void animacaoParaCima()
    {
        animacao.irParaCima(getAnimator());
    }

    public void animacaoComemorar()
    {
        animacao.comemorar(getAnimator());
    }

    public void animacaoPiscar()
    {
        animacao.piscar(getAnimator());
    }

    public void animacaoGirando()
    {
        animacao.girando(getAnimator());
    }

    public bool isAnimacaoComemorando()
    {
        return animacao.isComemorando(getAnimator());
    }

    protected void animacaoMacho()
    {
        animacao = new GarraAnimacaoMacho();
    }

    protected void animacaoFemea()
    {
        animacao = new GarraAnimacaoFemea();
    }

    protected Animator getAnimator()
    {
        return garraDto.Corpo.Animator;
    }
}
