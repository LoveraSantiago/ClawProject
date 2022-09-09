public class FactoryWrapperLevelMapDto 
{
    public static WrapperLevelMapDto factory(Direcao direcao, LevelMapDto levelMapDto, EstadoOrdemMapaDto estadoOrdem)
    {
        MapaEntidade mapaEntidade = HelperMapaEntidade.getMapaEntidadeByMapaEnum(levelMapDto.MapaEnum);

        MapaEstadoEnum mapaEstado = determinarMapaEstado(estadoOrdem);
        return new WrapperLevelMapDto()
                .configDirecao(direcao)
                .configMapaEntidade(mapaEntidade)
                .configLevelMapDto(levelMapDto)
                .configEstado(mapaEstado);
    }

    private static MapaEstadoEnum determinarMapaEstado(EstadoOrdemMapaDto estadoOrdem)
    {
        if (estadoOrdem.isUltimo)
        {
            return MapaEstadoEnum.BLOCKED;
        }
        else if (estadoOrdem.isPenultimo)
        {
            return MapaEstadoEnum.LOCKED;
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
