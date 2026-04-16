using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [Header("Cost")]
    public ResourceType costType;
    public int costAmount;

    [Header("Reward")]
    public ResourceType rewardType;
    public int rewardAmount;

    [Header("Special")]
    public bool isUnlock = false;   // for unlock buttons

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    
    private void Update()
    {
        bool interactable = CanAfford();
        if (isUnlock)
        {
            interactable = !ResourceManager.instance.GetResource(rewardType).unlocked && CanAfford();
        }
        button.interactable = interactable;
    }

    private void OnClick()
    {
        if (!CanAfford())
        {
            Debug.Log("Not enough resource!");
            return;
        }

        // Spend
        ResourceManager.instance.AddResource(costType, -costAmount);

        // Reward
        if (isUnlock)
        {
            ResourceManager.instance.UnlockResource(rewardType);
        }
        else
        {
            ResourceManager.instance.AddResource(rewardType, rewardAmount);
        }
    }

    private bool CanAfford()
    {
        return ResourceManager.instance.GetResource(costType).amount >= costAmount;
    }
}