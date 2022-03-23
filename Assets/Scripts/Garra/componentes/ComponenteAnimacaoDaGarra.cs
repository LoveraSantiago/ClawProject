public class ComponenteAnimacaoDaGarra : ComponenteEfeitosDaGarra
{
    private AbstractGarraAnimacao animacao;

    public ComponenteAnimacaoDaGarra(GarraDto garraDto) : 
        base(garraDto){}

    public void irParaDireita()
    {
        animacao.irParaDireita();
    }

    public void irParaEsquerda()
    {
        animacao.irParaEsquerda();
    }

    public void irParaBaixo()
    {
        animacao.irParaBaixo();
    }

    public void irParaCima()
    {
        animacao.irParaCima();
    }

    public void comemorar()
    {
        animacao.comemorar();
    }

    public void piscar()
    {
        animacao.piscar();
    }

    public void girando()
    {
        animacao.girando();
    }

    public bool isComemorando()
    {
        return animacao.isComemorando();
    }

    protected void animacaoMacho()
    {
        animacao = new GarraAnimacaoMacho(garraDto.Corpo.Animator);
    }

    protected void animacaoFemea()
    {
        animacao = new GarraAnimacaoFemea(garraDto.Corpo.Animator);
    }
}
