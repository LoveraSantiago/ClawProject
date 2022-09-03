public class FactoryWrapperLevelMapDto 
{
    public static WrapperLevelMapDto factory(Direcao direcao, LevelMapDto levelMapDto)
    {
        MapaEntidade mapaEntidade = FactoryMapaEntidade.getMapaEntidadeByMapaEnum(levelMapDto.MapaEnum);
        return new WrapperLevelMapDto(direcao, mapaEntidade, levelMapDto);
    }
}
