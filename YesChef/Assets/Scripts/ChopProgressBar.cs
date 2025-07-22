using UnityEngine;
using UnityEngine.UI;

public class ChopProgressBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void SetProgress(float progress)
    {
        fillImage.fillAmount = progress;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
