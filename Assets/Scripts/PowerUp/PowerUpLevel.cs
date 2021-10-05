public class PowerUpLevel 
{
    private int indiceAtual0;
    private int indiceAtual1;
    private int indiceAtual2;
    private int indiceAtual3;

    private PowerUpEnums.TIPO[] pupsBtn1;
    private PowerUpEnums.TIPO[] pupsBtn2;
    private PowerUpEnums.TIPO[] pupsBtn3;
    private PowerUpEnums.TIPO[] pupsBtn4;

    public PowerUpLevel addBtn0(PowerUpEnums.TIPO[] tipos)
    {
        pupsBtn1 = tipos;
        return this;
    }

    public PowerUpLevel addBtn1(PowerUpEnums.TIPO[] tipos)
    {
        pupsBtn2 = tipos;
        return this;
    }

    public PowerUpLevel addBtn2(PowerUpEnums.TIPO[] tipos)
    {
        pupsBtn3 = tipos;
        return this;
    }

    public PowerUpLevel addBtn3(PowerUpEnums.TIPO[] tipos)
    {
        pupsBtn4 = tipos;
        return this;
    }

    public PowerUpEnums.TIPO getPupEntidade(int indiceBtn)
    {
        PowerUpEnums.TIPO pupTipo = PowerUpEnums.TIPO.NONE;        
        switch (indiceBtn)
        {
            case 0:
                pupTipo = pupsBtn1[indiceAtual0];
                indiceAtual0++;
                break;
            case 1:
                pupTipo = pupsBtn1[indiceAtual1];
                indiceAtual1++;
                break;
            case 2:
                pupTipo = pupsBtn1[indiceAtual2];
                indiceAtual2++;
                break;
            case 3:
                pupTipo = pupsBtn1[indiceAtual3];
                indiceAtual3++;
                break;
        }
        
        return pupTipo;
    }

}
