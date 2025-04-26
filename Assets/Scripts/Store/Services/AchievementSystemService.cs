using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystemService : IService
{
    private readonly WalletService _walletService;
       
    public AchievementSystemService(WalletService walletService)
    {
        _walletService = walletService;
    }


    public void CheckCondition()
    { 
        
    }
}
