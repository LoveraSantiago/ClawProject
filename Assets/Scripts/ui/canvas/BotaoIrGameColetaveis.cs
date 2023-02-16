using UnityEngine.UI;

public class BotaoIrGameColetaveis 
{
    private ColetavelEntidade coletavelEntidade;
    private ModalNoFicha modalNoFicha;
    private IndiceArmarioSelecionadoDto indiceArmarioSelecionado;

    public BotaoIrGameColetaveis(
        MainColetaveisDto mainDto, OperacaoFicha operacaoFichaOuro, SomManagerColetaveis somManager)
    {
        mainDto.CanvasDetalheColetavelDto.BtnColetavel.onClick.AddListener(() => {                
                irParaLevelDeColetado(operacaoFichaOuro, somManager);
            });
        modalNoFicha = new ModalNoFicha(mainDto.ModalNoFichaDto, somManager);
    }

    private void irParaLevelDeColetado(OperacaoFicha operacaoFichaOuro, SomManagerColetaveis somManager)
    {   
        if(UtilsFicha.possuiFichasDeOuro(1) && ContextoEstaticoUtils.loading.naoAcionado)
        {
            operacaoFichaOuro.consumirFicha(1);            
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
