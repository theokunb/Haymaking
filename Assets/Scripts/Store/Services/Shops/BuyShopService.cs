using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShopService : IService
{
    public List<Product> products { get; set; }
    public readonly WalletService _walletService;
    public BuyShopService()
    {
        var config = Resources.Load<InventorySettings>("InventoryConfig");

        products = new List<Product>
        {
            new Product
            {
                hayItem = new Scythe() // 2 уровень косы
                {
                    CutRadius = 15,
                    CutHaysCount = 2,
                    Speed = 1,
                    Damage = 2,
                    AudioClip = config.Scythe
                },
                price = 150,
                type = 0,
                productIcon = Resources.Load<Sprite>("reaper lvl 2"),
                description = "Коса 2 уровня",
            },
            new Product
            {
                hayItem = new Rake() // 2 уровень грабли
                {
                    Radius = 15,
                    GrabCount = 9,
                    Speed = 1,
                    AudioClip = config.Rake
                },
                price = 200,
                type = 1,
                productIcon = Resources.Load<Sprite>("rake lvl 2"),
                description = "Грабли 2 уровня",
            },
            new Product
            {
                hayItem = new Pitchforks() // 2 уровень вил
                {
                    Radius = 5,
                    Speed = 15,
                    AudioClip = config.Pitchforks
                },
                price = 200,
                type = 2,
                productIcon = Resources.Load<Sprite>("pike lvl 2"),
                description = "Вилы 2 уровня",
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
            hayService.SelectItem(product.type);
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