using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuracoNegroPowerUpGo : PowerUpNaoInteracaoComGarra
{
    public BuracoNegroPowerUpGo() : 
        base(powerUpDto.BuracoNegroDto.BuracoNegroGo, "Buraco Negro"){}

    public override void configurarPup()
    {
        
    }

    public override void iniciarPup()
    {
        ligar();
    }

    public override void resetPup()
    {
        
    }
}
