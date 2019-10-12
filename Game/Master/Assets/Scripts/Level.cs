using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    // public List<string> values = new List<string>() { "Please select level", "10", "20", "30", "40", "50" };
    public static int highLimit;

    public Dropdown drop;

    public void Dropdown_LevelChange(int i)
    {
        if (i == 1)
        {
            highLimit = 10;
        }

        else if (i == 2)
        {
            highLimit = 20;
        }

        else if (i == 3)
        {
            highLimit = 30;
        }

        else if (i == 4)
        {
            highLimit = 40;
        }

        else if (i == 5)
        {
            highLimit = 50;
        }

        else if (i == 6)
        {
            highLimit = 60;
        }
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