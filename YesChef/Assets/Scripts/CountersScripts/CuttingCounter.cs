using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjSoList kitchenObjSo;
    [SerializeField] private ChoopedIngredientSOList choopedIngredientSOList;
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
        ChoppedIngredient ingredient = choopedIngredientSOList.choppedIngredients
            .Find(obj => obj.ingredientType == GetKitchenObject().IngredientType);

        if (ingredient != null)
        {
            chopUI.Show();

            float duration = ingredient.choppingProgress;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                chopUI.SetProgress(elapsed / duration);
                yield return null;
            }

            chopUI.Hide();

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
