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
        if(PlayerPrefsFichas.possueFichas(Ficha.OURO, 1))
        {
            PlayerPrefsFichas.consumirFicha(Ficha.OURO, 1);

            MapaEntidade mapaEntidade = coletavelEntidade.mapaEntidade;
            AbstractLevel level = mapaEntidade.getLevelColetavelByIndice(coletavelEntidade.indice);
            ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);            
            
            PlayerPrefsColetaveis.salvarNavegacaoColetavel(coletavelEntidade.indice);
            PlayerPrefsScrollArmarioPosition.salvarPosScrollRectArmario(indiceArmarioSelecionado);
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
