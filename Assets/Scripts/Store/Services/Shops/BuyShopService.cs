using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShopService : IService
{
    public List<Product> products { get; set; }
    public readonly WalletService _walletService;
    public BuyShopService()
    {
        products = new List<Product>
        {
            new Product
            {
                hayItem = new Scythe() // 2 ������� ����
                {
                    CutRadius = 15,
                    CutHaysCount = 2,
                    Speed = 1,
                    Damage = 2
                },
                price = 100,
                type = 1,
                productIcon = Resources.Load<Sprite>("reaper lvl 2"),
                description = "���� 2 ������",
            },
            new Product
            {
                hayItem = new Scythe() // 2 ������� ����
                {
                    CutRadius = 15,
                    CutHaysCount = 2,
                    Speed = 1,
                    Damage = 2
                },
                price = 100,
                type = 1,
                productIcon = Resources.Load<Sprite>("reaper lvl 2"),
                description = "���� 2 ������",
            }
        };
    }

    public void BuyProduct(int index)
    {
        var wallet = ServiceLocator.Instance.GetService<WalletService>();
        var hayService = ServiceLocator.Instance.GetService<HayService>();
        var product = products[index];

        if (wallet.GetMoney() >= product.price)
        {
            wallet.SpendMoney(product.price);
            hayService.SetHayItem(product.type, product.hayItem);
            Debug.Log($"���� 2 ������ ������");
        }
        else
        {
            Debug.Log($"��� ������� ���� 2 ������ �� ������� �����");
        }
    }

}

public class Product
{
    public IHayItem hayItem;
    public int price;
    public int type; // 1 - ����, 2 - ������ 3 - ����
    public Sprite productIcon;
    public string description;
}