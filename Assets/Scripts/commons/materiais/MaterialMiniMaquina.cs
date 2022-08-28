using UnityEngine;
using System.Collections.Generic;

public class MaterialMiniMaquina 
{
    private static Material matMiniMaquina;

    public static void configurar(Material matSprMininiMaquina)
    {
        matMiniMaquina = matSprMininiMaquina;
    }

    public static Material getNewMaterial()
    {
        return new Material(matMiniMaquina);
    }

    public static void addCores(Material material, Dictionary<string, string> cores)
    {
        material.SetColor("_corFundo",              Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.CHAO_DENTRO]));
        material.SetColor("_corExterno",            Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.PLACA_FRENTE]));
        material.SetColor("_corCardsBackground",    Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_INTERNA]));
        material.SetColor("_corCards",              Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_EXTERNA]));
        material.SetColor("_corJoystick",           Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA]));
        material.SetColor("_corSetas",              Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_SETAS_LATERAIS]));
        material.SetColor("_corPontosBackground",   Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL1]));
        material.SetColor("_corPontos",             Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_GRUPO]));
        material.SetColor("_corTimerBackground",    Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO]));
        material.SetColor("_corTimer",              Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL]));
        material.SetColor("_corSimboloBackground",  Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO]));
        material.SetColor("_corSimbolo",            Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_EXTERNO]));
        material.SetColor("_corColetadoBackground", Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL1]));
        material.SetColor("_corColetado",           Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_GRUPO]));
    }
}
