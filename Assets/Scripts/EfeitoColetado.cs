using UnityEngine;
using System.Collections;

public class EfeitoColetado : ConsumidorDeEvento<InformacoesColetado>
{
    private float velocidadeMovimentacao;
    private Vector3 posicaoDesejada;
    private Vector3 posicaoOriginal;
    private GameObject parentParticulas;

    private ParticleSystem particulas;
    private MonoBehaviour monoBehaviour;

    public EfeitoColetado(GameObject parentParticulas, 
        Vector3 posicaoDesejada,
        float velocidadeMovimentacao,
        MonoBehaviour monoBehaviour)
    {
        this.parentParticulas = parentParticulas;
        this.posicaoDesejada = posicaoDesejada;
        this.velocidadeMovimentacao = velocidadeMovimentacao;

        posicaoOriginal = parentParticulas.transform.position;
        particulas = parentParticulas.GetComponent<ParticleSystem>();
        particulas.Stop();
    }

    private void playEfeitoColetado(Vector3 posicao)
    {
        float posX = posicao.x;
        float posY = posicaoOriginal.y;
        float posZ = posicaoOriginal.z;
        parentParticulas.transform.position = new Vector3(posX, posY, posZ);
        particulas.Play();

        monoBehaviour.StartCoroutine(moverEfeito(posicaoDesejada, velocidadeMovimentacao));
    }

    public IEnumerator moverEfeito(Vector3 posFim, float velocidade)
    {
        while (Vector3.Distance(parentParticulas.transform.position, posFim) > velocidade * Time.deltaTime)
        {
            parentParticulas.transform.position = Vector3.MoveTowards(parentParticulas.transform.position, posFim, velocidade * Time.deltaTime);
            yield return null;
        }
        parentParticulas.transform.position = posFim;
    }

    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> INICIO
    public void consumirEvento(InformacoesColetado infoColetado)
    {
        playEfeitoColetado(infoColetado.posicao);
    }
    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> FIM

    public ConsumidorDeEvento<InformacoesColetado> getEfeitoConsumidorInfoColetado()
    {
        return this;
    }
}
