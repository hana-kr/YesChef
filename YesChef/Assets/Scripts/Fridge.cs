using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : BaseCounter
{
    [SerializeField] private KitchenObjSoList kitchenObjSo;
    [SerializeField] private GameObject menu;


    public override void Interact(Player player)
    {
        menu.SetActive(true);
        Debug.Log("fridge interaction");

        ChooseItemFridge chooseItemFridge = menu.GetComponent<ChooseItemFridge>();
        chooseItemFridge.OnChooseIngredient += HandleChooseIngredient;

        void HandleChooseIngredient(object sender, IngredientChosenEventArgs e)
        {
            GetTheIngredient(player, e.ingredientType);
            menu.SetActive(false);
            chooseItemFridge.OnChooseIngredient -= HandleChooseIngredient;
        }
    }
    public void GetTheIngredient(Player player, IngredientType ingredientType)
    {
        if (player.GetKitchenObject() == null)
        {
            KitchenObjSo tomatoSO = kitchenObjSo.kitchenObjSos.Find(obj => obj.objType == ingredientType);
            GameObject obj = Instantiate(tomatoSO.prefab);
            kitchenObject = obj.GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(player);
        }
        else
        {
            Debug.Log("has something in hand");
        }
    }

}
