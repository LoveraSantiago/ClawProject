using UnityEngine.UI;

public class BotaoIrGameColetaveis : AcaoBlocoImgColetavelAtual.ConsumidorEvento
{
    private Level levelAtual;

    public BotaoIrGameColetaveis(Button btnColetavel)
    {
        btnColetavel.onClick.AddListener(() => irParaLevelDeColetado());
    }

    private void irParaLevelDeColetado()
    {
        PlayerPrefsLevel.salvarLevel(levelAtual);
        CenaUtils.irParaCenaMainGame();

    }

    void AcaoBlocoImgColetavelAtual.ConsumidorEvento.consumirEvento(UiColetavelInfo evento)
    {
        levelAtual = evento.coletavelEntidade.level;
    }
}
