using System.Collections;
using UnityEngine;

public class MapaUi 
{
    private LevelMapaUiDto levelMapaUiDto;    
    private AnimacaoMainMapa animacaMainMapa;
    private GrupoBtnBaloesMapa grupoBtnBaloes;

    public MapaUi(LevelMapaUiDto levelMapaUiDto)
    {
        this.levelMapaUiDto = levelMapaUiDto;
        grupoBtnBaloes = new GrupoBtnBaloesMapa(levelMapaUiDto.BaloesLevels);
        
        animacaMainMapa = new AnimacaoMainMapa(levelMapaUiDto.AnimatorMainMapa);
    }

    public void addMapaParaTela(WrapperLevelMapDto evento)
    {   
        if(evento.isDireita)
        {
            grupoBtnBaloes.dismissBotoesBaloes();
            animacaMainMapa.navegarParaEsquerda();
            Utils.MonoBehaviour.StartCoroutine(alterarMaps(evento));
        }
        else if (evento.isEsquerda)
        {
            grupoBtnBaloes.dismissBotoesBaloes();
            animacaMainMapa.navegarParaDireita();
            Utils.MonoBehaviour.StartCoroutine(alterarMaps(evento));
        }
        else if(evento.isCentralizado)
        {
            updateMapa(evento);
            grupoBtnBaloes.posicionarBaloes(evento);        
            Utils.MonoBehaviour.StartCoroutine(grupoBtnBaloes.coroutineZommarBaloes(evento));
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
        grupoBtnBaloes.posicionarBaloes(evento);
        yield return new WaitForSeconds(levelMapaUiDto.DelayInicioBaloes);
        yield return grupoBtnBaloes.coroutineZommarBaloes(evento);        
    }   
}
