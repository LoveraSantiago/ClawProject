using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeMovimentacaoPowerUp : GerenciadorDeMovimentacao,
                                                ComunicadorComGerMovPowerUp
{

    private ContadorDeTempo contadorDeFimTempo;

    private MovimentacaoDaGarra movAtual;
    private MovimentacaoDaGarra movVoltarPCima;
    private MovimentacaoDaGarra movVoltarMeio;
    private MovimentacaoSegurandoEmcima movSegCima;

    public GerenciadorDeMovimentacaoPowerUp()
    {
        MovimentacaoDaGarraPowerUp.configurarComunicadorComGerMovimentacao(this);
        movVoltarPCima = new MovimentacaoVoltarParaCima();
        movVoltarMeio  = new MovimentacaoVoltarParaMeio();
        movSegCima     = new MovimentacaoSegurandoEmcima();
    }

    //IMPLEMENTANDO INTERFACE GERENCIADORDEMOVIMENTACAO INICIO
    public void iniciarMovimentacoes()
    {
        MovimentacaoDaGarra.produtorEventoDirecao.produziuEvento(DirecaoDaGarra.CENTRALIZADA);
        trocarParaAcaoVoltarParaCima();
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
        movSegCima.receberInteracaoComPowerUp(garraInteracaoPowerUp);
        contadorDeFimTempo.configTempoParaAcao(tempoDuracao);
    }

    private bool isEstadoAtualCentralizado()
    {
        //return movimentacaoAtual == ALGUM_ESTADO_CENTRALIZADO;
        return false;
    }

    //IMPLEMENTANDO INTERFACE COMUNICADORCOMGERMOVPOWERUP INICIO
    public void trocarParaAcaoVoltarParaCima()
    {
        trocarMovimentador(movVoltarPCima);
    }

    public void trocarParaAcaoVoltarParaMeio()
    {
        trocarMovimentador(movVoltarMeio);
    }

    public void trocarParaAcaoSegurando()
    {
        trocarMovimentador(movSegCima);
    }
    //IMPLEMENTANDO INTERFACE COMUNICADORCOMGERMOVPOWERUP FIM

    //TODO REFATORAR COM GERENCIADOR DE MOVIMENTACAO NORMAL
    private void trocarMovimentador(MovimentacaoDaGarra movimentador)
    {
        movimentador.preInicio();
        movAtual = movimentador;
    }

}
