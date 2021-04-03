using UnityEngine;

public class GarraManager : ConsumidorDeEventoTrigger
{
    private GerenciadorDeMovimentacao gerenciadorDeMovimentacao;
    public enum MECANICA_GARRA { ZIG_ZAG = 1, TELEGUIADA = 2, ZIG_ZAGTELEGUIADO = 3 };

    public GarraManager(ComponentesDaGarraDto componentesDaGarraDto,
                 MECANICA_GARRA mecanicaGarraEscolhida)
    {
        gerenciadorDeMovimentacao = new GerenciadorDeMovimentacao(componentesDaGarraDto, mecanicaGarraEscolhida);
        configurarColisorCentroDaPinca(componentesDaGarraDto.Colisor);
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
}
