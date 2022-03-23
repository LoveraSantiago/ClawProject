using UnityEngine;

public class ComponenteAnimacaoDaGarra : ComponenteEfeitosDaGarra
{
    private AbstractGarraAnimacao animacao;

    public ComponenteAnimacaoDaGarra(GarraDto garraDto) : 
        base(garraDto){}

    public void irParaDireita()
    {
        animacao.irParaDireita(getAnimator());
    }

    public void irParaEsquerda()
    {
        animacao.irParaEsquerda(getAnimator());
    }

    public void irParaBaixo()
    {
        animacao.irParaBaixo(getAnimator());
    }

    public void irParaCima()
    {
        animacao.irParaCima(getAnimator());
    }

    public void comemorar()
    {
        animacao.comemorar(getAnimator());
    }

    public void piscar()
    {
        animacao.piscar(getAnimator());
    }

    public void girando()
    {
        animacao.girando(getAnimator());
    }

    public bool isComemorando()
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
