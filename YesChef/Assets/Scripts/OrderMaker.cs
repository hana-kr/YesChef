using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OrderMaker
{
    public static List<RecipeSo> CreateRandomOrder(RecipeSoList recipes)
    {
        int ingredientCount = Random.value < 0.5f ? 2 : 3;

        List<RecipeSo> selectedIngredients = new List<RecipeSo>();

        for (int i = 0; i < ingredientCount; i++)
        {
            int randomIndex = Random.Range(0, recipes.recipeSos.Count);
            selectedIngredients.Add(recipes.recipeSos[randomIndex]);
        }
        return selectedIngredients;
    }
}
