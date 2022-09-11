using UnityEngine.UI;

public class BotaoIrGameColetaveis 
{
    private ColetavelEntidade coletavelEntidade;
    private ModalNoFicha modalNoFicha;
    private IndiceArmarioSelecionadoDto indiceArmarioSelecionado;

    public BotaoIrGameColetaveis(Button btnColetavel, ModalNoFichaDto modalNoFichaDto)
    {
        btnColetavel.onClick.AddListener(() => irParaLevelDeColetado());
        modalNoFicha = new ModalNoFicha(modalNoFichaDto);
    }

    private void irParaLevelDeColetado()
    {        
        int indiceFamilia = HelperColetavelEntidade.getIndiceDaFamilia(coletavelEntidade.mapaEnum);

        if(PlayerPrefsFichas.possueFichas(Ficha.OURO, 1))
        {
            PlayerPrefsFichas.consumirFicha(Ficha.OURO, 1);

            MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(coletavelEntidade.mapaEnum);
            AbstractLevel level = mapaEntidade.getLevelByColetavelEntidade(coletavelEntidade);
            ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);            
            
            PlayerPrefsColetaveis.salvarNavegacaoColetavel(coletavelEntidade.id);
            PlayerPrefsScrollPosition.salvarPosScrollRectArmario(indiceArmarioSelecionado);
            CenaUtils.irParaCenaMainGame();
        }
        else
        {
            modalNoFicha.ligar();
        }
    }

    public void prepararColetavelEntidade(ColetavelEntidade coletavelEntidade, IndiceArmarioSelecionadoDto indiceArmarioSelecionado)
    {
        this.coletavelEntidade = coletavelEntidade;
        this.indiceArmarioSelecionado = indiceArmarioSelecionado;
    }
}
