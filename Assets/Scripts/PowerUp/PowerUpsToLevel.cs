public class PowerUpsToLevel 
{
    private int[] indicesAtuais;        

    private PowerUpEnums.TIPO[] pupsBtn0;//Transformar em bidimensional
    private PowerUpEnums.TIPO[] pupsBtn1;
    private PowerUpEnums.TIPO[] pupsBtn2;
    private PowerUpEnums.TIPO[] pupsBtn3;

    public PowerUpsToLevel()
    {
        indicesAtuais = new int[4];
    }

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
                if(pupsBtn0 != null && indicesAtuais[indiceBtn] < pupsBtn0.Length)
                {
                    pupTipo = pupsBtn0[indicesAtuais[indiceBtn]];
                    indicesAtuais[indiceBtn] = indicesAtuais[indiceBtn]++;
                }
                break;
            case 1:
                if (pupsBtn1 != null && indicesAtuais[indiceBtn] < pupsBtn1.Length)
                {
                    pupTipo = pupsBtn1[indicesAtuais[indiceBtn]];
                    indicesAtuais[indiceBtn] = indicesAtuais[indiceBtn]++;
                }
                break;
            case 2:
                if (pupsBtn2 != null && indicesAtuais[indiceBtn] < pupsBtn2.Length)
                {
                    pupTipo = pupsBtn2[indicesAtuais[indiceBtn]];
                    indicesAtuais[indiceBtn] = indicesAtuais[indiceBtn]++;
                }
                break;
            case 3:
                if (pupsBtn3 != null && indicesAtuais[indiceBtn] < pupsBtn3.Length)
                {
                    pupTipo = pupsBtn3[indicesAtuais[indiceBtn]];
                    indicesAtuais[indiceBtn]++;
                }
                break;
        }
        
        return pupTipo;
    }

}
