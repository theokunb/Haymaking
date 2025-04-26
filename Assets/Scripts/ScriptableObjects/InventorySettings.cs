using UnityEngine;

[CreateAssetMenu(fileName = "InventoryConfig", menuName ="Confings/New inventory config", order = 51)]
public class InventorySettings : ScriptableObject
{
    [SerializeField] private int _scytheIndex = 0;
    [SerializeField] private int _rakeIndex = 1;
    [SerializeField] private int _pitchforksIndex = 2;

    public int ScytheIndex => _scytheIndex;
    public int RakeIndex => _rakeIndex;
    public int PitchforksIndex => _pitchforksIndex;
}
