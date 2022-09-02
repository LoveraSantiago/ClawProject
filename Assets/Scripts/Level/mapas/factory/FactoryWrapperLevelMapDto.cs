public class FactoryWrapperLevelMapDto 
{
    public static WrapperLevelMapDto factory(Direcao direcao, LevelMapDto levelMapDto)
    {
        return new WrapperLevelMapDto(direcao, levelMapDto);
    }
}
