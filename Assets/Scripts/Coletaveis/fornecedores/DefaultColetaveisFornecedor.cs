public class DefaultColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(0, -1, "vazio" , "tile-vazio"      ),
            new ColetavelEntidade(1, -1, "random", "tile-random"     ),
            new ColetavelEntidade(2, -1, "ovo"   , "capsula-completa"),
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
