using UnityEngine;
using System.Collections.Generic;

public class PlayerPrefsMapas 
{    
    private static readonly string LEVEL_LIBERADO       = "level-liberado";
    private static readonly string MAPA_NAVEGACAO       = "mapa-naveg";
    private static readonly string MAPA_COLETAVEIS      = "mapa-col-";
    private static readonly string MAPA_CHALLENGES      = "mapa-challenges-";
    private static readonly string NEW_LEVEL_BTN_BALAO  = "new-level-balao";
    private static readonly string NEW_LEVEL_LEVEL      = "new-level-level";
    private static readonly string NEW_LEVEL_ESPECIFICO = "new-level-especifico";
    private static readonly string NEW_COLETAVEL_LEVEL  = "new-coletavel-level";
    private static readonly string NEW_COLETAVEIS       = "new-coletaveis";
    private static readonly string NEW_MAPA             = "new-mapa-naveg";

    private static int DESLIGADO = 0;
    private static int LIGADO    = 1;

    public static int getIndiceMapaLiberado()//TODO ADICIONAR CRIPTOGRAFIA SEGURANCA
    {
        int indiceLevelLiberado = getIndiceLevelLiberado();
        int resultado = (indiceLevelLiberado + 9) / 10;
        //Debug.Log("Resultado indice mapa liberado " + resultado);
        return resultado;
        //return 100;
    }

    public static MapaEntidade getIndiceNavegacaoMapa()
    {
        int indice = PlayerPrefs.GetInt(MAPA_NAVEGACAO, LIGADO);
        return HelperMapaEntidade.getMapaEntidadeByIndice(indice);
    }

    public static int getIndiceLevelLiberado()
    {
        int indice = PlayerPrefs.GetInt(LEVEL_LIBERADO, 1);
        //Debug.Log("Recuperando indice level " + indice);
        return indice;
        //return 8; //PARA TESTES DIRETO NO LEVEL DE FASES
    }

    public static void salvarIndiceLevelLiberado(int indiceLevel)
    {
        int indiceAtual = getIndiceLevelLiberado();
        if(indiceLevel > indiceAtual)
        {
            //Debug.Log("Salvando indice level " + indiceLevel);
            PlayerPrefs.SetInt(NEW_LEVEL_BTN_BALAO, LIGADO);
            PlayerPrefs.SetInt(NEW_LEVEL_LEVEL, LIGADO);
            PlayerPrefs.SetInt(LEVEL_LIBERADO, indiceLevel);
            salvarNovaLiberacaoLevelEspecifico(indiceLevel);

            if (indiceLevel % 10 == 1 && indiceLevel > 10)
            {
                PlayerPrefs.SetInt(NEW_MAPA, LIGADO);
                PlayerPrefs.SetInt(NEW_COLETAVEL_LEVEL, LIGADO);
            }
        }
    }

    public static void salvarIndiceNavegacaoMapa(MapaEntidade mapaEntidade)
    {
        PlayerPrefs.SetInt(MAPA_NAVEGACAO, mapaEntidade.id);        
    }

    public static bool isNovaLiberacaoLevelBalao()
    {
        int result = PlayerPrefs.GetInt(NEW_LEVEL_BTN_BALAO, LIGADO);
        return result == LIGADO;
    }

    public static void consumidoNovaLiberacaoLevelBalao()
    {
        PlayerPrefs.SetInt(NEW_LEVEL_BTN_BALAO, DESLIGADO);
    }

    public static bool isNovaLiberacaoMapa()
    {
        int result = PlayerPrefs.GetInt(NEW_MAPA);
        return result == LIGADO;
    }

    public static void consumidoNovaLiberacaoMapa()
    {
        PlayerPrefs.SetInt(NEW_MAPA, DESLIGADO);
    }

    public static bool isNovaLiberacaoLevel()
    {
        int result = PlayerPrefs.GetInt(NEW_LEVEL_LEVEL, LIGADO);
        return result == LIGADO; 
    }

    public static void consumidoNovaLiberacaoLevel()
    {
        PlayerPrefs.SetInt(NEW_LEVEL_LEVEL, DESLIGADO);
    }

    public static bool isNovaLiberacaoColetavel()
    {
        int result = PlayerPrefs.GetInt(NEW_COLETAVEL_LEVEL, LIGADO);
        return result == LIGADO;
    }

    public static void consumidoNovaLiberacaoColetavel()
    {
        PlayerPrefs.SetInt(NEW_COLETAVEL_LEVEL, DESLIGADO);
    }

    private static void salvarNovaLiberacaoLevelEspecifico(int indiceLevel)
    {
        int[] arrayLevels = getLiberacaoLevelsEspecificos();       
        List<int> listaOrdenada = new List<int>(arrayLevels);
        listaOrdenada.Add(indiceLevel);
        listaOrdenada.Sort();

        salvarListaLiberacaoLevelEspecifico(listaOrdenada);        
    }

    public static int[] getNovaLiberacaoLevelEspecifico()
    {
        return getLiberacaoLevelsEspecificos();
    }

