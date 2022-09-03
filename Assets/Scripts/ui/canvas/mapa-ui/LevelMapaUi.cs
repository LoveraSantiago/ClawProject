using System.Collections;
using UnityEngine;

public class LevelMapaUi 
{
    private LevelMapaUiDto levelMapaUiDto;
    private BtnMapaBalao[] btnsMapasBaloes;
    private AnimacaoMainMapa animacaMainMapa;

    public LevelMapaUi(LevelMapaUiDto levelMapaUiDto)
    {
        this.levelMapaUiDto = levelMapaUiDto;
        inicializarBotoesBaloesMapas();
        animacaMainMapa = new AnimacaoMainMapa(levelMapaUiDto.AnimatorMainMapa);
    }

    public void addMapaParaTela(WrapperLevelMapDto evento)
    {        
        LevelMapDto levelMapDto = evento.levelMapDto; 
        MapaEntidade mapaEntidade = FactoryMapaEntidade.getMapaEntidadeByMapaEnum(levelMapDto.MapaEnum);
        if(evento.isDireita)
        {
            dismissBotoesBaloes();
            animacaMainMapa.navegarParaEsquerda();
            Utils.MonoBehaviour.StartCoroutine(alterarMaps(levelMapDto, mapaEntidade));
        }
        else if (evento.isEsquerda)
        {
            dismissBotoesBaloes();
            animacaMainMapa.navegarParaDireita();
            Utils.MonoBehaviour.StartCoroutine(alterarMaps(levelMapDto, mapaEntidade));
        }
        else if(evento.isCentralizado)
        {
            updateMapa(levelMapDto, mapaEntidade);
            posicionarBaloes(levelMapDto.Posicoes);        
            Utils.MonoBehaviour.StartCoroutine(zommarBaloes());
        }
    }

    private void dismissBotoesBaloes()
    {
        for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
        {
            btnsMapasBaloes[contador].zoomarBalaoMenos();
        }
    }

    private void posicionarBaloes(Vector2[] posicoes)
    {
        for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
        {
            btnsMapasBaloes[contador].colocarNaPosicao(posicoes[contador]);
        }
    }

    private void inicializarBotoesBaloesMapas()
    {
        btnsMapasBaloes = new BtnMapaBalao[levelMapaUiDto.BtnLevels.Length];
        for (int contador = 0; contador < levelMapaUiDto.BtnLevels.Length; contador++)
        {
            btnsMapasBaloes[contador] = new BtnMapaBalao(levelMapaUiDto.BaloesLevels[contador]);
        }
    }

    private void updateMapa(LevelMapDto levelMapDto, MapaEntidade mapaEntidade)
    {
        levelMapaUiDto.LblJorney.text = "JORNEY " + mapaEntidade.id;
        levelMapaUiDto.LblTitle.text = mapaEntidade.title;
        levelMapaUiDto.ImgMapa.sprite = levelMapDto.SprMapa;
    }

    private IEnumerator alterarMaps(LevelMapDto levelMapDto, MapaEntidade mapaEntidade)
    {
        yield return new WaitForSeconds(0.75f);
        updateMapa(levelMapDto, mapaEntidade);
        posicionarBaloes(levelMapDto.Posicoes);
        yield return new WaitForSeconds(0.3f);
        yield return zommarBaloes();        
    }

    private IEnumerator zommarBaloes()
    {
        for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
        {
            btnsMapasBaloes[contador].zoomarBalaoMais();
            yield return new WaitForSeconds(levelMapaUiDto.DelayEntreBaloes);
        }
        yield return null;
    }
}
