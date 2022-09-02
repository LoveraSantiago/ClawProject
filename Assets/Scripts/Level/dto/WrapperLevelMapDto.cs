public class WrapperLevelMapDto 
{
    public Direcao direcao { get; private set; }
    public LevelMapDto levelMapDto { get; private set; }

    public WrapperLevelMapDto(Direcao direcao, LevelMapDto levelMapDto)
    {
        this.levelMapDto = levelMapDto;
    }
}
