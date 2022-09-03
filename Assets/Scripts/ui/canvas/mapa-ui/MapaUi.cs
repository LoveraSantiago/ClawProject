using System.Collections;
using UnityEngine;

public class MapaUi 
{
    private LevelMapaUiDto levelMapaUiDto;    
    private AnimacaoMainMapa animacaMainMapa;
    private GrupoBtnBaloesMapa grupoBtnBaloes;

    private Material materialGrayScale;

    public MapaUi(LevelMapaUiDto levelMapaUiDto)
    {
        this.levelMapaUiDto = levelMapaUiDto;
        grupoBtnBaloes = new GrupoBtnBaloesMapa(levelMapaUiDto.BaloesLevels);        
        animacaMainMapa = new AnimacaoMainMapa(levelMapaUiDto.AnimatorMainMapa);
        materialGrayScale = MaterialGrayScale.of();
    }

    public void addMapaParaTela(WrapperLevelMapDto evento)
    {   
        if(evento.isDireita)
        {
            grupoBtnBaloes.dismissBotoesBaloes();
            animacaMainMapa.navegarParaEsquerda(evento.isAberto);
            Utils.MonoBehaviour.StartCoroutine(alterarMaps(evento));
        }
        else if (evento.isEsquerda)
        {
            grupoBtnBaloes.dismissBotoesBaloes();
            animacaMainMapa.navegarParaDireita(evento.isAberto);
            Utils.MonoBehaviour.StartCoroutine(alterarMaps(evento));
        }
        else if(evento.isCentralizado)
        {
            updateMapa(evento);
            grupoBtnBaloes.posicionarBaloes(evento);        
            Utils.MonoBehaviour.StartCoroutine(grupoBtnBaloes.coroutineZommarBaloes(evento, levelMapaUiDto.DelayEntreBaloes));
            animacaMainMapa.mostrarSetasNavegacao(evento.isAberto);
        }
    }        

    private void updateMapa(WrapperLevelMapDto evento)
    {
        LevelMapDto levelMapDto = evento.levelMapDto;
        MapaEntidade mapaEntidade = evento.mapaEntidade;

        levelMapaUiDto.ImgMapa.sprite = levelMapDto.SprMapa;

        if (evento.isAberto)
        {
            levelMapaUiDto.ImgMapa.color = Color.white;
            levelMapaUiDto.ImgMapa.material = null;
            levelMapaUiDto.LblJorney.text = "JORNEY " + mapaEntidade.id;
            levelMapaUiDto.LblTitle.text = mapaEntidade.title;
        }
        else if (evento.isLocked)
        {
            materialGrayScale = MaterialGrayScale.changeSprite(materialGrayScale, levelMapDto.SprMapa);
            levelMapaUiDto.ImgMapa.color = Color.white;
            levelMapaUiDto.ImgMapa.material = materialGrayScale;
            levelMapaUiDto.LblJorney.text = "LEVEL BLOQUEADO";
            levelMapaUiDto.LblTitle.text = "Complete o Mapa Anterior para Desbloquear";
        }
        else if (evento.isBlocked)
        {
            levelMapaUiDto.ImgMapa.color = Color.black;
            levelMapaUiDto.ImgMapa.material = null;
            levelMapaUiDto.LblJorney.text = "LEVEL SECRETO";            
            levelMapaUiDto.LblTitle.text = "Complete o Mapa Anterior para Revelar";
        }
    }

    private IEnumerator alterarMaps(WrapperLevelMapDto evento)
    {
        yield return new WaitForSeconds(levelMapaUiDto.DelayInicioMapa);
        updateMapa(evento);
        grupoBtnBaloes.posicionarBaloes(evento);
        yield return new WaitForSeconds(levelMapaUiDto.DelayInicioBaloes);
        yield return grupoBtnBaloes.coroutineZommarBaloes(evento, levelMapaUiDto.DelayEntreBaloes);        
    }   
}
