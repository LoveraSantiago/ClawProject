public class LevelLeite : AbstractLevelColetavel
{
    public LevelLeite() : base(new MaquinaCorChocolateComMorango()){}

    public override string getLevelTitle()
    {
        return "Level Leite";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {4, 0, 4, 0, 4, 0, 4},
             {4, 4, 4, 4, 4, 4, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1},
            {-1, -1, -1, -1, -1, -1, -1}
        };
    }

    public override PowerUpsParaLevel getPupsToLevel()
    {
        return new PowerUpsParaLevel(1)
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MISSIL_TELEGUIADO});            
    }

}
