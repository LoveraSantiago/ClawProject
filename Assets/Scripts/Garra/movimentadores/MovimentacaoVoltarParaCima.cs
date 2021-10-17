using UnityEngine;

public class MovimentacaoVoltarParaCima : MovimentacaoDaGarraPowerUp
{
    public MovimentacaoVoltarParaCima()
    {     
    }

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
        Quaternion angIdleMinEsquerda = angulosTemp.angIdleMinEsquerda;
        Quaternion angIdleMinDireita  = angulosTemp.angIdleMinDireita;
        rotacionarPincaFDT(garra.garraDto.Velocidades.MovAnguloAbertura, angIdleMinEsquerda, angIdleMinDireita);
    }
}
