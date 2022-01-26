using System;

public interface ContadorDeTempo 
{
    void iniciarContagem();
    TimeSpan processarContagem();
    void pause();
    void continuar();
    bool isTimeOver();
    bool isNearTimeOver();
}

