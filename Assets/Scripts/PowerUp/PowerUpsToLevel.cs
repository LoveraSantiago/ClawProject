public class PowerUpsToLevel 
{
    private int indiceAtual0;
    private int indiceAtual1;
    private int indiceAtual2;
    private int indiceAtual3;

    private PowerUpEnums.TIPO[] pupsBtn0;
    private PowerUpEnums.TIPO[] pupsBtn1;
    private PowerUpEnums.TIPO[] pupsBtn2;
    private PowerUpEnums.TIPO[] pupsBtn3;

    public PowerUpsToLevel addBtn0(PowerUpEnums.TIPO[] tipos)
    {
        pupsBtn0 = tipos;
        return this;
    }

    public PowerUpsToLevel addBtn1(PowerUpEnums.TIPO[] tipos)
    {
        pupsBtn1 = tipos;
        return this;
    }

    public PowerUpsToLevel addBtn2(PowerUpEnums.TIPO[] tipos)
    {
        pupsBtn2 = tipos;
        return this;
    }

    public PowerUpsToLevel addBtn3(PowerUpEnums.TIPO[] tipos)
    {
        pupsBtn3 = tipos;
        return this;
    }

    public PowerUpEnums.TIPO getPupEntidade(int indiceBtn)
    {
        PowerUpEnums.TIPO pupTipo = PowerUpEnums.TIPO.NONE;        
        switch (indiceBtn)
        {
            case 0:
                if(pupsBtn0 != null && indiceAtual0 < pupsBtn0.Length)
                {
                    pupTipo = pupsBtn0[indiceAtual0];
                    indiceAtual0++;
                }
                break;
            case 1:
                if (pupsBtn1 != null && indiceAtual1 < pupsBtn1.Length)
                {
                    pupTipo = pupsBtn1[indiceAtual1];
                    indiceAtual1++;
                }
                break;
            case 2:
                if (pupsBtn2 != null && indiceAtual2 < pupsBtn2.Length)
                {
                    pupTipo = pupsBtn2[indiceAtual2];
                    indiceAtual2++;
                }
                break;
            case 3:
                if (pupsBtn3 != null && indiceAtual3 < pupsBtn3.Length)
                {
                    pupTipo = pupsBtn3[indiceAtual3];
                    indiceAtual3++;
                }
                break;
        }
        
        return pupTipo;
    }

}
