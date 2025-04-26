using UnityEngine;

public class Inventory : MonoBehaviour
{
    private HayService _hayService;

    private void Start()
    {
        _hayService = ServiceLocator.Instance.GetService<HayService>();

        Debug.Log("switch to scythe");
        _hayService.SelectItem(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("switch to scythe");
            _hayService.SelectItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("switch to rake");
            _hayService.SelectItem(1);
        }
    }
}
