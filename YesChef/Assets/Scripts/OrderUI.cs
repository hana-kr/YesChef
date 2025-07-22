using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private Transform ingredientContainer;
    [SerializeField] private GameObject ingredientIconPrefab;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private bool hideTimerWhenNoOrder = true;

    private readonly List<GameObject> _spawnedRecipes = new();

    private void Awake()
    {
        if (timerText != null && hideTimerWhenNoOrder)
            timerText.gameObject.SetActive(false);
    }

    public void ShowOrder(List<RecipeSo> order)
    {
        RefreshRecipe(order);
        if (timerText != null && hideTimerWhenNoOrder)
            timerText.gameObject.SetActive(true);
    }

    public void UpdateOrder(List<RecipeSo> order)
    {
        RefreshRecipe(order);
    }

    public void ClearOrder()
    {
        ClearRecipe();
        if (timerText != null && hideTimerWhenNoOrder)
        {
            timerText.text = string.Empty;
            timerText.gameObject.SetActive(false);
        }
    }

    public void UpdateTimer(int secondsElapsed)
    {
        if (timerText == null) return;
        timerText.text = secondsElapsed.ToString();
    }

    private void RefreshRecipe(List<RecipeSo> order)
    {
        ClearRecipe();

        if (order == null) return;

        foreach (var recipe in order)
        {
            var go = Instantiate(ingredientIconPrefab, ingredientContainer);
            _spawnedRecipes.Add(go);

            var recipeUI = go.GetComponentInChildren<RecipeUI>();
            if (recipeUI != null )
            {
                recipeUI.SetUp(recipe.image, recipe.recipeType.ToString());
            }
        }
    }

    private void ClearRecipe()
    {
        foreach (var recipe in _spawnedRecipes)
        {
            if (recipe != null)
                Destroy(recipe);
        }
        _spawnedRecipes.Clear();
    }


}

