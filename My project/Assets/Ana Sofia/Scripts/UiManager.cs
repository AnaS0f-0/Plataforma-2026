using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Image _barra;
    

    public void SumarFillAmount(float amount)
    {
        _barra.fillAmount += amount;
        _barra.fillAmount = _barra.fillAmount + amount;
    }


    public void RestarFillAmount(float amount)
    {
        _barra.fillAmount = _barra.fillAmount - amount;
    }
}
