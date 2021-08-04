using UnityEngine;
using System.Collections;

public class EfeitoColetado : AcaoColetado.ConsumidorEvento
{    
    private Vector3 posOriginalEfeito;
    //private Vector3 posOriginalSeguidores;

    private ParticleSystem particulas;
    private MonoBehaviour monoBehaviour;

    private ParticulasDto particulasDto;

    public EfeitoColetado(ParticulasDto particulasDto, MonoBehaviour monoBehaviour)
    {
        this.particulasDto = particulasDto;        
        this.monoBehaviour = monoBehaviour;

        posOriginalEfeito = particulasDto.ParentParticulas.transform.position;
        //posOriginalSeguidores = particulasDto.SeguidoraParticulas.transform.position;
        particulas      = particulasDto.ParentParticulas.GetComponent<ParticleSystem>();
        particulas.Stop();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        particulasDto.ParentParticulas.transform.position = new Vector3(evento.posicao.x, posOriginalEfeito.y, posOriginalEfeito.z);
        //particulasDto.SeguidoraParticulas.transform.position = new Vector3(evento.posicao.x, posOriginalSeguidores.y, posOriginalSeguidores.y);
        //particulasDto.LuzSeguidora.transform.position = particulasDto.SeguidoraParticulas.transform.position;

        particulas.Play();

        //monoBehaviour.StartCoroutine(
        //    moverEfeito(particulasDto.DestinoParticulas.transform.position, particulasDto.VelocidadeMovimentacao));
    }

    public IEnumerator moverEfeito(Vector3 posFim, float velocidade)
    {
        //yield return new WaitForSeconds(0.5f);
        while ((Vector3.Distance(particulasDto.SeguidoraParticulas.transform.position, posFim))
               > (velocidade * Time.deltaTime))
        {
            particulasDto.SeguidoraParticulas.transform.position = Vector3.MoveTowards(
                particulasDto.SeguidoraParticulas.transform.position, posFim, velocidade * Time.deltaTime);

            particulasDto.LuzSeguidora.transform.position = particulasDto.SeguidoraParticulas.transform.position;

            yield return null;
        }
        particulasDto.SeguidoraParticulas.transform.position = posFim;
    }
}
