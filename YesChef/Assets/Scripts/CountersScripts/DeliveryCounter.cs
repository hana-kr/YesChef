using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    [SerializeField] private KitchenObjSoList kitchenObjSo;
    [SerializeField] DeliveryManager deliveryManager;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
                deliveryManager.DeliverRecipe(GetKitchenObject());
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                Debug.Log("both slots full");
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);

            }
        }
    }

}
