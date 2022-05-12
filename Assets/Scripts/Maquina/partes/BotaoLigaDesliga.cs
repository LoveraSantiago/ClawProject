using UnityEngine;

public class BotaoLigaDesliga : AcaoDesligarMaquina.ProdutorEvento,
                                AcaoDesligarMaquinaResultado.ConsumidorEvento
{
    private BotaoLigaDesligaDto btnLigaDesligaDto;
    private ProdutorDeEvento<DesligarMaquinaDto> produtorDeEvento;

    public BotaoLigaDesliga(BotaoLigaDesligaDto btnLigaDesligaDto)
    {
        this.btnLigaDesligaDto = btnLigaDesligaDto;
        produtorDeEvento = new ProdutorDeEvento<DesligarMaquinaDto>();
        desacionarBtnLigaDesliga();
    }   

    public void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if (btnLigaDesligaDto.SprRendererBtnLigaDesliga.bounds.Contains(posicaoTap))
            {
                acionarBtnLigaDesliga();           
                produtorDeEvento.produziuEvento(null);
                inputGame.consumirTap();
            }
        }
    }   

    private void acionarBtnLigaDesliga()
    {
        setarAparenciaBtnLigaDesliga(0);
    }

    private void desacionarBtnLigaDesliga()
    {
        setarAparenciaBtnLigaDesliga(1);
    }

    private void setarAparenciaBtnLigaDesliga(int estado)
    {
        btnLigaDesligaDto.SprRendererBtnLigaDesliga.sharedMaterial.SetInt("_ligado", estado);
    }

    void AcaoDesligarMaquinaResultado.ConsumidorEvento.consumirEvento(ResultadoDesligarMaquinaDto evento)
    {
        if (!evento.resultadoSair)
        {
            desacionarBtnLigaDesliga();
        }
    }

    ProdutorDeEvento<DesligarMaquinaDto> AcaoDesligarMaquina.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
