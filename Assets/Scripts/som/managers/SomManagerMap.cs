public class SomManagerMap : SomManager,
                             SomMap
{
    private AudioMapDto audioDto;

    public SomManagerMap(AudioMapDto audioDto) 
        : base(audioDto)
    {
        this.audioDto = audioDto;
    }

    public void playSomCliqueBalao()
    {
        audioPlayOneShot(getAudioSourceUi(), audioDto.CliqueSomBalao);
    }

    public void playSomCliqueSetas()
    {
        audioPlayOneShot(getAudioSourceUi(), audioDto.CliqueSomSetas);
    }

    public void playSomUiBaloesLevel()
    {
        audioPlayOneShot(getAudioSourceUi(), audioDto.BumpBaloesLevels);
    }
}
