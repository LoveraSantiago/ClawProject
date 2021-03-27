using UnityEngine;

public class Garra 
{ 
    private GerenciadorDeMovimentacao gerenciadorDeMovimentacao;
    public enum MECANICA_GARRA { ZIG_ZAG, TELEGUIADA, ZIG_ZAGTELEGUIADO };

    public Garra(ComponentesDaGarraDto componentesDaGarraDto, 
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
        detectorDeColisoes.registrarConsumidorDeTrigger((colisao) =>garraColidiuCom(colisao));
    }    
}
