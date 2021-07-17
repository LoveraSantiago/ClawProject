using System;

public interface TipoContadorTimer 
{
    void iniciarContagem();
    TimeSpan processarContagem();
    void pause();
    void continuar();
    bool isTimeOver();
    bool isNearTimeOver();
}
