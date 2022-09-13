public class GeleiaColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "geleia";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(60, 36, "Geleia 1"  , "geleia1"  ),
            new ColetavelEntidade(61, 37, "Geleia 2"  , "geleia2"  ),
            new ColetavelEntidade(62, 38, "Geleia 3"  , "geleia3"  ),
            new ColetavelEntidade(63, 39, "Geleia 4"  , "geleia4"  ),
            new ColetavelEntidade(64, 40, "Geleia 5"  , "geleia5"  ),
            new ColetavelEntidade(65, 41, "Geleia 6"  , "geleia6"  ),
            new ColetavelEntidade(66, 42, "Geleia 7"  , "geleia7"  ),
            new ColetavelEntidade(67, 43, "Geleia 8"  , "geleia8"  ),
            new ColetavelEntidade(68, 44, "Geleia 9"  , "geleia9"  )
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }    
}
