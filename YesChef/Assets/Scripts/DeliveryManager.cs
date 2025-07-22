using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private KitchenObjSoList kitchenObjSoList;
    [SerializeField] private RecipeSoList recipes;
    [SerializeField] private OrderUI orderUI;
    [SerializeField] private float respawnDelay = 5f;

    private List<RecipeSo> currentOrder;
    private Dictionary<IngredientType, RecipeType> mapping;

    private int runningTotalScore = 0;
    private int orderIngredientScoreTotal = 0;
    private float orderStartTime;

    private Coroutine countdownRoutine;

    private void Awake()
    {
        mapping = new()
        {
            { IngredientType.Cheese,         RecipeType.Cheese },
            { IngredientType.CoockedMeat,    RecipeType.CoockedMeat },
            { IngredientType.ChoppedTomato,  RecipeType.ChoppedTomato }
        };

        SpawnNewOrder();
    }

    public bool DeliverRecipe(KitchenObject kitchenObject)
    {
        if (currentOrder == null || currentOrder.Count == 0)
            return false;

        if (!mapping.TryGetValue(kitchenObject.IngredientType, out RecipeType mappedType))
        {
            Debug.LogWarning("IngredientType not found in mapping");
            return false;
        }

        int index = currentOrder.FindIndex(r => r.recipeType == mappedType);
        if (index == -1)
        {
            return false;
        }

        currentOrder.RemoveAt(index);
        kitchenObject.DestroySelf();
        orderIngredientScoreTotal += recipes.recipeSos.First(r => r.recipeType == mappedType).scoreValue;

        orderUI.UpdateOrder(currentOrder);

        if (currentOrder.Count == 0)
        {
            int orderScore = CalculateScore();
            runningTotalScore += orderScore;
            orderUI.ClearOrder();

            StartCoroutine(RespawnOrderAfterDelay());
        }

        return true;
    }

    private void SpawnNewOrder()
    {
        currentOrder = OrderMaker.CreateRandomOrder(recipes);

        orderStartTime = Time.time;
        orderIngredientScoreTotal = 0;

        orderUI.ShowOrder(currentOrder);

        if (countdownRoutine != null) StopCoroutine(countdownRoutine);
        countdownRoutine = StartCoroutine(OrderCountDown());
    }

    private IEnumerator RespawnOrderAfterDelay()
    {
        orderUI.ShowScore(orderIngredientScoreTotal);
        yield return new WaitForSeconds(respawnDelay);
        SpawnNewOrder();
    }

    private IEnumerator OrderCountDown()
    {
        while (currentOrder != null && currentOrder.Count > 0)
        {
            float elapsed = Time.time - orderStartTime;
            orderUI.UpdateTimer(Mathf.FloorToInt(elapsed));
            yield return new WaitForSeconds(1f);
        }
    }

    private int CalculateScore()
    {
        int elapsedSeconds = Mathf.FloorToInt(Time.time - orderStartTime);
        return orderIngredientScoreTotal - elapsedSeconds;
    }
}
