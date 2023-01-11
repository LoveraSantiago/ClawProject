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
        return new PowerUpInfoDto(
            PowerUpEnums.ESTADO.INICIO, pupEntidade, posInicial);        
    }

    public static PowerUpInfoDto ofEmAndamento(PowerUpEnums.ESTADO estadoAndamento)
    {
        return new PowerUpInfoDto(estadoAndamento);
    }

    public static PowerUpInfoDto ofPreFinalizar()
    {
        return new PowerUpInfoDto(PowerUpEnums.ESTADO.PREFINALIZAR);        
    }

    public static PowerUpInfoDto ofPreFinalizar(Coletavel coletavel)
    {
        return new PowerUpInfoDto(PowerUpEnums.ESTADO.PREFINALIZAR, coletavel);        
    }

    public static PowerUpInfoDto ofExpirado()
    {
        return new PowerUpInfoDto(PowerUpEnums.ESTADO.EXPIRADO);        
    }

    public static PowerUpInfoDto ofFinalizar(int indiceBtn)
    {
        return new PowerUpInfoDto(PowerUpEnums.ESTADO.FINALIZAR, indiceBtn);                
    }
}
