using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellShopService : IService
{
    private readonly WalletService _walletService;
    private readonly HeapOnPitchfork _heapOnPitchfork;


    private readonly int priceOfOnePiece = 50;

    public SellShopService(WalletService walletService, HeapOnPitchfork heapOnPitchfork)
    {
        _walletService = walletService;
        _heapOnPitchfork = heapOnPitchfork;
    }


    public bool SellSay()
    {

        if (_heapOnPitchfork.GetAccumulatedHeap() > 0)
        {
            var earnedMoney = _heapOnPitchfork.GetAccumulatedHeap() * priceOfOnePiece;
            _heapOnPitchfork.SellSay();
            _walletService.AddMoney(earnedMoney);
            Debug.Log($"SellShopService - заработано {earnedMoney}");
            return true;
        }

        return false;
    }

    public int GetPriceOfOnePiece()
    {
        return priceOfOnePiece;
    }

}
