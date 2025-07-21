using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] IngredientType ingredientType;
    private IKitchenObjectParent iKitchenObjectparent;


    public IngredientType IngredientType => ingredientType;
    public void SetKitchenObjectParent(IKitchenObjectParent iKitchenObjectparent)
    {
        if (this.iKitchenObjectparent != null)
        {
            this.iKitchenObjectparent.ClearKitchenObject();
        }
        this.iKitchenObjectparent = iKitchenObjectparent;
        iKitchenObjectparent.SetKitchenObject(this);

        transform.parent = iKitchenObjectparent.GetCounterTop();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent GetClearCounter()
    {
        return iKitchenObjectparent;

    }
}
