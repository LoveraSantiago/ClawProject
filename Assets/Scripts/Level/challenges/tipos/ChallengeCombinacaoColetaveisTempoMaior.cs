public class ChallengeCombinacaoColetaveisTempoMaior : ChallengeCombinacaoColetaveisTempoMenor
{
    public ChallengeCombinacaoColetaveisTempoMaior(
        AbstractLevel abstractLevel, int indice1, int indice2, int indice3, string tempoEstimado) : 
        base(abstractLevel, indice1, indice2, indice3, tempoEstimado)
    {
    }

    protected override string getMomentoDeTempo()
    {
        return "depois";
    }

    protected override bool validarTempo(double tempoEstimado, double timestamp)
    {
        return tempoEstimado > timestamp;
    }
}
