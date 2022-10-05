using UnityEngine;
using System.Collections.Generic;

public class MaterialMiniMaquina 
{
    private const string COR_FUNDO         = "_corFundo";
    private const string COR_EXTERNO       = "_corExterno";
    private const string COR_CARD_BACK     = "_corCardsBackground";
    private const string COR_CARD          = "_corCards";
    private const string COR_JOYSTICK      = "_corJoystick";
    private const string COR_SETAS         = "_corSetas";
    private const string COR_PONTOS_BACK   = "_corPontosBackground";
    private const string COR_PONTOS        = "_corPontos";
    private const string COR_TIMER_BACK    = "_corTimerBackground";
    private const string COR_TIMER         = "_corTimer";
    private const string COR_SIMBOLO_BACK  = "_corSimboloBackground";
    private const string COR_SIMBOLO       = "_corSimbolo";
    private const string COR_COLETADO_BACK = "_corColetadoBackground";
    private const string COR_COLETADO      = "_corColetado";

    private static Material matMiniMaquina;    

    public static void configurar(Material matSprMininiMaquina)
    {
        matMiniMaquina = matSprMininiMaquina;
    }

    public static Material getNewMaterial()
    {
        return new Material(matMiniMaquina);
    }

    public static void addCores(int estrelas, Material material, Dictionary<string, string> cores)
    {
        if(estrelas == 0)
        {
            colorirFullBranco(material);
        }
        else if(estrelas == 1)
        {
            colorirNivelHum(material, cores);
        }
        else if(estrelas == 2)
        {
            colorirNivelDois(material, cores);
        }
        else
        {
            coloriCompleto(material, cores);
        }
    }

    public static void addCores(Material materialDestino, Material materialOrigem)
    {        
        materialDestino.SetColor(COR_FUNDO        , materialOrigem.GetColor(COR_FUNDO));
        materialDestino.SetColor(COR_EXTERNO      , materialOrigem.GetColor(COR_EXTERNO));
        materialDestino.SetColor(COR_CARD_BACK    , materialOrigem.GetColor(COR_CARD_BACK));
        materialDestino.SetColor(COR_CARD         , materialOrigem.GetColor(COR_CARD));
        materialDestino.SetColor(COR_JOYSTICK     , materialOrigem.GetColor(COR_JOYSTICK));
        materialDestino.SetColor(COR_PONTOS_BACK  , materialOrigem.GetColor(COR_PONTOS_BACK));
        materialDestino.SetColor(COR_PONTOS       , materialOrigem.GetColor(COR_PONTOS));
        materialDestino.SetColor(COR_TIMER_BACK   , materialOrigem.GetColor(COR_TIMER_BACK));
        materialDestino.SetColor(COR_TIMER        , materialOrigem.GetColor(COR_TIMER));
        materialDestino.SetColor(COR_SIMBOLO_BACK , materialOrigem.GetColor(COR_SIMBOLO_BACK));
        materialDestino.SetColor(COR_SIMBOLO      , materialOrigem.GetColor(COR_SIMBOLO));
        materialDestino.SetColor(COR_COLETADO_BACK, materialOrigem.GetColor(COR_COLETADO_BACK));
        materialDestino.SetColor(COR_COLETADO     , materialOrigem.GetColor(COR_COLETADO));        
        materialDestino.SetColor(COR_SETAS        , materialOrigem.GetColor(COR_SETAS));        
    }

    private static void colorirFullBranco(Material material)
    {
        material.SetColor(COR_FUNDO,         Color.black);
        material.SetColor(COR_EXTERNO,       Color.black);
        material.SetColor(COR_CARD_BACK,     Color.black);
        material.SetColor(COR_CARD,          Color.black);
        material.SetColor(COR_JOYSTICK,      Color.black);
        material.SetColor(COR_SETAS,         Color.black);
        material.SetColor(COR_PONTOS_BACK,   Color.black);
        material.SetColor(COR_PONTOS,        Color.black);
        material.SetColor(COR_TIMER_BACK,    Color.black);
        material.SetColor(COR_TIMER,         Color.black);
        material.SetColor(COR_SIMBOLO_BACK,  Color.black);
        material.SetColor(COR_SIMBOLO,       Color.black);
        material.SetColor(COR_COLETADO_BACK, Color.black);
        material.SetColor(COR_COLETADO,      Color.black);
    }

    private static void colorirNivelHum(Material material, Dictionary<string, string> cores)
    {
        material.SetColor(COR_FUNDO,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.CHAO_DENTRO]));
        material.SetColor(COR_EXTERNO,       Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.PLACA_FRENTE]));
        material.SetColor(COR_CARD_BACK,     Color.black);
        material.SetColor(COR_CARD,          Color.black);
        material.SetColor(COR_JOYSTICK,      Color.black);
        material.SetColor(COR_SETAS,         Color.black);
        material.SetColor(COR_PONTOS_BACK,   Color.black);
        material.SetColor(COR_PONTOS,        Color.black);
        material.SetColor(COR_TIMER_BACK,    Color.black);
        material.SetColor(COR_TIMER,         Color.black);
        material.SetColor(COR_SIMBOLO_BACK,  Color.black);
        material.SetColor(COR_SIMBOLO,       Color.black);
        material.SetColor(COR_COLETADO_BACK, Color.black);
        material.SetColor(COR_COLETADO,      Color.black);
    }

    private static void colorirNivelDois(Material material, Dictionary<string, string> cores)
    {
        material.SetColor(COR_FUNDO,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.CHAO_DENTRO]));
        material.SetColor(COR_EXTERNO,       Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.PLACA_FRENTE]));
        material.SetColor(COR_CARD_BACK,     Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_INTERNA]));
        material.SetColor(COR_CARD,          Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_EXTERNA]));
        material.SetColor(COR_JOYSTICK,      Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA]));
        material.SetColor(COR_SETAS,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_SETAS_LATERAIS]));
        material.SetColor(COR_PONTOS_BACK,   Color.black);
        material.SetColor(COR_PONTOS,        Color.black);
        material.SetColor(COR_TIMER_BACK,    Color.black);
        material.SetColor(COR_TIMER,         Color.black);
        material.SetColor(COR_SIMBOLO_BACK,  Color.black);
        material.SetColor(COR_SIMBOLO,       Color.black);
        material.SetColor(COR_COLETADO_BACK, Color.black);
        material.SetColor(COR_COLETADO,      Color.black);
    }

    private static void coloriCompleto(Material material, Dictionary<string, string> cores)
    {
        material.SetColor(COR_FUNDO,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.CHAO_DENTRO]));
        material.SetColor(COR_EXTERNO,       Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.PLACA_FRENTE]));
        material.SetColor(COR_CARD_BACK,     Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_INTERNA]));
        material.SetColor(COR_CARD,          Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_EXTERNA]));
        material.SetColor(COR_JOYSTICK,      Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA]));
        material.SetColor(COR_SETAS,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_SETAS_LATERAIS]));
        material.SetColor(COR_PONTOS_BACK,   Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL1]));
        material.SetColor(COR_PONTOS,        Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_GRUPO]));
        material.SetColor(COR_TIMER_BACK,    Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO]));
        material.SetColor(COR_TIMER,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL]));
        material.SetColor(COR_SIMBOLO_BACK,  Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO]));
        material.SetColor(COR_SIMBOLO,       Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_EXTERNO]));
        material.SetColor(COR_COLETADO_BACK, Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL1]));
        material.SetColor(COR_COLETADO,      Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_GRUPO]));
    }

}
