using UnityEngine.UI;

public class BotaoIrGameColetaveis 
{
    private ColetavelEntidade coletavelEntidade;
    private ModalNoFicha modalNoFicha;
    private float posicaoScroll;

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
            PlayerPrefsScrollPosition.salvarPosScrollRectColetaveis(posicaoScroll);
            CenaUtils.irParaCenaMainGame();
        }
        else
        {
            modalNoFicha.ligar();
        }
    }

    public void prepararColetavelEntidade(ColetavelEntidade coletavelEntidade, float posicaoScroll)
    {
        this.coletavelEntidade = coletavelEntidade;
        this.posicaoScroll = posicaoScroll;
    }
}
