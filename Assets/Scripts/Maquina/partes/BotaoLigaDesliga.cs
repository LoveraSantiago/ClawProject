using UnityEngine;

public class BotaoLigaDesliga : AcaoDesligarMaquina.ProdutorEvento,
                                AcaoDesligarMaquinaResultado.ConsumidorEvento
{
    private readonly int MAT_LIGADO = Shader.PropertyToID("_ligado");

    private bool habilitado;
    private BotaoLigaDesligaDto btnLigaDesligaDto;
    private ProdutorDeEvento<DesligarMaquinaDto> produtorDeEvento;

    public BotaoLigaDesliga(BotaoLigaDesligaDto btnLigaDesligaDto)
    {
        this.btnLigaDesligaDto = btnLigaDesligaDto;
        habilitado = true;
        produtorDeEvento = new ProdutorDeEvento<DesligarMaquinaDto>();
        desacionarBtnLigaDesliga();
    }   

    public void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaInferior() && habilitado)
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

    public void desligar()
    {
        habilitado = false;
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
        btnLigaDesligaDto.SprRendererBtnLigaDesliga.sharedMaterial.SetInt(MAT_LIGADO, estado);
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
