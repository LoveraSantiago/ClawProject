using UnityEngine;

public class MovimentacaoVoltarParaCima : AbstractMovimentacaoDaGarraPowerUp
{
    public override void preInicio()
    {
        colocarMassa(3);
        playAnimacaoIrPCima();
    }

    public override void update(InputGame inputGame)
    {
        if (isAcimaPosInicial())
        {
            parar();
            colocarNaAlturaInicial();
            comunicadorComGerMovimentacao.trocarParaAcaoVoltarParaMeio();
        }
    }

    public override void fixedUpdate()
    {
        moverParaCimaFreeze();
        Quaternion angIdleMinEsquerda = getAnguloIdleMinEsquerda();
        Quaternion angIdleMinDireita  = getAnguloIdleMinDireita();        
        rotacionarPincaVelocidadeAberturaFDT(angIdleMinEsquerda, angIdleMinDireita);
    }
}
