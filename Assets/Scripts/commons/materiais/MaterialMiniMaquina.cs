using UnityEngine;
using System.Collections.Generic;

public class MaterialMiniMaquina 
{
    private static readonly int ID_COR_FUNDO         = Shader.PropertyToID("_corFundo");
    private static readonly int ID_COR_EXTERNO       = Shader.PropertyToID("_corExterno");
    private static readonly int ID_COR_CARD_BACK     = Shader.PropertyToID("_corCardsBackground");
    private static readonly int ID_COR_CARD          = Shader.PropertyToID("_corCards");
    private static readonly int ID_COR_JOYSTICK      = Shader.PropertyToID("_corJoystick");
    private static readonly int ID_COR_SETAS         = Shader.PropertyToID("_corSetas");
    private static readonly int ID_COR_PONTOS_BACK   = Shader.PropertyToID("_corPontosBackground");
    private static readonly int ID_COR_PONTOS        = Shader.PropertyToID("_corPontos");
    private static readonly int ID_COR_TIMER_BACK    = Shader.PropertyToID("_corTimerBackground");
    private static readonly int ID_COR_TIMER         = Shader.PropertyToID("_corTimer");
    private static readonly int ID_COR_SIMBOLO_BACK  = Shader.PropertyToID("_corSimboloBackground");
    private static readonly int ID_COR_SIMBOLO       = Shader.PropertyToID("_corSimbolo");
    private static readonly int ID_COR_COLETADO_BACK = Shader.PropertyToID("_corColetadoBackground");
    private static readonly int ID_COR_COLETADO      = Shader.PropertyToID("_corColetado");

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
        materialDestino.SetColor(ID_COR_FUNDO        , materialOrigem.GetColor(ID_COR_FUNDO));
        materialDestino.SetColor(ID_COR_EXTERNO      , materialOrigem.GetColor(ID_COR_EXTERNO));
        materialDestino.SetColor(ID_COR_CARD_BACK    , materialOrigem.GetColor(ID_COR_CARD_BACK));
        materialDestino.SetColor(ID_COR_CARD         , materialOrigem.GetColor(ID_COR_CARD));
        materialDestino.SetColor(ID_COR_JOYSTICK     , materialOrigem.GetColor(ID_COR_JOYSTICK));
        materialDestino.SetColor(ID_COR_PONTOS_BACK  , materialOrigem.GetColor(ID_COR_PONTOS_BACK));
        materialDestino.SetColor(ID_COR_PONTOS       , materialOrigem.GetColor(ID_COR_PONTOS));
        materialDestino.SetColor(ID_COR_TIMER_BACK   , materialOrigem.GetColor(ID_COR_TIMER_BACK));
        materialDestino.SetColor(ID_COR_TIMER        , materialOrigem.GetColor(ID_COR_TIMER));
        materialDestino.SetColor(ID_COR_SIMBOLO_BACK , materialOrigem.GetColor(ID_COR_SIMBOLO_BACK));
        materialDestino.SetColor(ID_COR_SIMBOLO      , materialOrigem.GetColor(ID_COR_SIMBOLO));
        materialDestino.SetColor(ID_COR_COLETADO_BACK, materialOrigem.GetColor(ID_COR_COLETADO_BACK));
        materialDestino.SetColor(ID_COR_COLETADO     , materialOrigem.GetColor(ID_COR_COLETADO));        
        materialDestino.SetColor(ID_COR_SETAS        , materialOrigem.GetColor(ID_COR_SETAS));
        subtrairTempo(materialDestino);
    }

    private static void colorirFullBranco(Material material)
    {
        material.SetColor(ID_COR_FUNDO,         Color.black);
        material.SetColor(ID_COR_EXTERNO,       Color.black);
        material.SetColor(ID_COR_CARD_BACK,     Color.black);
        material.SetColor(ID_COR_CARD,          Color.black);
        material.SetColor(ID_COR_JOYSTICK,      Color.black);
        material.SetColor(ID_COR_SETAS,         Color.black);
        material.SetColor(ID_COR_PONTOS_BACK,   Color.black);
        material.SetColor(ID_COR_PONTOS,        Color.black);
        material.SetColor(ID_COR_TIMER_BACK,    Color.black);
        material.SetColor(ID_COR_TIMER,         Color.black);
        material.SetColor(ID_COR_SIMBOLO_BACK,  Color.black);
        material.SetColor(ID_COR_SIMBOLO,       Color.black);
        material.SetColor(ID_COR_COLETADO_BACK, Color.black);
        material.SetColor(ID_COR_COLETADO,      Color.black);
        subtrairTempo(material);
    }

    private static void colorirNivelHum(Material material, Dictionary<string, string> cores)
    {
        material.SetColor(ID_COR_FUNDO,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.CHAO_DENTRO]));
        material.SetColor(ID_COR_EXTERNO,       Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.PLACA_FRENTE]));
        material.SetColor(ID_COR_CARD_BACK,     Color.black);
        material.SetColor(ID_COR_CARD,          Color.black);
        material.SetColor(ID_COR_JOYSTICK,      Color.black);
        material.SetColor(ID_COR_SETAS,         Color.black);
        material.SetColor(ID_COR_PONTOS_BACK,   Color.black);
        material.SetColor(ID_COR_PONTOS,        Color.black);
        material.SetColor(ID_COR_TIMER_BACK,    Color.black);
        material.SetColor(ID_COR_TIMER,         Color.black);
        material.SetColor(ID_COR_SIMBOLO_BACK,  Color.black);
        material.SetColor(ID_COR_SIMBOLO,       Color.black);
        material.SetColor(ID_COR_COLETADO_BACK, Color.black);
        material.SetColor(ID_COR_COLETADO,      Color.black);
        subtrairTempo(material);
    }

    private static void colorirNivelDois(Material material, Dictionary<string, string> cores)
    {
        material.SetColor(ID_COR_FUNDO,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.CHAO_DENTRO]));
        material.SetColor(ID_COR_EXTERNO,       Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.PLACA_FRENTE]));
        material.SetColor(ID_COR_CARD_BACK,     Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_INTERNA]));
        material.SetColor(ID_COR_CARD,          Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_EXTERNA]));
        material.SetColor(ID_COR_JOYSTICK,      Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA]));
        material.SetColor(ID_COR_SETAS,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_SETAS_LATERAIS]));
        material.SetColor(ID_COR_PONTOS_BACK,   Color.black);
        material.SetColor(ID_COR_PONTOS,        Color.black);
        material.SetColor(ID_COR_TIMER_BACK,    Color.black);
        material.SetColor(ID_COR_TIMER,         Color.black);
        material.SetColor(ID_COR_SIMBOLO_BACK,  Color.black);
        material.SetColor(ID_COR_SIMBOLO,       Color.black);
        material.SetColor(ID_COR_COLETADO_BACK, Color.black);
        material.SetColor(ID_COR_COLETADO,      Color.black);
        subtrairTempo(material);
    }

    private static void coloriCompleto(Material material, Dictionary<string, string> cores)
    {
        material.SetColor(ID_COR_FUNDO,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.CHAO_DENTRO]));
        material.SetColor(ID_COR_EXTERNO,       Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.PLACA_FRENTE]));
        material.SetColor(ID_COR_CARD_BACK,     Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_INTERNA]));
        material.SetColor(ID_COR_CARD,          Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_EXTERNA]));
        material.SetColor(ID_COR_JOYSTICK,      Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA]));
        material.SetColor(ID_COR_SETAS,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SCROLL_PUP_SETAS_LATERAIS]));
        material.SetColor(ID_COR_PONTOS_BACK,   Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL1]));
        material.SetColor(ID_COR_PONTOS,        Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_GRUPO]));
        material.SetColor(ID_COR_TIMER_BACK,    Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO]));
        material.SetColor(ID_COR_TIMER,         Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL]));
        material.SetColor(ID_COR_SIMBOLO_BACK,  Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO]));
        material.SetColor(ID_COR_SIMBOLO,       Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.SIMBOLO_CIRC_EXTERNO]));
        material.SetColor(ID_COR_COLETADO_BACK, Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL1]));
        material.SetColor(ID_COR_COLETADO,      Utils.getCorByHex(cores[ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_GRUPO]));
        subtrairTempo(material);
    }

    private static void subtrairTempo(Material material)
    {
        material.SetFloat("_tempoSubtrair", Time.time);
    }
}
