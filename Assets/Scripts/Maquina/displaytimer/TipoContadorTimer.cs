using System;

public interface TipoContadorTimer 
{
    void iniciarContagem();
    TimeSpan processarContagem();
    bool isTimeOver();
    bool isNearTimeOver();
}
