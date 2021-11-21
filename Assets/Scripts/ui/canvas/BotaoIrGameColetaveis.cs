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
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        int indiceFamilia = coletavelHelper.getIndiceDaFamilia(coletavelEntidade.familia);

        PlayerPrefsLevel.salvarLevel(coletavelEntidade.level);
        PlayerPrefsColetaveis.salvarIndiceFamilia(indiceFamilia);
        PlayerPrefsColetaveis.salvarIndiceColetavel(coletavelEntidade.nome);
        CenaUtils.irParaCenaMainGame();
    }

    void AcaoBlocoImgColetavelAtual.ConsumidorEvento.consumirEvento(UiColetavelInfo evento)
    {
        coletavelEntidade = evento.coletavelEntidade;
    }
}
