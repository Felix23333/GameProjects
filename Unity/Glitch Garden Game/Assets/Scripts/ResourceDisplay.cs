using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] int resources = 100;
    Text resourceText;
    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<Text>();
        UpdateResouces();
    }

    private void UpdateResouces()
    {
        resourceText.text = resources.ToString();
    }

    public void AddResources(int resoucesToAdd)
    {
        resources += resoucesToAdd;
        UpdateResouces();
    }

    public void UseResouces(int resouceToUse)
    {
        if(resources >= resouceToUse)
        {
            resources -= resouceToUse;
        }
        UpdateResouces();
    }
}
