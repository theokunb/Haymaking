using UnityEngine;

public class Inventory : MonoBehaviour
{
    private HayService _hayService;
    private HeapOnPitchfork _heapOnPitchfork;

    private void Start()
    {
        _hayService = ServiceLocator.Instance.GetService<HayService>();
        _heapOnPitchfork = ServiceLocator.Instance.GetService<HeapOnPitchfork>();

        Debug.Log("switch to scythe");
        _hayService.SelectItem(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("switch to scythe");
            _hayService.SelectItem(0);
            _heapOnPitchfork.DropHeap();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("switch to rake");
            _hayService.SelectItem(1);
            _heapOnPitchfork.DropHeap();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("switch to pitchforks");
            _hayService.SelectItem(2);
        }
    }
}
