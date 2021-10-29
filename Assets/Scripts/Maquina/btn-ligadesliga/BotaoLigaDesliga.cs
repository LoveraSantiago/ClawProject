using UnityEngine;

public class BotaoLigaDesliga 
{
    private BotaoLigaDesligaDto btnsLigaDesligaDto;

    public BotaoLigaDesliga(BotaoLigaDesligaDto btnsLigaDesligaDto)
    {
        this.btnsLigaDesligaDto = btnsLigaDesligaDto;
    }

    public void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnsLigaDesligaDto.SprRendererBtnOnOff.bounds.Contains(posicaoTap))
            {
                btnsLigaDesligaDto.SprRendererBtnOnOff.color = Color.red;
            }
        }
    }
}
