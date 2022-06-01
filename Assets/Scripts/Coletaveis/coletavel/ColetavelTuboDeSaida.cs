using UnityEngine;

public class ColetavelTuboDeSaida 
{
    private ColetavelTuboDeSaidaDto coletavelTuboSaidaDto;

    public ColetavelTuboDeSaida(ColetavelTuboDeSaidaDto coletavelTuboSaidaDto)
    {
        this.coletavelTuboSaidaDto = coletavelTuboSaidaDto;
    }

    public void prepararParaDescarte(float torque, float gravidade,  Sprite spriteAtual)
    {
        coletavelTuboSaidaDto.RigidBodyColetavel.gameObject.SetActive(true);
        coletavelTuboSaidaDto.RigidBodyColetavel.gravityScale = gravidade;
        coletavelTuboSaidaDto.RigidBodyColetavel.AddTorque(torque);
        coletavelTuboSaidaDto.SprRendererColetavel.sprite = spriteAtual;
        coletavelTuboSaidaDto.GoTrail.SetActive(true);
        coletavelTuboSaidaDto.RigidBodyTrail.gravityScale = gravidade;
        coletavelTuboSaidaDto.ParticulasTrail.Play();
    }

    public void restaurarParaProximoDescarte(Vector3 posicaoOriginal)
    {
        float zero = 0f;
        coletavelTuboSaidaDto.RigidBodyColetavel.gameObject.SetActive(false);
        coletavelTuboSaidaDto.RigidBodyColetavel.gravityScale = zero;
        coletavelTuboSaidaDto.RigidBodyColetavel.angularVelocity = zero;
        coletavelTuboSaidaDto.RigidBodyColetavel.velocity = Vector2.zero;
        coletavelTuboSaidaDto.TransformColetavel.position = posicaoOriginal;

        coletavelTuboSaidaDto.RigidBodyTrail.gravityScale = zero;
        coletavelTuboSaidaDto.RigidBodyTrail.angularVelocity = zero;
        coletavelTuboSaidaDto.RigidBodyTrail.velocity = Vector2.zero;
        coletavelTuboSaidaDto.ParticulasTrail.Stop();
        coletavelTuboSaidaDto.GoTrail.SetActive(false);
        coletavelTuboSaidaDto.TransformTrail.position = posicaoOriginal;
    }
}
