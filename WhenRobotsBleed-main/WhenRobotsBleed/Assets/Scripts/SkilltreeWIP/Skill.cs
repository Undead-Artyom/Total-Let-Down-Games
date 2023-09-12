using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public int id;
    public bool unlocked = false;
    public int maxLevel = 5;
    public int level = 0;
    public int upgradeCost = 10;
    public Text levelText;
    public Text upgradeCostText;

    [SerializeField] private GameObject linePrefab;
    [SerializeField] private float lineWidth = 0.1f;
    [SerializeField] private Color lineColor = Color.white;

    private LineRenderer lineRenderer;

    void Start()
    {
        // Create the line renderer
        GameObject line = Instantiate(linePrefab, transform);
        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material.color = lineColor;

        // Set the skill to locked by default
        SetLocked(true);

        // Update the level and upgrade cost text
        levelText.text = "Level " + level.ToString();
        upgradeCostText.text = "Upgrade: " + upgradeCost.ToString();
    }

    public void Connect(Skill other)
    {
        // Draw a line between this skill and another skill
        Vector3[] positions = { transform.position, other.transform.position };
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(positions);
    }

    public void Upgrade()
    {/*
        // Check if the skill can be upgraded
        if (unlocked && level < maxLevel && GameManager.instance.score >= upgradeCost)
        {
            // Deduct the upgrade cost from the points and increase the skill level
            GameManager.instance.score -= upgradeCost;
            level++;

            // Update the level and upgrade cost text
            levelText.text = "Level " + level.ToString();
            upgradeCostText.text = "Upgrade: " + upgradeCost.ToString();
        }*/
    }

    public void SetLocked(bool locked)
    {
        // Set the skill to locked or unlocked
        unlocked = !locked;

        // Disable or enable the skill's renderer and collider
        Renderer renderer = GetComponent<Renderer>();
        Collider2D collider = GetComponent<Collider2D>();
        renderer.enabled = unlocked;
        collider.enabled = unlocked;

        // Set the line renderer's color based on whether the skill is locked or unlocked
        lineRenderer.material.color = unlocked ? lineColor : Color.gray;
    }
}