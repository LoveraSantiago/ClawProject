public class WrapperLevelMapDto 
{
    public Direcao direcao { get; private set; }
    public MapaEntidade mapaEntidade { get; private set; }
    public LevelMapDto levelMapDto { get; private set; }
    public bool isCentralizado { get { return direcao == Direcao.CENTRALIZADA; } }
    public bool isEsquerda     { get { return direcao == Direcao.ESQUERDA; } }
    public bool isDireita      { get { return direcao == Direcao.DIREITA; } }

    public WrapperLevelMapDto(Direcao direcao, MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        this.direcao = direcao;
        this.levelMapDto = levelMapDto;
        
    }


}
