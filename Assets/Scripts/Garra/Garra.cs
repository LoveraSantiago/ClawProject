using UnityEngine;

public class Garra 
{ 
    private GerenciadorDeMovimentacao gerenciadorDeMovimentacao;

    public Garra(ComponentesDaGarraDto componentesDaGarraDto)
    {
        gerenciadorDeMovimentacao = new GerenciadorDeMovimentacao(componentesDaGarraDto);
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
