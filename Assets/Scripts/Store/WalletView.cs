using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletView : MonoBehaviour
{
    private WalletService _walletService;
    [SerializeField]
    private Text _moneyText;
    void Start()
    {
        _walletService = ServiceLocator.Instance.GetService<WalletService>();
    }

    // Update is called once per frame
    void Update()
    {
        _moneyText.text = _walletService.GetMoney().ToString();
    }
}
