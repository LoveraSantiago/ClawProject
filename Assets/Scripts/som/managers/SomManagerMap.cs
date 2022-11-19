public class SomManagerMap : SomManager,
                             SomMap
{
    private AudioMapDto audioDto;

    public SomManagerMap(AudioMapDto audioDto) 
        : base(audioDto)
    {
        this.audioDto = audioDto;
    }

    public void playSomUiBaloesLevel()
    {
        audioPlayOneShot(getAudioSourceUi(), audioDto.BumpBaloesLevels);
    }
}
