using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjSoList kitchenObjSo;
    [SerializeField] private Transform counterTop;

    private KitchenObject kitchenObject;
    public void Interact()
    {
        if (kitchenObject == null)
        {
            Debug.Log("clear couonter");
            KitchenObjSo tomatoSO = kitchenObjSo.kitchenObjSos.Find(obj => obj.objType == IngredientType.Tomato);

            GameObject obj = Instantiate(tomatoSO.prefab, counterTop);
            kitchenObject = obj.GetComponent<KitchenObject>();
            kitchenObject.SetClearCounter(this);
        }
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
        }
    }
    public Transform GetCounterTop()
    {
        return counterTop;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
