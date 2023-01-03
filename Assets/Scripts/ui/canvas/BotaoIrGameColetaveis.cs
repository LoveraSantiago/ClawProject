using UnityEngine.UI;

public class BotaoIrGameColetaveis 
{
    private ColetavelEntidade coletavelEntidade;
    private ModalNoFicha modalNoFicha;
    private IndiceArmarioSelecionadoDto indiceArmarioSelecionado;

    public BotaoIrGameColetaveis(
        Button btnColetavel, ModalNoFichaDto modalNoFichaDto, SomManagerColetaveis somManager)
    {
        btnColetavel.onClick.AddListener(() => {
            somManager.playSomCliqueIrParaGame();
                irParaLevelDeColetado();
            });
        modalNoFicha = new ModalNoFicha(modalNoFichaDto, null);
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
            ContextoEstaticoUtils.loading.irParaGameCena();
        }
        else
        {
            modalNoFicha.ligar(Ficha.OURO, null);
        }
    }

    public void prepararColetavelEntidade(ColetavelEntidade coletavelEntidade, IndiceArmarioSelecionadoDto indiceArmarioSelecionado)
    {
        this.coletavelEntidade = coletavelEntidade;
        this.indiceArmarioSelecionado = indiceArmarioSelecionado;
    }
}
