using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Haymaker : MonoBehaviour, IService
{
    private HayService _hayService;

    private void Start()
    {
        _hayService = ServiceLocator.Instance.GetService<HayService>();
        ServiceLocator.Instance.Register(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Haymaking();
        }
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<Haymaker>();
    }

    private void Haymaking()
    {
        var hays = Physics.OverlapSphere(transform.position, _hayService.CurrentHayItem.GetRadius())
            .Select(x => x.GetComponent<Hay>())
            .Where(x => x!= null)
            .Where(x => x.HayStatus == _hayService.CurrentHayItem.GetTargetHasyStatus());
        var cuttingHays = new List<KeyValuePair<float, Hay>>();

        foreach(var element in hays)
        {
            var distance = Vector3.Distance(transform.position, element.transform.position);
            cuttingHays.Add(new KeyValuePair<float, Hay>(distance, element));
        }

        if(_hayService.CurrentHayItem == null)
        {
            Debug.Log("hay item not inited");
            return;
        }

        _hayService.CurrentHayItem.ProcessHays(cuttingHays
            .OrderBy(x => x.Key)
            .Select(x => x.Value)
            .ToArray());
    }
}
