using UnityEngine;

public class BotaoLigaDesliga : AcaoDesligarMaquina.ProdutorEvento,
                                AcaoDesligarMaquinaCancelado.ConsumidorEvento
{
    private BotaoLigaDesligaDto btnsLigaDesligaDto;
    private ProdutorDeEvento<DesligarMaquina> produtorDeEvento;

    public BotaoLigaDesliga(BotaoLigaDesligaDto btnsLigaDesligaDto)
    {
        this.btnsLigaDesligaDto = btnsLigaDesligaDto;
        produtorDeEvento = new ProdutorDeEvento<DesligarMaquina>();
    }   

    public void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnsLigaDesligaDto.SprRendererBtnOnOff.bounds.Contains(posicaoTap))
            {
                btnsLigaDesligaDto.SprRendererBtnOnOff.color = Color.red;                
                produtorDeEvento.produziuEvento(null);
            }
        }
    }   

    void AcaoDesligarMaquinaCancelado.ConsumidorEvento.consumirEvento(CancelarDesligarMaquina evento)
    {
        btnsLigaDesligaDto.SprRendererBtnOnOff.color = Color.green;     
    }

    ProdutorDeEvento<DesligarMaquina> AcaoDesligarMaquina.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
