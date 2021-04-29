using UnityEngine;

public class GarraManager : ConsumidorDeEventoTrigger,
                            ConsumidorDeEvento<PowerUpInfo>,
                            ConsumidorDeEvento<Utils.EventoVazioPowerUpFim>
{
    public enum MECANICA_GARRA { ZIG_ZAG = 1, TELEGUIADA = 2, ZIG_ZAGTELEGUIADO = 3 };

    private GerenciadorDeMovimentacaoNormal gerenciadorDeMovimentacao;

    public GarraManager(GarraDto componentesDaGarraDto,  
        MECANICA_GARRA mecanicaGarraEscolhida, InputGame inputGame)
    {
        MovimentacaoDaGarra.configurarComponentesMovimentacaoGarra(componentesDaGarraDto, inputGame);
        gerenciadorDeMovimentacao = new GerenciadorDeMovimentacaoNormal(mecanicaGarraEscolhida);

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

    private void processarFimPowerUp()
    {
        gerenciadorDeMovimentacao.trocarParaAcaoNormal();
    }

    private void processarPowerUp(PowerUpInfo powerUpInfo)
    {
        if(powerUpInfo.garraInteracaoPowerUp != null)
        {
            gerenciadorDeMovimentacao.trocarParaAcaoSegurando(powerUpInfo.garraInteracaoPowerUp, powerUpInfo.duracaoTempo);
        }
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger INICIO
    //ACIONADO QDO GARRA COLLIDE COM UM COLETAVEL
    public void consumirEvento(Collider2D colliderDeColetavel)
    {
        processarGarraColidiuCom(colliderDeColetavel);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger FIM

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUpInfo> INICIO
    public void consumirEvento(PowerUpInfo evento)
    {
        processarPowerUp(evento);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<PowerUpInfo> INICIO

    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<int> INICIO
    public void consumirEvento(Utils.EventoVazioPowerUpFim evento)
    {
        processarFimPowerUp();
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEvento<int> INICIO

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

    public ConsumidorDeEvento<PowerUpInfo> getConsumidorDePowerUpInfo()
    {
        return this;
    }

    internal ConsumidorDeEvento<Utils.EventoVazioPowerUpFim> getConsumidorDePowerUpFim()
    {
        return this;
    }    
}
