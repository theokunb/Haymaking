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
            _heapOnPitchfork.SellSay();
            var earnedMoney = _heapOnPitchfork.GetAccumulatedHeap() * priceOfOnePiece;
            _walletService.AddMoney(earnedMoney);
            Debug.Log($"SellShopService - ���������� {earnedMoney}");
            return true;
        }

        return false;
    }

}
