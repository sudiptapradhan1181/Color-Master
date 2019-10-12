using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fingerselector : MonoBehaviour
{
    
    public static int data;
    public static int lowerLimit;
    public static int higherLimit;

    public Dropdown dropdown;
    public InputField lowerLimitText;
    public InputField higherLimitText;

    public void Dropdown_IndexChange(int index)
    {
        if (index == 1)
        {
            data = Jump.angles[1];
            return;
        }

        else if (index == 2)
        {
            data = Jump.angles[3];
            return;
        }

        else if (index == 3)
        {
            data = Jump.angles[5];
            return;
        }

        else if (index == 4)
        {
            data = Jump.angles[7];
            return;
        }

        else if (index == 5)
        {
            data = Jump.angles[9];
            return;
        }
    }

    public void lowerLimitSet()
    {
        lowerLimit = int.Parse(lowerLimitText.text);
    }

    public void higherLimitSet()
    {
        higherLimit = int.Parse(higherLimitText.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Populate();
    }

    public void Populate()
    {
        // drop.AddOptions(values);
    }


}
