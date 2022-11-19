using System.Collections;
using UnityEngine;

public class MapaUi 
{
    private LevelMapaUiDto levelMapaUiDto;    
    private AnimacaoMainMapa animacaMainMapa;
    public GrupoBtnBaloesMapa grupoBtnBaloes { get; private set; }

    private Material materialGrayScale;

    public MapaUi(LevelMapaUiDto levelMapaUiDto, SomMap somMap)
    {
        this.levelMapaUiDto = levelMapaUiDto;
        grupoBtnBaloes = new GrupoBtnBaloesMapa(levelMapaUiDto.BaloesLevels, somMap);        
        animacaMainMapa = new AnimacaoMainMapa(levelMapaUiDto.AnimatorMainMapa);
        materialGrayScale = MaterialGrayScale.of();
    }

    public void addMapaParaTela(WrapperLevelMapDto evento, SomMap somMap)
    {
        MapaEntidade mapaEntidade = evento.mapaEntidade;
        if(evento.isDireita)
        {
            grupoBtnBaloes.dismissBotoesBaloes();
            animacaMainMapa.navegarParaEsquerda(mapaEntidade.isLivre|| mapaEntidade.isProgresso);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(alterarMaps(evento, somMap));
        }
        else if (evento.isEsquerda)
        {
            grupoBtnBaloes.dismissBotoesBaloes();
            animacaMainMapa.navegarParaDireita(mapaEntidade.isLivre || mapaEntidade.isProgresso);
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(alterarMaps(evento, somMap));
        }
        else if(evento.isCentralizado)
        {
            updateMapa(evento);
            grupoBtnBaloes.posicionarBaloes(evento);
            MaterialBackground.movimentarSaida(levelMapaUiDto.MatBackground, evento.mapaEntidade.levelCorBackground);

            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(
                grupoBtnBaloes.coroutineZommarBaloes(evento, levelMapaUiDto.DelayEntreBaloes, somMap));

            animacaMainMapa.mostrarSetasNavegacao(mapaEntidade.isLivre);
        }
    }        

    private void updateMapa(WrapperLevelMapDto evento)
    {
        MapaEntidade mapaEntidade = evento.mapaEntidade;        
        levelMapaUiDto.ImgMapa.sprite = mapaEntidade.spriteMapa;

        if (mapaEntidade.isLivre || mapaEntidade.isProgresso)
        {
            levelMapaUiDto.ImgMapa.color = Color.white;
            levelMapaUiDto.ImgMapa.material = null;
            levelMapaUiDto.LblJorney.text = "JORNEY " + mapaEntidade.id;
            levelMapaUiDto.LblTitle.text = mapaEntidade.title;
        }
        else if (mapaEntidade.isBloqueado)
        {
            materialGrayScale = MaterialGrayScale.changeSprite(materialGrayScale, mapaEntidade.spriteMapa);
            levelMapaUiDto.ImgMapa.color = Color.white;
            levelMapaUiDto.ImgMapa.material = materialGrayScale;
            levelMapaUiDto.LblJorney.text = "LEVEL BLOQUEADO";
            levelMapaUiDto.LblTitle.text = "Complete o Mapa Anterior para Desbloquear";
        }
        else if (mapaEntidade.isLockado)
        {
            levelMapaUiDto.ImgMapa.color = Color.black;
            levelMapaUiDto.ImgMapa.material = null;
            levelMapaUiDto.LblJorney.text = "LEVEL SECRETO";            
            levelMapaUiDto.LblTitle.text = "Complete o Mapa Anterior para Revelar";
        }
    }

    private IEnumerator alterarMaps(WrapperLevelMapDto evento, SomMap somMap)
    {
        MaterialBackground.movimentarEntrada(levelMapaUiDto.MatBackground);
        yield return new WaitForSeconds(levelMapaUiDto.DelayInicioMapa);
        updateMapa(evento);
        grupoBtnBaloes.posicionarBaloes(evento);
        yield return new WaitForSeconds(levelMapaUiDto.DelayInicioBaloes);
        MaterialBackground.movimentarSaida(levelMapaUiDto.MatBackground, evento.mapaEntidade.levelCorBackground);
        yield return grupoBtnBaloes.coroutineZommarBaloes(evento, levelMapaUiDto.DelayEntreBaloes, somMap);
    }   
}
