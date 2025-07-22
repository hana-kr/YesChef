using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] IngredientType ingredientType;
    private IKitchenObjectParent KitchenObjectparent;


    public IngredientType IngredientType => ingredientType;
    public void SetKitchenObjectParent(IKitchenObjectParent iKitchenObjectparent)
    {
        if (this.KitchenObjectparent != null)
        {
            this.KitchenObjectparent.ClearKitchenObject();
        }
        this.KitchenObjectparent = iKitchenObjectparent;
        iKitchenObjectparent.SetKitchenObject(this);

        transform.parent = iKitchenObjectparent.GetCounterTop();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent GetClearCounter()
    {
        return KitchenObjectparent;
    }
    public void DestroySelf()
    {
        KitchenObjectparent.ClearKitchenObject();
        Destroy(gameObject);
    }
}
