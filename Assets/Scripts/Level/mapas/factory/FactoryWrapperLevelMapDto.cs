public class FactoryWrapperLevelMapDto 
{
    public static WrapperLevelMapDto factory(Direcao direcao, LevelMapDto levelMapDto, EstadoOrdemMapaDto estadoOrdem)
    {
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(levelMapDto.MapaEnum);        

        return new WrapperLevelMapDto()
                .configDirecao(direcao)
                .configMapaEntidade(mapaEntidade)
                .configLevelMapDto(levelMapDto)
                .configEstado(determinarMapaEstado(estadoOrdem));
    }

    private static MapaEstadoEnum determinarMapaEstado(EstadoOrdemMapaDto estadoOrdem)
    {
        if (estadoOrdem.isPenultimo)
        {
            return MapaEstadoEnum.LOCKED;
        }
        else if (estadoOrdem.isUltimo)
        {
            return MapaEstadoEnum.BLOCKED;
        }
        else if (estadoOrdem.isAntepenultimo)
        {
            return MapaEstadoEnum.ANDAMENTO;
        }
        else
        {
            return MapaEstadoEnum.LIVRE;
        }
    }
}
