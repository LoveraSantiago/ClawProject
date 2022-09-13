public class BolasColetaveisFornecedor : AbstractFornecedorColetaveisLevels
{
    public override string getPathSprite()
    {
        return "bolas";
    }

    protected override ColetavelEntidade[] getArrayDeColetaveis()
    {
        return new ColetavelEntidade[] {
            new ColetavelEntidade(30, 14, "Bola de Beisebol"       , "baseball"        ),
            new ColetavelEntidade(31, 15, "Bola de Basquete"       , "basket"          ),
            new ColetavelEntidade(32, 16, "Bola de Bilhar"         , "bilhar"          ),
            new ColetavelEntidade(33, 17, "Bocha"                  , "bocha"           ),
            new ColetavelEntidade(34, 18, "Bola de Leite"          , "boladeleite"     ),
            new ColetavelEntidade(35, 19, "Bola de Boliche"        , "boliche"         ),
            new ColetavelEntidade(36, 20,  "Bola de Capotao"        , "football"       ),
            new ColetavelEntidade(37, 21, "Bola de Futebol"        , "footbolamericano"),
            new ColetavelEntidade(38, 22, "Bola de Tenis"          , "tenis"           )
        };
    }

    protected override AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade)
    {
        return null;
    }
}
