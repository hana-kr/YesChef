using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KitchenObject", menuName = "Kitchen/Chopped ingredients", order = 1)]

public class ChoopedIngredientSOList : ScriptableObject
{
    public List<ChoppedIngredient> choppedIngredients;
}
[Serializable]
public class ChoppedIngredient
{
    public IngredientType ingredientType;
    public GameObject ingredientChopped;
    public float choppingProgress;
}
