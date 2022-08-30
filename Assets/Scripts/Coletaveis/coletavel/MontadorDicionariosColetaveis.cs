using System.Collections.Generic;

public class MontadorDicionariosColetaveis
{
    public Dictionary<int, ColetavelEntidade> dicionarioDeIds { get; private set; }
    public Dictionary<string, ColetavelEntidade> dicionarioDeSprites { get; private set; }
    public Dictionary<MapaEnum, List<ColetavelEntidade>> dicionarioDeFamilias { get; private set; }

    public MontadorDicionariosColetaveis()
    {
        dicionarioDeIds      = new Dictionary<int, ColetavelEntidade>();
        dicionarioDeSprites  = new Dictionary<string, ColetavelEntidade>();
        dicionarioDeFamilias = new Dictionary<MapaEnum, List<ColetavelEntidade>>();
    }

    public void montarDicionariosDeColetaveis()
    {
        popularDicionarios();
    }

    private void popularDicionarios()
    {
        ColetavelEntidade[] coletaveisEntidades = ColetavelEntidade.getColetaveisEntidades();
        for (int contador = 0; contador < coletaveisEntidades.Length; contador++)
        {
            ColetavelEntidade coletavelEntidadeIt = coletaveisEntidades[contador];

            dicionarioDeIds.Add(coletavelEntidadeIt.id, coletavelEntidadeIt);
            dicionarioDeSprites.Add(coletavelEntidadeIt.nomeSprite, coletavelEntidadeIt);
            addAoDicionarioDeFamilias(coletavelEntidadeIt);
        }
    }

    private void addAoDicionarioDeFamilias(ColetavelEntidade coletavelEntidadeIt)
    {
        if (!dicionarioDeFamilias.ContainsKey(coletavelEntidadeIt.mapaEnum))
        {
            dicionarioDeFamilias.Add(coletavelEntidadeIt.mapaEnum, new List<ColetavelEntidade>());
        }

        List<ColetavelEntidade> lista = dicionarioDeFamilias[coletavelEntidadeIt.mapaEnum];
        lista.Add(coletavelEntidadeIt);
    }
}
