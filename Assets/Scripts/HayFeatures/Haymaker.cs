using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Haymaker : MonoBehaviour
{
    private HayService _hayService;

    private void Start()
    {
        _hayService = ServiceLocator.Instance.GetService<HayService>();
        _hayService.SelectCurrent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Haymaking();
        }
    }

    private void Haymaking()
    {
        var colliders = Physics.OverlapSphere(transform.position, _hayService.CurrentHayItem.GetRadius());
        var hays = new List<KeyValuePair<float, Hay>>();

        foreach(var collider in colliders)
        {
            if(collider.TryGetComponent(out Hay hay))
            {
                if (hay.Performed)
                {
                    continue;
                }

                var distance = Vector3.Distance(transform.position, hay.transform.position);
                hays.Add(new KeyValuePair<float, Hay>(distance, hay));
            }
        }

        if(_hayService.CurrentHayItem == null)
        {
            Debug.Log("hay item not inited");
            return;
        }

        _hayService.CurrentHayItem.Cut(hays
            .OrderBy(x => x.Key)
            .Select(x => x.Value)
            .ToArray());
    }
}
