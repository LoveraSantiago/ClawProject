using System;

public interface ContadorTimer 
{
    void iniciarContagem();
    TimeSpan processarContagem();
    bool isTimeOver();
    bool isNearTimeOver();
}
