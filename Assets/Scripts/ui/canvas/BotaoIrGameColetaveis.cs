using UnityEngine.UI;

public class BotaoIrGameColetaveis : AcaoBlocoImgColetavelAtual.ConsumidorEvento
{
    private ColetavelEntidade coletavelEntidade;
    private ModalNoFicha modalNoFicha;

    public BotaoIrGameColetaveis(Button btnColetavel, ModalNoFichaDto modalNoFichaDto)
    {
        btnColetavel.onClick.AddListener(() => irParaLevelDeColetado());
        modalNoFicha = new ModalNoFicha(modalNoFichaDto);
    }

    private void irParaLevelDeColetado()
    {
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        int indiceFamilia = helperColetavel.getIndiceDaFamilia(coletavelEntidade.familia);

        if(PlayerPrefsFichas.possueFichas(Ficha.OURO, 1))
        {
            PlayerPrefsFichas.consumirFicha(Ficha.OURO, 1);
            PlayerPrefsLevel.salvarLevel(coletavelEntidade.level);
            PlayerPrefsColetaveis.salvarIndiceFamilia(indiceFamilia);
            PlayerPrefsColetaveis.salvarNavegacaoColetavel(coletavelEntidade.id);
            CenaUtils.irParaCenaMainGame();
        }
        else
        {
            modalNoFicha.ligar();
        }
    }

    void AcaoBlocoImgColetavelAtual.ConsumidorEvento.consumirEvento(UiColetavelInfo evento)
    {
        coletavelEntidade = evento.coletavelEntidade;
    }
}
