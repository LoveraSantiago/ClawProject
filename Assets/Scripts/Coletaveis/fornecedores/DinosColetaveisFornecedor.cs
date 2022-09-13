public class DinosColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override ColetavelEntidade[] getColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(20, 9, "Triceratops"       , "triceratops256"      , MapaEnum.DINO),
            new ColetavelEntidade(21, 10, "T-Rex"            , "trex256"             , MapaEnum.DINO),
            new ColetavelEntidade(22, 11, "Pterodatilo"      , "pterodatilo256"      , MapaEnum.DINO),
            new ColetavelEntidade(23, 12, "Parassauro"       , "parassauro256"       , MapaEnum.DINO),
            new ColetavelEntidade(24, 13, "Pachicefalossauro", "pachicefalossauro256", MapaEnum.DINO)
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
