using UnityEngine;

public class Inventory : MonoBehaviour
{
    private HayService _hayService;
    private HeapOnPitchfork _heapOnPitchfork;
    private InventorySettings _inventorySettings;

    private void Start()
    {
        _hayService = ServiceLocator.Instance.GetService<HayService>();
        _heapOnPitchfork = ServiceLocator.Instance.GetService<HeapOnPitchfork>();
        _inventorySettings = Resources.Load<InventorySettings>("InventoryConfig");

        Debug.Log("switch to scythe");
        _hayService.SelectItem(_inventorySettings.ScytheIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _hayService.SelectItem(_inventorySettings.ScytheIndex);
            _heapOnPitchfork.DropHeap();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("switch to rake");
            _hayService.SelectItem(_inventorySettings.RakeIndex);
            _heapOnPitchfork.DropHeap();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("switch to pitchforks");
            _hayService.SelectItem(_inventorySettings.PitchforksIndex);
        }
    }
}
