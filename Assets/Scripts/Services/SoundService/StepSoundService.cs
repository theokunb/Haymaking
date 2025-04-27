using UnityEngine;

public class StepSoundService : IService
{
    public StepSoundService(params AudioClip[] stepSound)
    {
        StepSounds = stepSound;
    }

    public AudioClip[] StepSounds { get; private set; }
}
