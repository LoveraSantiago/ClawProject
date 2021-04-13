using System;
using UnityEngine;

public class GarraManager : ConsumidorDeEventoTrigger,
                            ConsumidorDeEvento<PowerUp>
{
    public enum MECANICA_GARRA { ZIG_ZAG = 1, TELEGUIADA = 2, ZIG_ZAGTELEGUIADO = 3 };

    private GerenciadorDeMovimentacao gerenciadorDeMovimentacao;

    public GarraManager(GarraDto componentesDaGarraDto,  
        MECANICA_GARRA mecanicaGarraEscolhida, InputGame inputGame)
    {
        gerenciadorDeMovimentacao = new GerenciadorDeMovimentacao(componentesDaGarraDto, mecanicaGarraEscolhida, inputGame);
        configurarColisorCentroDaPinca(componentesDaGarraDto.Colisor);
    }

    private void configurarColisorCentroDaPinca(GameObject goColisor)
    {
        DetectorDeTriggers detectorDeColisoes = goColisor.GetComponent<DetectorDeTriggers>();
        detectorDeColisoes.registrarConsumidorDeTrigger(this);
    }

    public void start()
    {
        gerenciadorDeMovimentacao.iniciarMovimentacoes();
    }

    public void update()
    {
        gerenciadorDeMovimentacao.update();
    }

    public void fixedUpdate()
    {
        gerenciadorDeMovimentacao.fixedUpdate();
    }

    private void processarGarraColidiuCom(Collider2D other)
    {
        gerenciadorDeMovimentacao.garraColidiuCom(other);
    }

    private void processarPowerUp(PowerUp powerUp)
    {
        if(powerUp.tipo == PowerUp.TIPO.BOMBA_DA_GARRA)
        {
            gerenciadorDeMovimentacao.trocarParaAcaoSegurando();
        }
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger INICIO
    //ACIONADO QDO GARRA COLLIDE COM UM COLETAVEL
    public void consumirEvento(Collider2D colliderDeColetavel)
    {
        processarGarraColidiuCom(colliderDeColetavel);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger FIM

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUp> INICIO
    public void consumirEvento(PowerUp evento)
    {
        processarPowerUp(evento);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUp> INICIO

    public ProdutorDeEvento<DirecaoDaGarra> getDisparadorDeEventoDeDirecao()
    {
        return gerenciadorDeMovimentacao.getDisparadorDeEventoDeDirecao();
    }

    public ProdutorDeEvento<string> getProdutorDeEventoTocadoPelaGarra()
    {
        return gerenciadorDeMovimentacao.getProdutorDeEventoTocadoPelaGarra(); ;
    }

    public ProdutorDeEvento<int> getProdutorDeEventoSubidaDaGarra()
    {
        return gerenciadorDeMovimentacao.getProdutorDeEventoSubidaDaGarra();
    }

    public ConsumidorDeEvento<PowerUp> getConsumidorDePowerUp()
    {
        return this;
    }

    public ProdutorDeEvento<Vector3> getProdutorDeEventoGarraCentralizadaPup()
    {
        return gerenciadorDeMovimentacao.getProdutorDeEventoGarraCentralizadaPup();
    }
}
