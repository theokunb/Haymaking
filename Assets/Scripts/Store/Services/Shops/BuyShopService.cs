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
                hayItem = new Scythe() // 2 ������� ����
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
                description = "���� 2 ������",
            },
            new Product
            {
                hayItem = new Rake() // 2 ������� ������
                {
                    Radius = 15,
                    GrabCount = 9,
                    Speed = 1,
                    AudioClip = config.Rake
                },
                price = 200,
                type = 1,
                productIcon = Resources.Load<Sprite>("rake lvl 2"),
                description = "������ 2 ������",
            },
            new Product
            {
                hayItem = new Pitchforks() // 2 ������� ���
                {
                    Radius = 5,
                    Speed = 15,
                    AudioClip = config.Pitchforks
                },
                price = 200,
                type = 2,
                productIcon = Resources.Load<Sprite>("pike lvl 2"),
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
            hayService.SelectItem(product.type);
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