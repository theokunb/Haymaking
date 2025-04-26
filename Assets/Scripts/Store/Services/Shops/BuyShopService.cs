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
                hayItem = new Scythe() // 2 уровень косы
                {
                    CutRadius = 15,
                    CutHaysCount = 2,
                    Speed = 1,
                    Damage = 2
                },
                price = 100,
                type = 1,
                productIcon = Resources.Load<Sprite>("reaper lvl 2"),
                description = "Коса 2 уровня",
            },
            new Product
            {
                hayItem = new Scythe() // 2 уровень косы
                {
                    CutRadius = 15,
                    CutHaysCount = 2,
                    Speed = 1,
                    Damage = 2
                },
                price = 100,
                type = 1,
                productIcon = Resources.Load<Sprite>("reaper lvl 2"),
                description = "Коса 2 уровня",
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
            Debug.Log($"Коса 2 уровня продан");
        }
        else
        {
            Debug.Log($"Для покупки косы 2 уровня не хватает денег");
        }
    }

}

public class Product
{
    public IHayItem hayItem;
    public int price;
    public int type; // 1 - коса, 2 - грабли 3 - вилы
    public Sprite productIcon;
    public string description;
}