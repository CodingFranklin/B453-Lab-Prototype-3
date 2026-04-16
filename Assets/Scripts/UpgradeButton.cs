using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private ResourceType costType;
    [SerializeField] private int costAmount = 1;
    [SerializeField] private float percentReduction = 0.01f;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(BuyUpgrade);
    }

    private void Update()
    {
        Resource costResource = ResourceManager.instance.GetResource(costType);
        button.interactable = costResource != null && costResource.amount >= costAmount;
    }

    private void BuyUpgrade()
    {
        Resource costResource = ResourceManager.instance.GetResource(costType);

        if (costResource == null) return;
        if (costResource.amount < costAmount) return;

        ResourceManager.instance.AddResource(costType, -costAmount);
        ResourceManager.instance.ApplyCollectSpeedUpgrade(percentReduction);
    }
}