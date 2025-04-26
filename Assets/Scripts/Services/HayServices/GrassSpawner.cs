using UnityEngine;

public class GrassSpawner : MonoBehaviour, IService
{
    [SerializeField] private GameObject hayPrefab;

    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private float _offset;

    private void Start()
    {
        float currentOffset = _offset;
        float multipluier;
        for (float i = _point1.position.x; i <= _point2.position.x; i += currentOffset)
        {
            for (float j = _point1.position.z; j <= _point2.position.z; j += currentOffset)
            {
                Instantiate(hayPrefab, new Vector3(i, 0, j), Quaternion.identity);
                multipluier = Random.Range(0.2f, 1.5f);
                currentOffset = _offset * multipluier;
            }
        }
    }
}
