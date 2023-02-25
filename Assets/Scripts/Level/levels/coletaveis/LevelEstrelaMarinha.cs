public class LevelEstrelaMarinha : AbstractLevelColetavel
{
    public LevelEstrelaMarinha() : base(new MaquinaCorIcebergGelada()){}

    public override string getLevelTitle()
    {
        return "Level EstrelaMarinha";
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]{
            {1, 2, 5, 6, 5, 2, 1},
             {-1, 4, 6, 6, 4, -1, -1},
            {-1, -1, 3, -1, 3, -1, -1},
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
           .addPupsParaBtn(0, new PowerUpEnums.TIPO[] { PowerUpEnums.TIPO.MINA_TERRESTRE });
    }
}
