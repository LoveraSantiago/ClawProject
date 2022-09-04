public class FactoryWrapperLevelMapDto 
{
    public static WrapperLevelMapDto factory(Direcao direcao, LevelMapDto levelMapDto, bool penultimo, bool ultimo)
    {
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(levelMapDto.MapaEnum);        

        return new WrapperLevelMapDto()
                .configDirecao(direcao)
                .configMapaEntidade(mapaEntidade)
                .configLevelMapDto(levelMapDto)
                .configEstado(determinarMapaEstado(penultimo, ultimo));
    }

    private static MapaEstadoEnum determinarMapaEstado(bool penultimo, bool ultimo)
    {
        if (penultimo)
        {
            return MapaEstadoEnum.LOCKED;
        }
        else if (ultimo)
        {
            return MapaEstadoEnum.BLOCKED;
        }
        else
        {
            return MapaEstadoEnum.LIVRE;
        }
    }
}
