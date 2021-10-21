using UnityEngine;

public class AngulosPropriedades 
{
    public Quaternion angIdleMinEsquerda { get; private set; }
    public Quaternion angIdleMinDireita  { get; private set; }

    public Quaternion angIdleMaxEsquerda { get; private set; }
    public Quaternion angIdleMaxDireita  { get; private set; }

    public Quaternion angAberturaEsquerda { get; private set; }
    public Quaternion angAberturaDireita  { get; private set; }

    public Quaternion angFechamentoEsquerda { get; private set; }
    public Quaternion angFechamentoDireita  { get; private set; }

    public AngulosPropriedades(GarraAngulosDto angulosDto)
    {
        angIdleMinDireita  = Quaternion.Euler(0, 0, -angulosDto.IdleMin);
        angIdleMinEsquerda = Quaternion.Euler(0, 0, angulosDto.IdleMin);

        angIdleMaxDireita  = Quaternion.Euler(0, 0, -angulosDto.IdleMax);
        angIdleMaxEsquerda = Quaternion.Euler(0, 0, angulosDto.IdleMax);

        angAberturaDireita  = Quaternion.Euler(0, 0, -angulosDto.Abertura);
        angAberturaEsquerda = Quaternion.Euler(0, 0, angulosDto.Abertura);

        angFechamentoEsquerda = Quaternion.Euler(0, 0, -angulosDto.Fechamento);
        angFechamentoDireita  = Quaternion.Euler(0, 0, angulosDto.Fechamento);
    }
}
