using UnityEngine;

public class MovimentacaoAgarrandoEmcima : MovimentacaoDaGarraPowerUp
{
    private int direcao;

    private Quaternion anguloDesejadoEsquerdaFechado;
    private Quaternion anguloDesejadoDireitaFechado;

    private GarraInteracaoComPowerUp garraInteracaoPowerUp;

    public MovimentacaoAgarrandoEmcima()
    {
        anguloDesejadoDireitaFechado  = Quaternion.Euler(0, 0, garraDto.AnguloFechamento);
        anguloDesejadoEsquerdaFechado = Quaternion.Euler(0, 0, -garraDto.AnguloFechamento);
    }

    public override void preInicio()
    {        
        pincas.acionarCollider();        

        garraInteracaoPowerUp.ligar();
        garraInteracaoPowerUp.desligarGravidade();
        garraInteracaoPowerUp.colocarNaPosicao(garraDto.CentroDaGarra.position);

        direcao = 1;
        dispararEventoDirecao(direcao);//reesincronizarJoystick
    }

    public override void update()
    {
        if (inputGame.aconteceuTapNaAreaSuperior())
        {
            comunicadorComGerMovimentacao.trocarParaAcaoSoltar();
        }
    }

    public override void fixedUpdate()
    {        
        pincas.rotacionarFDT(garraDto.VelocidadeAnguloFechamento, anguloDesejadoEsquerdaFechado, anguloDesejadoDireitaFechado);
        verificarSeMovimentacaoAtingiuLimites();
        moverGarraHorizontalmenteFreeze(direcao);
    }

    public void receberInteracaoComPowerUp(GarraInteracaoComPowerUp garraInteracaoPowerUp)
    {
        this.garraInteracaoPowerUp = garraInteracaoPowerUp;
    }   

    //TODO duplicidade com MovimentacaoLateralZigZag
    private void verificarSeMovimentacaoAtingiuLimites()
    {
        if (isGarraMaiorPosHorizontal(LIMITE_LATERAL_TELA - 0.1f))
        {
            direcao = -1;
            moverGarraHorizontalmenteFreeze(direcao);
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.ESQUERDA);
        }
        else if (isGarraMenorPosHorizontal(-LIMITE_LATERAL_TELA + 0.1f))
        {
            direcao = 1;
            moverGarraHorizontalmenteFreeze(direcao);
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.DIREITA);
        }
        else
        {
            //nada
        }
    }
}
