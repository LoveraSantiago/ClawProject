using UnityEngine;

public class BotaoLigaDesliga : AcaoDesligarMaquina.ProdutorEvento
{
    private BotaoLigaDesligaDto btnsLigaDesligaDto;
    private ProdutorDeEvento<bool> produtorDeEvento;

    public BotaoLigaDesliga(BotaoLigaDesligaDto btnsLigaDesligaDto)
    {
        this.btnsLigaDesligaDto = btnsLigaDesligaDto;
        produtorDeEvento = new ProdutorDeEvento<bool>();
    }   

    public void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnsLigaDesligaDto.SprRendererBtnOnOff.bounds.Contains(posicaoTap))
            {
                btnsLigaDesligaDto.SprRendererBtnOnOff.color = Color.red;
                Utils.pausarGame();
                produtorDeEvento.produziuEvento(true);
            }
        }
    }

    public void cancelarDesligamento()
    {
        btnsLigaDesligaDto.SprRendererBtnOnOff.color = Color.green;
        Utils.continuarGame();
    }

    ProdutorDeEvento<bool> AcaoDesligarMaquina.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
