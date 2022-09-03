using System.Collections;
using UnityEngine;

public class MapaUi 
{
    private LevelMapaUiDto levelMapaUiDto;
    private BtnBalaoMapa[] btnsMapasBaloes;
    private AnimacaoMainMapa animacaMainMapa;

    public MapaUi(LevelMapaUiDto levelMapaUiDto)
    {
        this.levelMapaUiDto = levelMapaUiDto;
        inicializarBotoesBaloesMapas();
        animacaMainMapa = new AnimacaoMainMapa(levelMapaUiDto.AnimatorMainMapa);
    }

    public void addMapaParaTela(WrapperLevelMapDto evento)
    {   
        if(evento.isDireita)
        {
            dismissBotoesBaloes();
            animacaMainMapa.navegarParaEsquerda();
            Utils.MonoBehaviour.StartCoroutine(alterarMaps(evento));
        }
        else if (evento.isEsquerda)
        {
            dismissBotoesBaloes();
            animacaMainMapa.navegarParaDireita();
            Utils.MonoBehaviour.StartCoroutine(alterarMaps(evento));
        }
        else if(evento.isCentralizado)
        {
            updateMapa(evento);
            posicionarBaloes(evento);        
            Utils.MonoBehaviour.StartCoroutine(zommarBaloes(evento));
        }
    }

    private void dismissBotoesBaloes()
    {
        for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
        {
            btnsMapasBaloes[contador].zoomarBalaoMenos();
        }
    }

    private void posicionarBaloes(WrapperLevelMapDto evento)
    {
        Vector2[] posicoes = evento.levelMapDto.Posicoes;
        if (evento.isAberto)
        {
            for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
            {
                btnsMapasBaloes[contador].colocarNaPosicao(posicoes[contador]);
            }
        }
    }

    private void inicializarBotoesBaloesMapas()
    {
        btnsMapasBaloes = new BtnBalaoMapa[levelMapaUiDto.BtnLevels.Length];
        for (int contador = 0; contador < levelMapaUiDto.BtnLevels.Length; contador++)
        {
            btnsMapasBaloes[contador] = new BtnBalaoMapa(levelMapaUiDto.BaloesLevels[contador]);
        }
    }

    private void updateMapa(WrapperLevelMapDto evento)
    {
        LevelMapDto levelMapDto = evento.levelMapDto;
        MapaEntidade mapaEntidade = evento.mapaEntidade;

        levelMapaUiDto.LblJorney.text = "JORNEY " + mapaEntidade.id;
        levelMapaUiDto.LblTitle.text = mapaEntidade.title;
        levelMapaUiDto.ImgMapa.sprite = levelMapDto.SprMapa;
    }

    private IEnumerator alterarMaps(WrapperLevelMapDto evento)
    {
        yield return new WaitForSeconds(levelMapaUiDto.DelayInicioMapa);
        updateMapa(evento);
        posicionarBaloes(evento);
        yield return new WaitForSeconds(levelMapaUiDto.DelayInicioBaloes);
        yield return zommarBaloes(evento);        
    }

    private IEnumerator zommarBaloes(WrapperLevelMapDto evento)
    {
        if (evento.isAberto)
        {
            for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
            {
                btnsMapasBaloes[contador].zoomarBalaoMais();
                yield return new WaitForSeconds(levelMapaUiDto.DelayEntreBaloes);
            }
        }
        yield return null;
    }
}
