using UnityEngine;

[CreateAssetMenu(fileName = "InventoryConfig", menuName ="Confings/New inventory config", order = 51)]
public class InventorySettings : ScriptableObject
{
    [SerializeField] private int _scytheIndex = 0;
    [SerializeField] private int _rakeIndex = 1;
    [SerializeField] private int _pitchforksIndex = 2;
    [SerializeField] private AudioClip _scythe;
    [SerializeField] private AudioClip _rake;
    [SerializeField] private AudioClip _pitchforks;
    [SerializeField] private AudioClip[] _steps;

    public int ScytheIndex => _scytheIndex;
    public int RakeIndex => _rakeIndex;
    public int PitchforksIndex => _pitchforksIndex;

    public AudioClip Scythe => _scythe;
    public AudioClip Rake => _rake;
    public AudioClip Pitchforks => _pitchforks;
    public AudioClip[] Steps => _steps;
}
