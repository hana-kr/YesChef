using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private Image recipeImage;
    [SerializeField] private TextMeshProUGUI recipeName;

    public void SetUp(Sprite image, string name)
    {
        recipeImage.sprite = image;
        recipeName.text = name;
    }
}
