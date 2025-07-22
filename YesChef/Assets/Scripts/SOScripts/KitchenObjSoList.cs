using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "KitchenObject", menuName = "Kitchen/Kitchen Object", order = 1)]
public class KitchenObjSoList : ScriptableObject
{
    public List<KitchenObjSo> kitchenObjSos;
}

[Serializable]
public class KitchenObjSo
{
    public GameObject prefab;
    public Sprite sprite;
    public IngredientType objType;
}
public enum IngredientType
{
    Cheese,
    Meat,
    Tomato,
    CoockedMeat,
    ChoppedTomato,
}

