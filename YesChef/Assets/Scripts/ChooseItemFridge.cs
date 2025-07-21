using UnityEngine;
using UnityEngine.UI;
using System;

public class ChooseItemFridge : MonoBehaviour
{
    [SerializeField] private Button tomatoButton;
    [SerializeField] private Button cheeseButton;
    [SerializeField] private Button meatButton;

    public event EventHandler<IngredientChosenEventArgs> OnChooseIngredient;

    private void Start()
    {
        tomatoButton.onClick.AddListener(() => Choose(IngredientType.Tomato));
        cheeseButton.onClick.AddListener(() => Choose(IngredientType.Cheese));
        meatButton.onClick.AddListener(() => Choose(IngredientType.Meat));
    }

    private void Choose(IngredientType type)
    {
        Debug.Log("Button clicked: " + type);
        OnChooseIngredient?.Invoke(this, new IngredientChosenEventArgs(type));
    }
}
public class IngredientChosenEventArgs : EventArgs
{
    public IngredientType ingredientType;

    public IngredientChosenEventArgs(IngredientType type)
    {
        ingredientType = type;
    }
}
