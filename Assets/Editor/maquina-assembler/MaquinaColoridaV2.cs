using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaquinaColoridaV2 : FinderComponente
{
    private GameObject goMaquina;
    private GameObject goCabo;
    private Dictionary<string, ComponenteColorivel> dicionario;

    public MaquinaColoridaV2()
    {
        inicializarGos();

        dicionario = new Dictionary<string, ComponenteColorivel>();
        dicionario.Add(ConstantesCoresMaquinaV2.PLACA_FRENTE, new SingleCompColorivel(findNaMaquina(ConstantesCoresMaquinaV2.PLACA_FRENTE)));

        Fornecedor<ComponenteColorivel> vigasColoriveis = new VigasColoriveis(this);
        dicionario.Add(ConstantesCoresMaquinaV2.VIGAS, vigasColoriveis.fornecer());

        TimerColorivel timerColorivel = new TimerColorivel(this);
        dicionario.Add(ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL, timerColorivel.getPlacaPrincipal());
        dicionario.Add(ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO, timerColorivel.getPlacaDigitos());
        dicionario.Add(ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS, timerColorivel.getSegmentos());
    }

    private void inicializarGos()
    {
        GameObject[] gos = SceneManager.GetActiveScene().GetRootGameObjects();
        for (int contador = 0; contador < gos.Length; contador++)
        {
            if (gos[contador].name == "main-object")
            {
                goMaquina = findNoComponente(gos[contador], "maquina-v3");                
                goCabo = findNoComponente(gos[contador], "cabo-da-garra");
                return;
            }
        }
        Debug.LogError("Cena nao contem game object maquina");
    }

    public GameObject findNaMaquina(string nome)
    {
        return goMaquina.transform.Find(nome).gameObject;
    }

    public GameObject findNoComponente(GameObject go, string nome)
    {
        return go.transform.Find(nome).gameObject;
    }

    public void colorir(string nome, Color cor)
    {
        dicionario[nome].passarCor(cor);
    }

    public void select(string nome)
    {
        Selection.activeGameObject = dicionario[nome].getGo();
    }

    public void reset(string nome)
    {
        dicionario[nome].resetCor();
    }
}