    public static int[] consumidoNovaLiberacaoLevelEspecifico(int indiceConsumido)
    {
        int[] arrayLevels = getLiberacaoLevelsEspecificos();
        List<int> listaOrdenada = new List<int>(arrayLevels);
        listaOrdenada.Sort();
        listaOrdenada.Remove(indiceConsumido);

        salvarListaLiberacaoLevelEspecifico(listaOrdenada);
        return listaOrdenada.ToArray();
    }

    public static int[] getChallengesDoMapa(MapaEntidade mapaEntidade)
    {
        string chave = MAPA_CHALLENGES + mapaEntidade.id;
        //return recuperarArray(chave, 10, 7);        
        return getArray(chave, 10, DESLIGADO);        
    }

    public static void salvarChallengeDoMapa(MapaEntidade mapaEntidade, int indiceLevel, int challenge)
    {
        int[] challenges = getChallengesDoMapa(mapaEntidade);
        if(challenges[indiceLevel] != challenge)
        {
            challenges[indiceLevel] = challenge;

            string chave = MAPA_CHALLENGES + mapaEntidade.id;
            salvarArray(chave, challenges);

            salvarNovaLiberacaoLevelEspecifico(indiceLevel);
        }
    }

    public static int[] getColetaveisAdquiridosDoMapa(MapaEntidade mapaEntidade, int qtdColetaveis)
    {
        string chave = MAPA_COLETAVEIS + mapaEntidade.id;
        return getArray(chave, qtdColetaveis, DESLIGADO);
    }

    public static int[] getColetaveisEstadoLiberadosDoMapa(MapaEntidade mapaEntidade, int qtdColetaveis)
    {
        string chave = NEW_COLETAVEIS + mapaEntidade.id;
        return getArray(chave, qtdColetaveis, LIGADO);
    }   

    public static void consumirColetavelEstadoLiberadosDoMapa(ColetavelEntidade coletavel)
    {
        MapaEntidade mapaEntidade = coletavel.mapaEntidade;
        string chave = NEW_COLETAVEIS + mapaEntidade.id;
        int[] arrayLiberados = getColetaveisEstadoLiberadosDoMapa(mapaEntidade, mapaEntidade.getQtdColetaveis());
        arrayLiberados[coletavel.indice] = DESLIGADO;
        salvarArray(chave, arrayLiberados);
    }

    public static void salvarColetavelAdquiridoDoDoMapa(ColetavelEntidade coletavel)
    {
        MapaEntidade mapaEntidade = coletavel.mapaEntidade;
        string chave = MAPA_COLETAVEIS + mapaEntidade.id;
        int[] coletaveisEstadoLiberado = getColetaveisAdquiridosDoMapa(mapaEntidade, mapaEntidade.getQtdColetaveis());

        if(coletaveisEstadoLiberado[coletavel.indice] == DESLIGADO)
        {
            coletaveisEstadoLiberado[coletavel.indice] = LIGADO;
            salvarArray(chave, coletaveisEstadoLiberado);
        }
    }

    private static int[] getArray(string chave, int tamanhoArray, int estado)
    {
        string arrayString = PlayerPrefs.GetString(chave);
        if (Utils.isBlank(arrayString))
        {
            int[] arrayVazio = Utils.criarArrayPopuladoDeInteiros(tamanhoArray, estado);
            salvarArray(chave, arrayVazio);
            return arrayVazio;
        }
        else
        {
            WrapperArrayInteiros wrapper = JsonUtility.FromJson<WrapperArrayInteiros>(arrayString);
            if (wrapper.array == null)
            {
                return Utils.criarArrayPopuladoDeInteiros(tamanhoArray, estado);
            }
            return wrapper.array;
        }
    }

    private static void salvarArray(string chave, int[] estados)
    {
        WrapperArrayInteiros wrapper = new WrapperArrayInteiros();
        wrapper.array = estados;
        string arrayString = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString(chave, arrayString);
        Debug.Log("Chave " + chave + " array " + arrayString);
    }

    private static int[] getLiberacaoLevelsEspecificos()
    {        
        string arrayString = PlayerPrefs.GetString(NEW_LEVEL_ESPECIFICO);
        if (Utils.isBlank(arrayString))
        {
            List<int> listaInicial = new List<int>();
            listaInicial.Add(LIGADO);

            salvarListaLiberacaoLevelEspecifico(listaInicial);
            arrayString = PlayerPrefs.GetString(NEW_LEVEL_ESPECIFICO); 
        }        
        WrapperArrayInteiros wrapper= JsonUtility.FromJson<WrapperArrayInteiros>(arrayString);
        if(wrapper.array == null)
        {
            return new int[0] { };
        }
        return wrapper.array;                
    }    

    private static void salvarListaLiberacaoLevelEspecifico(List<int> listaOrdenada)
    {
        int[] arrayLevels = listaOrdenada.ToArray();
        WrapperArrayInteiros wrapper = new WrapperArrayInteiros();
        wrapper.array = arrayLevels;

        string arrayString = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString(NEW_LEVEL_ESPECIFICO, arrayString);
    }      
}
