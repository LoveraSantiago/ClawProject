using UnityEngine;

public class GaiolaContexto : GOContexto
{
    public int contadorDesligados { get; private set; }
    public Nomeador nomeador { get; private set; }

    public GaiolaContexto(GameObject goMainGaiola) 
        : base(goMainGaiola)
    {
        contadorDesligados = 0;
        nomeador = new Nomeador();
    }

    public void adicionarDesligado()
    {
        contadorDesligados++;
    }
}
