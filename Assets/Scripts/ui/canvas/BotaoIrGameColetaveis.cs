using UnityEngine.UI;

public class BotaoIrGameColetaveis : AcaoBlocoImgColetavelAtual.ConsumidorEvento
{
    private ColetavelEntidade coletavelEntidade;

    public BotaoIrGameColetaveis(Button btnColetavel)
    {
        btnColetavel.onClick.AddListener(() => irParaLevelDeColetado());
    }

    private void irParaLevelDeColetado()
    {
        PlayerPrefsLevel.salvarLevel(coletavelEntidade.level);
        PlayerPrefsColetaveis.salvarIndiceFamilia(coletavelEntidade.familia);
        PlayerPrefsColetaveis.salvarIndiceColetavel(coletavelEntidade.nome);
        CenaUtils.irParaCenaMainGame();
    }

    void AcaoBlocoImgColetavelAtual.ConsumidorEvento.consumirEvento(UiColetavelInfo evento)
    {
        coletavelEntidade = evento.coletavelEntidade;
    }
}
