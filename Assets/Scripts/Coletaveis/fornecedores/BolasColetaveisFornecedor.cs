public class BolasColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override ColetavelEntidade[] getColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(30, 14, "Bola de Beisebol"       , "baseball"        , MapaEnum.BOLAS),
            new ColetavelEntidade(31, 15, "Bola de Basquete"       , "basket"          , MapaEnum.BOLAS),
            new ColetavelEntidade(32, 16, "Bola de Bilhar"         , "bilhar"          , MapaEnum.BOLAS),
            new ColetavelEntidade(33, 17, "Bocha"                  , "bocha"           , MapaEnum.BOLAS),
            new ColetavelEntidade(34, 18, "Bola de Leite"          , "boladeleite"     , MapaEnum.BOLAS),
            new ColetavelEntidade(35, 19, "Bola de Boliche"        , "boliche"         , MapaEnum.BOLAS),
            new ColetavelEntidade(36, 20,  "Bola de Capotao"        , "football"        , MapaEnum.BOLAS),
            new ColetavelEntidade(37, 21, "Bola de Futebol"        , "footbolamericano", MapaEnum.BOLAS),
            new ColetavelEntidade(38, 22, "Bola de Tenis"          , "tenis"           , MapaEnum.BOLAS)
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
