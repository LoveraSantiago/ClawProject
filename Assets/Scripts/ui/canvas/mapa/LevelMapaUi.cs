using System.Collections;
using UnityEngine;

public class LevelMapaUi 
{
    private LevelMapaUiDto levelMapaUiDto;
    private BtnMapaBalao[] btnsMapasBaloes;

    public LevelMapaUi(LevelMapaUiDto levelMapaUiDto)
    {
        this.levelMapaUiDto = levelMapaUiDto;
        inicializarBotoesBaloesMapas();
    }

    public void addMapaParaTela(int indice, LevelMapDto levelMapDto)
    {
        MapaEntidade mapaEntidade = FactoryMapaEntidade.getMapaEntidadeByIndice(indice);
        levelMapaUiDto.LblJorney.text = "Jorney " + indice;
        levelMapaUiDto.LblTitle.text = mapaEntidade.title;
        levelMapaUiDto.ImgMapa.sprite = levelMapDto.SprMapa;

        for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
        {
            btnsMapasBaloes[contador].colocarNaPosicao(levelMapDto.Posicoes[contador]);
        }
        Utils.MonoBehaviour.StartCoroutine(zommarBaloes());
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
