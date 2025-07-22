using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjSoList kitchenObjSo;
    [SerializeField] private ChoopedIngredientSOList choopedIngredientSOList;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);

            }
        }
    }
    public override void InteractAlter(Player player)
    {
        if (HasKitchenObject())
        {

            ChoppedIngredient ingredient = choopedIngredientSOList.choppedIngredients.Find(obj => obj.ingredientType == GetKitchenObject().IngredientType);
            if (ingredient != null)
            {
                GetKitchenObject().DestroySelf();
                GameObject obj = Instantiate(ingredient.ingredientChopped);
                kitchenObject = obj.GetComponent<KitchenObject>();
                kitchenObject.SetKitchenObjectParent(this);
            }
            else
            {
                Debug.Log("ingredient is not choppable");
            }
        }
    }
}
