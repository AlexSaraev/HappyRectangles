using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    // === COMPONENTS ===
    LineRenderer lineRenderer = null;
    SpriteRenderer spriteRenderer = null;

    // === DYNAMIC PROPERTIES ===
    GameObject currentConnectionTarget = null;

    // === LIFE CYCLE ===
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        SetLineColor();
    }

    void Update()
    {
        if (currentConnectionTarget != null)
            DrawLine();
        else
            RemoveLine();
    }

    // === PUBLIC METHODS ===
    public bool HasConnection(GameObject target) => target == currentConnectionTarget;
    
    public void DrawLine(GameObject target) => currentConnectionTarget = target;    
    
    public void RemoveLine()
    {
        lineRenderer.positionCount = 0;
        currentConnectionTarget = null;
    }

    // === PRIVATE METHODS ===
    void SetLineColor() => lineRenderer.material.color = spriteRenderer.color;

    void DrawLine()
    {
        if (currentConnectionTarget == null) return;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, currentConnectionTarget.transform.position);
    }
}
