using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeSO", menuName = "Kitchen/Recipies", order = 1)]


public class RecipeSoList : ScriptableObject
{
    public List<RecipeSo> recipeSos;
}
[Serializable]
public class RecipeSo
{
    public RecipeType recipeType;
    public int scoreValue;
    public Sprite image;

}
public enum RecipeType
{
    CoockedMeat,
    ChoppedTomato,
    Cheese,
}
