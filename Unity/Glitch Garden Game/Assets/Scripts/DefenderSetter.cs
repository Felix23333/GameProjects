using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSetter : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    // Start is called before the first frame update
    void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defemders");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetSelectDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }
    private void OnMouseDown()
    {
        TryToPlaceDefender(GetSquareClicked());
    }

    private Vector2 SnapToGrid(Vector2 floatWorldPos)
    {
        float intX = Mathf.RoundToInt(floatWorldPos.x);
        float intY = Mathf.RoundToInt(floatWorldPos.y);
        return new Vector2(intX, intY);
    }

    private void TryToPlaceDefender(Vector2 defenderPos)
    {
        var resourceDisplay = FindObjectOfType<ResourceDisplay>();
        if (defender == null)
        {
            return;
        }
        int resourceCost = defender.GetResourceCost();
        if (resourceCost <= resourceDisplay.GetCurrentResource())
        {
            resourceDisplay.UseResouces(resourceCost);
            SetDefender(defenderPos);
        }
        else
        {
            return;
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private void SetDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
        //Debug.Log(worldPos);
    }
}
