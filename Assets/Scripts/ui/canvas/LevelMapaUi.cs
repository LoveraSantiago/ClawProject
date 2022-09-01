public class LevelMapaUi 
{
    private LevelMapaUiDto levelMapaUiDto;

    public LevelMapaUi(LevelMapaUiDto levelMapaUiDto)
    {
        this.levelMapaUiDto = levelMapaUiDto;
    }

    public void addMapaParaTela(int indice, LevelMapDto levelMapDto)
    {
        MapaEntidade mapaEntidade = FactoryMapaEntidade.getMapaEntidadeByIndice(indice);
        levelMapaUiDto.LblJorney.text = "Jorney " + indice;
        levelMapaUiDto.LblTitle.text = mapaEntidade.title;
        levelMapaUiDto.ImgMapa.sprite = levelMapDto.SprMapa;

        for (int contador = 0; contador < levelMapaUiDto.BtnLevels.Length; contador++)
        {
            levelMapaUiDto.BtnLevels[contador].transform.localPosition = levelMapDto.Posicoes[contador];
        }
    }
}
