using UnityEngine;

public class FactoryPowerUpInfoDto 
{
    public static PowerUpInfoDto ofInicio(PowerUpEntidade pupEntidade)
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.INICIO, pupEntidade);
        return pupInfo;
    }

    public static PowerUpInfoDto ofInicio(PowerUpEntidade pupEntidade, Vector3 posInicial)
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.INICIO, pupEntidade, posInicial);
        return pupInfo;
    }

    public static PowerUpInfoDto ofPreFinalizar()
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.PREFINALIZAR);
        return pupInfo;
    }

    public static PowerUpInfoDto ofPreFinalizar(Coletavel coletavel)
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.PREFINALIZAR, coletavel);
        return pupInfo;
    }

    public static PowerUpInfoDto ofExpirado()
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.EXPIRADO);
        return pupInfo;
    }

    public static PowerUpInfoDto ofFinalizar(int indiceBtn)
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.FINALIZAR, indiceBtn);        
        return pupInfo;
    }
}
