using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeMovimentacaoPowerUp : GerenciadorDeMovimentacao
{
    private MovimentacaoDaGarra movimentacaoAtual;

    private ContadorDeTempo contadorDeFimTempo;

    //IMPLEMENTANDO INTERFACE GERENCIADORDEMOVIMENTACAO INICIO
    public void iniciarMovimentacoes()
    {
        
    }

    public void update()
    {
        if (contadorDeFimTempo.contarTempoDT() && isEstadoAtualCentralizado())
        {
            acaoSoltarPowerUp();
        }

    }
    //IMPLEMENTANDO INTERFACE GERENCIADORDEMOVIMENTACAO FIM

    public void receberGarraInteracaoComPowerUp(GarraInteracaoComPowerUp garraInteracaoPowerUp, float tempoDuracao)
    {
        this.garraInteracaoPowerUp = garraInteracaoPowerUp;
        contadorDeFimTempo.configTempoParaAcao(tempoDuracao);
    }

    private bool isEstadoAtualCentralizado()
    {
        return movimentacaoAtual == ALGUM_ESTADO_CENTRALIZADO;
        //return false;
    }

    //TODO REFATORAR COM GERENCIADOR DE MOVIMENTACAO NORMAL
    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movimentacaoAtual = movimentador;
    }
}
