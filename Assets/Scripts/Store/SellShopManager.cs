using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellShopManager : MonoBehaviour
{
    [SerializeField]
    private Transform productsPanel;

    private SellShopService _sellShopManager;
    private HeapOnPitchfork _heapOnPitchfork;

    private Transform player;
    private Transform shop;

    [SerializeField]
    private float minDistanceForOpenShop = 2;
    [SerializeField]
    private Text countHayHeapText, priceText;

    void Start()
    {
        _sellShopManager = ServiceLocator.Instance.GetService<SellShopService>();
        _heapOnPitchfork = ServiceLocator.Instance.GetService<HeapOnPitchfork>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shop = GameObject.FindGameObjectWithTag("Shop").transform;

        priceText.text = _sellShopManager.GetPriceOfOnePiece().ToString();
    }

    void Update()
    {
        var distancePlayerAndShop = Vector3.Distance(player.position, shop.position);

        if (distancePlayerAndShop <= minDistanceForOpenShop && Input.GetKeyDown(KeyCode.H))
        {
            productsPanel.gameObject.active = !productsPanel.gameObject.active;
        }

        if (distancePlayerAndShop > minDistanceForOpenShop)
        {
            productsPanel.gameObject.active = false;
        }


        countHayHeapText.text = $"Сено x{_heapOnPitchfork.GetAccumulatedHeap()}";
    }

    public void SellHayHeap()
    {
        _sellShopManager.SellSay();
    }
}
