using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    public GameObject root;
    public Image fillImage;

    public void Show()
    {
        root.SetActive(true);
        SetProgress(0f);
    }

    public void Hide()
    {
        SetProgress(0f);
        root.SetActive(false);
    }

    public void SetProgress(float value)
    {
        fillImage.fillAmount = Mathf.Clamp01(value);
    }
}
