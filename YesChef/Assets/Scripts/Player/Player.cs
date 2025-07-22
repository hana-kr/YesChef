using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] private Transform holdPoint;

    private KitchenObject kitchenObject;
    private BaseCounter kitchenCounter;
    private Vector3 lastInteractDir;
    void OnEnable()
    {
        playerInput.OnPressE += DetectInteraction;
        playerInput.OnPressF += DetectInteractAlter;
    }

    void Update()
    {
        Move();
        DetectCounter();

    }
    private void DetectInteractAlter(object sender, EventArgs e)
    {
         if (kitchenCounter != null)
            StartCoroutine(kitchenCounter.InteractAlterCoroutine(this));
    }


    private void DetectInteraction(object sender, EventArgs e)
    {
        if (kitchenCounter != null)
            kitchenCounter.Interact(this);
    }
    private void DetectCounter()
    {
        float interactDistance = 2f;
        Vector3 rayOrigin = transform.position + Vector3.up * -0.2f;
        Debug.DrawRay(rayOrigin, lastInteractDir * interactDistance, Color.red);
        if (Physics.Raycast(rayOrigin, lastInteractDir, out RaycastHit hit, interactDistance))
        {
            if (hit.transform.TryGetComponent<BaseCounter>(out var baseCounter))
            {
                kitchenCounter = baseCounter;
            }
            else
            {
                Debug.Log("Hit something but no ClearCounter");
            }
        }
        else
        {
            kitchenCounter = null;
        }
    }
    void Move()
    {
        Vector2 input = playerInput.GetMovmentVector();
        Vector3 movment = new Vector3(input.x, 0f, input.y);
        if (movment != Vector3.zero)
        {
            lastInteractDir = movment;
        }
        transform.position += movment * Time.deltaTime * moveSpeed;
        if (input != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movment);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

        }
    }

   public Transform GetCounterTop()
    {
        return holdPoint;
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
