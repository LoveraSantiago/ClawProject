using UnityEngine;

public class EfeitoColetado : AcaoColetado.ConsumidorEvento
{    
    private Vector3 posOriginalEfeito;

    private ParticleSystem particulas;
    private MonoBehaviour monoBehaviour;

    private ParticulasDto particulasDto;

    public EfeitoColetado(ParticulasDto particulasDto, MonoBehaviour monoBehaviour)
    {
        this.particulasDto = particulasDto;        
        this.monoBehaviour = monoBehaviour;

        posOriginalEfeito = particulasDto.ParentParticulas.transform.position;
        particulas      = particulasDto.ParentParticulas.GetComponent<ParticleSystem>();
        particulas.Stop();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        particulasDto.ParentParticulas.transform.position = new Vector3(evento.posicao.x, posOriginalEfeito.y, posOriginalEfeito.z);
        particulas.Play();
    }
}
