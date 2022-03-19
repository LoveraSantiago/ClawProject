using UnityEngine;

public class ComponenteRigidBodyDeMovimentacaoGarra : ComponenteEfeitoDeMovimentacaoGarra
{
    protected void parar()
    {
        getGarra().rigidBody.parar();
    }

    protected void colocarNaPosInicial()//REMOVER
    {
        getGarra().rigidBody.colocarNaPosicaoInicial();
    }

    protected void colocarNaPosHorizontal(float posHorizontal)
    {
        getGarra().rigidBody.colocarNaPosicaoHorizontal(posHorizontal);
    }

    protected void colocarMassa(int massa)
    {
        getGarra().rigidBody.colocarMassa(massa);
    }

    protected void moverParaCima()
    {
        getGarra().rigidBody.moverPCima();
    }

    protected void moverParaBaixo()
    {
        getGarra().rigidBody.moverPBaixo();
    }

    protected void moverParaHorizontal(float direcao)
    {
        getGarra().rigidBody.moverPHorizontal(direcao);
    }

    protected void colocarNaAlturaInicial()
    {
        getGarra().rigidBody.colocarNaHalturaInicial();
    }

    protected void fixarVerticalmente()
    {
        getGarra().rigidBody.fixarVerticalmente();
    }

    protected void fixarHorizontalmente()
    {
        getGarra().rigidBody.fixarHorizontalmente();
    }

    protected void fixarVerticalEHorizontal()
    {
        getGarra().rigidBody.fixarVerticalEHorizontal();
    }

    protected void desafixar()
    {
        getGarra().rigidBody.desafixar();
    }

    protected bool isAcimaPosInicial()
    {
        return getGarra().rigidBody.isAcimaPosInicial();
    }

    protected bool isMaiorPosHorizontal(float posHorizontal)
    {
        return getGarra().rigidBody.isMaiorPosHorizontal(posHorizontal);
    }

    protected bool isMenorPosHorizontal(float posHorizontal)
    {
        return getGarra().rigidBody.isMenorPosHorizontal(posHorizontal);
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
