using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeMovimentacaoPowerUp : GerenciadorDeMovimentacao,
                                                ComunicadorComGerMovPowerUp
{
    private MovimentacaoDaGarra movimentacaoAtual;

    private ContadorDeTempo contadorDeFimTempo;

    public GerenciadorDeMovimentacaoPowerUp()
    {
        MovimentacaoDaGarraPowerUp.configurarComunicadorComGerMovimentacao(this);
    }

    //IMPLEMENTANDO INTERFACE GERENCIADORDEMOVIMENTACAO INICIO
    public void iniciarMovimentacoes()
    {
        MovimentacaoDaGarraHorizontal.produtorEventoDirecao.produziuEvento(DirecaoDaGarra.CENTRALIZADA);
    }

    public void update()
    {
        if (contadorDeFimTempo.contarTempoDT() && isEstadoAtualCentralizado())
        {
            //acaoSoltarPowerUp();
        }

    }

    public void fixedUpdate()
    {

    }
    //IMPLEMENTANDO INTERFACE GERENCIADORDEMOVIMENTACAO FIM

    public void receberGarraInteracaoComPowerUp(GarraInteracaoComPowerUp garraInteracaoPowerUp, float tempoDuracao)
    {
        //this.garraInteracaoPowerUp = garraInteracaoPowerUp;
        contadorDeFimTempo.configTempoParaAcao(tempoDuracao);
    }

    private bool isEstadoAtualCentralizado()
    {
        //return movimentacaoAtual == ALGUM_ESTADO_CENTRALIZADO;
        return false;
    }

    //TODO REFATORAR COM GERENCIADOR DE MOVIMENTACAO NORMAL
    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movimentacaoAtual = movimentador;
    }
}
