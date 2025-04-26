using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletService : IService
{
    private int _moneyCount = 1000;

    public WalletService() 
    { 
        
    }
    public void AddMoney(int sum)
    {
        _moneyCount += sum;
        Debug.Log($"Added sum {sum}");
    }

    public void SpendMoney(int sum)
    {
        _moneyCount -= sum;
        Debug.Log($"Spend sum {sum}");
    }

    public int GetMoney()
    {
        return _moneyCount;
    }

}
