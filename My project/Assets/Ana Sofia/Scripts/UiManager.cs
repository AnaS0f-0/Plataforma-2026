using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Image _barra;
    [SerializeField] private PlayerStats _invencibilidad;
   

    
    

    public void SumarFillAmount(float amount)
    {
        _barra.fillAmount += amount;
        _barra.fillAmount = _barra.fillAmount + amount;
    }


    public void RestarFillAmount(float amount)
    {

        if (_invencibilidad != null && !_invencibilidad._invencibilidad)
        {
            _barra.fillAmount = _barra.fillAmount - amount;
            return;
        }

        

       

      
    }


    

    
}
