using UnityEngine;

public class BotaoLigaDesliga : AcaoDesligarMaquina.ProdutorEvento,
                                CallbackDesligar
{
    private BotaoLigaDesligaDto btnsLigaDesligaDto;
    private ProdutorDeEvento<AcaoDesligar> produtorDeEvento;

    public BotaoLigaDesliga(BotaoLigaDesligaDto btnsLigaDesligaDto)
    {
        this.btnsLigaDesligaDto = btnsLigaDesligaDto;
        produtorDeEvento = new ProdutorDeEvento<AcaoDesligar>();
    }   

    public void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnsLigaDesligaDto.SprRendererBtnOnOff.bounds.Contains(posicaoTap))
            {
                btnsLigaDesligaDto.SprRendererBtnOnOff.color = Color.red;
                produtorDeEvento.produziuEvento(new AcaoDesligar(this));
            }
        }
    }

    public void cancelarDesligamento()
    {
        btnsLigaDesligaDto.SprRendererBtnOnOff.color = Color.green;
    }

    ProdutorDeEvento<AcaoDesligar> AcaoDesligarMaquina.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
