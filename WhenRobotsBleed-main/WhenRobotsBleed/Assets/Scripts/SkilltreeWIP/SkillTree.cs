using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    [SerializeField] private int numSkills = 5;
    [SerializeField] private GameObject skillPrefab;
    [SerializeField] private float skillSpacing = 2f;

    void Start()
    {
        // Create the skills
        for (int i = 0; i < numSkills; i++)
        {
            GameObject skill = Instantiate(skillPrefab, transform);
            skill.transform.localPosition = new Vector3(i * skillSpacing, 0, 0);
            skill.GetComponent<Skill>().id = i;
            // Customize the skill here
        }

        // Connect the skills with lines
        for (int i = 0; i < numSkills - 1; i++)
        {
            Skill skill1 = transform.GetChild(i).GetComponent<Skill>();
            Skill skill2 = transform.GetChild(i + 1).GetComponent<Skill>();
            skill1.Connect(skill2);
        }
    }
}