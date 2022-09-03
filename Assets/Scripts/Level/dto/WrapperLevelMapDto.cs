public class WrapperLevelMapDto 
{
    private MapaEstadoEnum mapaEstado;
    public Direcao direcao { get; private set; }
    public MapaEntidade mapaEntidade { get; private set; }
    public LevelMapDto levelMapDto { get; private set; }

    public bool isCentralizado { get { return direcao == Direcao.CENTRALIZADA; } }
    public bool isEsquerda     { get { return direcao == Direcao.ESQUERDA; } }
    public bool isDireita      { get { return direcao == Direcao.DIREITA; } }

    public bool isAberto  { get { return mapaEstado == MapaEstadoEnum.LIVRE; } }
    public bool isLocked  { get { return mapaEstado == MapaEstadoEnum.LOCKED; } }
    public bool isBlocked { get { return mapaEstado == MapaEstadoEnum.BLOCKED; } }

    public WrapperLevelMapDto()
    {
    }    

    public WrapperLevelMapDto configDirecao(Direcao direcao)
    {
        this.direcao = direcao;
        return this;
    }

    public WrapperLevelMapDto configMapaEntidade(MapaEntidade mapaEntidade)
    {
        this.mapaEntidade = mapaEntidade;
        return this;
    }

    public WrapperLevelMapDto configLevelMapDto(LevelMapDto levelMapDto)
    {
        this.levelMapDto = levelMapDto;
        return this;
    }

    public WrapperLevelMapDto configEstado(MapaEstadoEnum mapaEstado)
    {
        this.mapaEstado = mapaEstado;
        return this;
    }
}
