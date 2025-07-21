using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] IngredientType ingredientType;
    private ClearCounter clearCounter;


    public IngredientType IngredientType => ingredientType;
    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }
        this.clearCounter = clearCounter;
        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetCounterTop();
        transform.localPosition = Vector3.zero;
    }
    public ClearCounter GetClearCounter()
    {
        return clearCounter;

    }
}
