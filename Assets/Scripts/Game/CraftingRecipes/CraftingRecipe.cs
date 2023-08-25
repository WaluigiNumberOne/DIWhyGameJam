using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CraftingRecipe : MonoBehaviour
{
    public Object craftableObj;

    public string name;
    public string description;
    public List<Vector2> components; //type, quantity

    public string getComponentsAsString()
    {
        bool firstPass = true;
        string returnString = "Need: ";
        foreach(Vector2 v in components)
        {

            if (firstPass)
            {
                firstPass = false;
            }
            else
            {
                returnString += ", ";
            }

            returnString += v.y.ToString() + "x "; // append quantity
            switch(v.x)
            {
                case 0:
                    returnString += "Duct Tape";
                    break;
                case 1:
                    returnString += "Scrap Metal";
                    break;
                case 2:
                    returnString += "Copper Wire";
                    break;
                case 3:
                    returnString += "Spring";
                    break;
                case 4:
                    returnString += "Battery";
                    break;
                default:
                    break;
            }
        }

        return returnString;
    }

}
