public class DinosColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "dinos";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(20, 9, "Triceratops"       , "triceratops256"      ),
            new ColetavelEntidade(21, 10, "T-Rex"            , "trex256"             ),
            new ColetavelEntidade(22, 11, "Pterodatilo"      , "pterodatilo256"      ),
            new ColetavelEntidade(23, 12, "Parassauro"       , "parassauro256"       ),
            new ColetavelEntidade(24, 13, "Pachicefalossauro", "pachicefalossauro256")
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
