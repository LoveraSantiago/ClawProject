public class MegamanColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "megaman";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(80, 50, "Kalinka", "kalinka"),
            new ColetavelEntidade(81, 51, "Megaman", "megaman"),
            new ColetavelEntidade(82, 52, "Tadashi", "tadashi")
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
