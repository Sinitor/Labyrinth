using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
   public void Gas()
    {
        Application.OpenURL("https://easypay.ua/ua/catalog/utility/utilitygas/naftogaz");
    }
    public void Water()
    {
        Application.OpenURL("https://easypay.ua/ua/catalog/utility/odessa/infoksvodokanal");
    }
    public void Light()
    {
        Application.OpenURL("https://easypay.ua/ua/catalog/utility/odessa/odesa-ec");
    }
    public void Heating()
    {
        Application.OpenURL("https://easypay.ua/ua/catalog/utility/odessa/teplopostachannia-odesa");
    }
}
