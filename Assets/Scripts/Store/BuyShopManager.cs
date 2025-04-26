using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyShopManager : MonoBehaviour
{
    private BuyShopService _buyShopService;
    [SerializeField]
    private GameObject productUIBlock;
    private Image iconProduct;
    private Text productText;
    private Text productPrice;

    [SerializeField]
    private Transform productsPanel;
    void Start()
    {
        _buyShopService = ServiceLocator.Instance.GetService<BuyShopService>();
        InitProducts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitProducts()
    {
        var index = 0;
        foreach (var product in _buyShopService.products)
        {
            GameObject productRow = Instantiate(productUIBlock, productsPanel);
            iconProduct = productRow.transform.Find("ProductIcon").GetComponent<Image>();
            iconProduct.sprite = product.productIcon;
            
            productText = productRow.transform.Find("Description").GetComponent<Text>();
            productText.text = product.description;

            var productButton = productRow.transform.Find("Button");
            var indexLocal = index;
            productButton.GetComponent<Button>().onClick.AddListener(() => OnClickButton(indexLocal));
            productPrice = productButton.GetComponentInChildren<Text>();
            productPrice.text = product.price.ToString();
            index++;
        }
    }

    public void OnClickButton(int index)
    {
        _buyShopService.BuyProduct(index);
    }
}
