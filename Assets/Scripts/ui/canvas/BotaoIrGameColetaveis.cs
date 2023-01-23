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
                irParaLevelDeColetado(somManager);
            });
        modalNoFicha = new ModalNoFicha(modalNoFichaDto, somManager);
    }

    private void irParaLevelDeColetado(SomManagerColetaveis somManager)
    {   
        if(PlayerPrefsFichas.possueFichas(Ficha.OURO, 1) && ContextoEstaticoUtils.loading.naoAcionado)
        {
            PlayerPrefsFichas.consumirFicha(Ficha.OURO, 1);
            somManager.playSomCliqueIrParaGame();

            MapaEntidade mapaEntidade = coletavelEntidade.mapaEntidade;
            AbstractLevel level = mapaEntidade.getLevelColetavelByIndice(coletavelEntidade.indice);
            ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);            
            
            PlayerPrefsColetaveis.salvarNavegacaoColetavel(coletavelEntidade.indice);
            PlayerPrefsScrollArmarioPosition.salvarPosScrollRectArmario(indiceArmarioSelecionado);
            ContextoEstaticoUtils.loading.irParaGameCena();
        }
        else
        {
            modalNoFicha.ligar(Ficha.OURO, somManager);
        }
    }

    public void prepararColetavelEntidade(ColetavelEntidade coletavelEntidade, IndiceArmarioSelecionadoDto indiceArmarioSelecionado)
    {
        this.coletavelEntidade = coletavelEntidade;
        this.indiceArmarioSelecionado = indiceArmarioSelecionado;
    }
}
