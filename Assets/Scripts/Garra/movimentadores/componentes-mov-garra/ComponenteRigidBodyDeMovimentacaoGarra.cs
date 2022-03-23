using UnityEngine;

public class ComponenteRigidBodyDeMovimentacaoGarra : ComponenteEfeitoDeMovimentacaoGarra
{
    protected void parar()
    {
        getGarra().parar();
    }

    protected void colocarNaPosInicial()//REMOVER
    {
        getGarra().colocarNaPosicaoInicial();
    }

    protected void colocarNaPosHorizontal(float posHorizontal)
    {
        getGarra().colocarNaPosicaoHorizontal(posHorizontal);
    }

    protected void colocarMassa(int massa)
    {
        getGarra().colocarMassa(massa);
    }

    protected void moverParaCima()
    {
        getGarra().moverPCima();
    }

    protected void moverParaBaixo()
    {
        getGarra().moverPBaixo();
    }

    protected void moverParaHorizontal(float direcao)
    {
        getGarra().moverPHorizontal(direcao);
    }

    protected void colocarNaAlturaInicial()
    {
        getGarra().colocarNaHalturaInicial();
    }

    protected void fixarVerticalmente()
    {
        getGarra().fixarVerticalmente();
    }

    protected void fixarHorizontalmente()
    {
        getGarra().fixarHorizontalmente();
    }

    protected void fixarVerticalEHorizontal()
    {
        getGarra().fixarVerticalEHorizontal();
    }

    protected void desafixar()
    {
        getGarra().desafixar();
    }

    protected bool isAcimaPosInicial()
    {
        return getGarra().isAcimaPosInicial();
    }

    protected bool isMaiorPosHorizontal(float posHorizontal)
    {
        return getGarra().isMaiorPosHorizontal(posHorizontal);
    }

    protected bool isMenorPosHorizontal(float posHorizontal)
    {
        return getGarra().isMenorPosHorizontal(posHorizontal);
    }

    protected Vector3 getPosicaoCentroGarra()
    {
        return getGarra().getPosicaoCentroGarra();
    }

    protected float getPosicaoHorizontalMeio()
    {
        return 0;
    }

    protected float getPosicaoCacaNiquel()
    {
        return getGarra().getPosicaoCacaNiquel();
    }
}
