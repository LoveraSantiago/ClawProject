public class FornecedorLevelColetaveisFrutas : AbstractFornecedorColetaveisLevels
{
    protected override AbstractLevel getLevelToColetavel(int indice)
    {
        switch (indice)
        {
            case 0: return new LevelLeite(); 
            case 1: return new LevelMaca();
            case 2: return new LevelLaranja();
            case 3: return new LevelPao();
            case 4: return new LevelAspargo(); 
            case 5: return new LevelCoco();
            case 6: return new LevelEstrelaMarinha();
        }
        return null;
    }
}
