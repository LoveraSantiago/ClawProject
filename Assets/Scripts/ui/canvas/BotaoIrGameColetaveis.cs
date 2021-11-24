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
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        int indiceFamilia = helperColetavel.getIndiceDaFamilia(coletavelEntidade.familia);

        PlayerPrefsLevel.salvarLevel(coletavelEntidade.level);
        PlayerPrefsColetaveis.salvarIndiceFamilia(indiceFamilia);
        PlayerPrefsColetaveis.salvarNavegacaoColetavel(coletavelEntidade.id);
        CenaUtils.irParaCenaMainGame();
    }

    void AcaoBlocoImgColetavelAtual.ConsumidorEvento.consumirEvento(UiColetavelInfo evento)
    {
        coletavelEntidade = evento.coletavelEntidade;
    }
}
