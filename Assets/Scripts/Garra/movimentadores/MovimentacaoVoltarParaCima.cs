using UnityEngine;

public class MovimentacaoVoltarParaCima : AbstractMovimentacaoDaGarra
{
    private ComunicadorComGerenciadorComum comunicadorComGerMovimentacaoComum;

    public MovimentacaoVoltarParaCima(ComunicadorComGerenciadorComum comunicadorComGerMovimentacaoComum)
    {
        this.comunicadorComGerMovimentacaoComum = comunicadorComGerMovimentacaoComum;
    }

    public override void preInicio()
    {
        colocarMassa(getMassaMovimentacaoCima());
        playAnimacaoIrPCima();
        playSomGarraMovimentoVertical();
    }

    public override void update(InputGame inputGame)
    {
        if (isAcimaPosInicial())
        {
            //Debug.Log("isAcimaPosInicial");
            stopSomGarraMovimentoVertical();
            parar();
            colocarNaAlturaInicial();
            comunicadorComGerMovimentacaoComum.trocarParaAcaoVoltarParaMeio();
        }
    }

    public override void fixedUpdate()
    {
        moverParaCimaFreeze();
        Quaternion angIdleMinEsquerda = getAnguloIdleMinEsquerda();
        Quaternion angIdleMinDireita = getAnguloIdleMinDireita();
        rotacionarPincaVelocidadeAberturaFDT(angIdleMinEsquerda, angIdleMinDireita);
    }
}
