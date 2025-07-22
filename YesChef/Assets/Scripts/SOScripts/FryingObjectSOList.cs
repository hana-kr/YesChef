
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KitchenObject", menuName = "Kitchen/Frying ingredients", order = 1)]

public class FryingObjectSOList : ScriptableObject
{
    public List<FryingObject> FriedIngredients;
}
[Serializable]
public class FryingObject
{
    public IngredientType ingredientType;
    public GameObject ingredientFried;
    public float fryingProgress;
}
