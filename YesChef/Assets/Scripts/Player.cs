using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] PlayerInput playerInput;
    private Vector3 lastInteractDir;
    void OnEnable()
    {
        playerInput.OnPressE += DetectInteraction;
    }

    void Update()
    {
        Move();

    }

    private void DetectInteraction(object sender, EventArgs e)
    {

        float interactDistance = 2f;
        Vector3 rayOrigin = transform.position + Vector3.up * -0.2f;
        Debug.DrawRay(rayOrigin, lastInteractDir * interactDistance, Color.red);
        if (Physics.Raycast(rayOrigin, lastInteractDir, out RaycastHit hit, interactDistance))
        {
            if (hit.transform.TryGetComponent<ClearCounter>(out var clearCounter))
            {
                clearCounter.Interact();
            }
            else
            {
                Debug.Log("Hit something but no ClearCounter");
            }
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

}
