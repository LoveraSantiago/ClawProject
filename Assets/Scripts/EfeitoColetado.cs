using UnityEngine;
using System.Collections;

public class EfeitoColetado : ConsumidorDeEvento<InformacoesColetado>
{    
    private Vector3 posicaoOriginal;

    private ParticleSystem particulas;
    private MonoBehaviour monoBehaviour;

    private ParticulasDto particulasDto;

    public EfeitoColetado(ParticulasDto particulasDto, MonoBehaviour monoBehaviour)
    {
        this.particulasDto = particulasDto;
        
        this.monoBehaviour = monoBehaviour;

        posicaoOriginal = particulasDto.ParentParticulas.transform.position;
        particulas      = particulasDto.ParentParticulas.GetComponent<ParticleSystem>();
        particulas.Stop();
    }

    private void playEfeitoColetado(Vector3 posicao)
    {
        float posX = posicao.x;
        float posY = posicaoOriginal.y;
        float posZ = posicaoOriginal.z;
        particulasDto.ParentParticulas.transform.position = new Vector3(posX, posY, posZ);
        particulasDto.SeguidoraParticulas.transform.position = particulasDto.ParentParticulas.transform.position;
        particulas.Play();

        monoBehaviour.StartCoroutine(
            moverEfeito(particulasDto.DestinoParticulas.transform.position, particulasDto.VelocidadeMovimentacao));
    }

    public IEnumerator moverEfeito(Vector3 posFim, float velocidade)
    {
        //yield return new WaitForSeconds(0.5f);
        while ((Vector3.Distance(particulasDto.SeguidoraParticulas.transform.position, posFim))
               > (velocidade * Time.deltaTime))
        {
            particulasDto.SeguidoraParticulas.transform.position = Vector3.MoveTowards(
                particulasDto.SeguidoraParticulas.transform.position, posFim, velocidade * Time.deltaTime);

            yield return null;
        }
        particulasDto.SeguidoraParticulas.transform.position = posFim;
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
