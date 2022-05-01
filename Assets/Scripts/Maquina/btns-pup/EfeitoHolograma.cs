using UnityEngine;
using System.Collections;

public class EfeitoHolograma 
{
    private GameObject goEfeitoHolograma;
    private Coroutine coroutineUpdateTime;

    public EfeitoHolograma(GameObject goEfeitoHolograma)
    {
        this.goEfeitoHolograma = goEfeitoHolograma;
    }

    public void ligar(EfeitoHologramaBtnPupDto efeitoHologramaDto)
    {
        efeitoHologramaDto.GoMainEfeito.SetActive(true);
        efeitoHologramaDto.GoEfeitoHorizontal.SetActive(true);

        coroutineUpdateTime = Utils.MonoBehaviour.StartCoroutine(updateTime(efeitoHologramaDto.MeshRendererEfeitoHorizontal.sharedMaterial));
    }

    public void desligar()
    {
        goEfeitoHolograma.SetActive(false);
        Utils.MonoBehaviour.StopCoroutine(coroutineUpdateTime);
    }

    private IEnumerator updateTime(Material material)
    {
        while (true)
        {
            material.SetFloat("_updateTime", Time.unscaledTime);
            yield return null;
        }
    }
}
