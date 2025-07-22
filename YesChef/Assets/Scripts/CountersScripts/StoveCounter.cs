using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private KitchenObjSoList kitchenObjSo;
    [SerializeField] private FryingObjectSOList fryingObjectSOList;
    [SerializeField] private ChopProgressBar chopUI;

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
    public override IEnumerator InteractAlterCoroutine(Player player)
{
    if (HasKitchenObject())
    {
        FryingObject ingredient = fryingObjectSOList.FriedIngredients
            .Find(obj => obj.ingredientType == GetKitchenObject().IngredientType);

        if (ingredient != null)
        {
            chopUI.Show();

            float duration = ingredient.fryingProgress;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                chopUI.SetProgress(elapsed / duration);
                yield return null;
            }

            chopUI.Hide();

            GetKitchenObject().DestroySelf();
            GameObject obj = Instantiate(ingredient.ingredientFried);
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
