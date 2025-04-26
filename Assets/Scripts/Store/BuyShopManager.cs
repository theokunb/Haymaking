using UnityEngine;
using UnityEngine.UI;

public class BuyShopManager : MonoBehaviour
{
    private BuyShopService _buyShopService;
    [SerializeField]
    private GameObject productUIBlock;

    [SerializeField]
    private Transform productsPanel;

    private Transform player;
    private Transform shop;

    [SerializeField]
    private float minDistanceForOpenShop = 2;

    void Start()
    {
        _buyShopService = ServiceLocator.Instance.GetService<BuyShopService>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shop = GameObject.FindGameObjectWithTag("Shop").transform;
        InitProducts();
    }

    // Update is called once per frame
    void Update()
    {
        var distancePlayerAndShop = Vector3.Distance(player.position, shop.position);

        if (distancePlayerAndShop <= minDistanceForOpenShop && Input.GetKeyDown(KeyCode.G))
        {
            productsPanel.gameObject.active = !productsPanel.gameObject.active;
        }

        if (distancePlayerAndShop > minDistanceForOpenShop)
        {
            productsPanel.gameObject.active = false;
        }
    }

    private void InitProducts()
    {
        var index = 0;
        foreach (var product in _buyShopService.products)
        {
            GameObject productRow = Instantiate(productUIBlock, productsPanel);
            var iconProduct = productRow.transform.Find("ProductIcon").GetComponent<Image>();
            iconProduct.sprite = product.productIcon;
            
            var productText = productRow.transform.Find("Description").GetComponent<Text>();
            productText.text = product.description;

            var priceText = productRow.transform.Find("PriceText").GetComponent<Text>();
            priceText.text = product.price.ToString();

            var productButton = productRow.transform.Find("Button");
            var indexLocal = index;
            productButton.GetComponent<Button>().onClick.AddListener(() => OnClickButton(indexLocal));
            index++;
        }
    }

    public void OnClickButton(int index)
    {
        _buyShopService.BuyProduct(index);
    }
}
