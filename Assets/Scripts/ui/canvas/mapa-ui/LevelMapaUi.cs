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
        levelMapaUiDto.LblJorney.text = "JORNEY " + mapaEntidade.id;
        levelMapaUiDto.LblTitle.text = mapaEntidade.title;
        levelMapaUiDto.ImgMapa.sprite = levelMapDto.SprMapa;
        showBotoesBaloes(levelMapDto.Posicoes);
        
        Utils.MonoBehaviour.StartCoroutine(zommarBaloes());
    }

    private void dismissBotoesBaloes()
    {

    }

    private void showBotoesBaloes(Vector2[] posicoes)
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

    private IEnumerator zommarBaloes()
    {
        for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
        {
            btnsMapasBaloes[contador].zoomarBalao();
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
