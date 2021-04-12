using UnityEngine;

public class GarraManager : ConsumidorDeEventoTrigger
{
    public enum MECANICA_GARRA { ZIG_ZAG = 1, TELEGUIADA = 2, ZIG_ZAGTELEGUIADO = 3 };
    private GerenciadorDeMovimentacao gerenciadorDeMovimentacao;

    public GarraManager(ComponentesDaGarraDto componentesDaGarraDto,  
        MECANICA_GARRA mecanicaGarraEscolhida, InputGame inputGame)
    {
        gerenciadorDeMovimentacao = new GerenciadorDeMovimentacao(componentesDaGarraDto, mecanicaGarraEscolhida, inputGame);
        configurarColisorCentroDaPinca(componentesDaGarraDto.Colisor);
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

    private void garraColidiuCom(Collider2D other)
    {
        gerenciadorDeMovimentacao.garraColidiuCom(other);
    }

    private void configurarColisorCentroDaPinca(GameObject goColisor)
    {
        DetectorDeTriggers detectorDeColisoes = goColisor.GetComponent<DetectorDeTriggers>();
        detectorDeColisoes.registrarConsumidorDeTrigger(this);
    }

    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger INICIO
    //ACIONADO QDO GARRA COLLIDE COM UM COLETAVEL
    public void consumirEvento(Collider2D colliderDeColetavel)
    {
        garraColidiuCom(colliderDeColetavel);
    }
    //IMPLEMENTACAO INTERFACE ConsumidorDeEventoTrigger FIM

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
}
