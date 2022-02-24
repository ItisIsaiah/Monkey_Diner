using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="FoodScriptableObject",menuName = "ScriptableObject/Food")]
public class Orders : ScriptableObject
{
    public string foodName;
    public bool cookable;

    //These need to be apart of the food always
    public string[] coreParts;
    //This is just he toppings
    public string[] foodParts;
    //The most food that can be on there and the least amount of food that can be on there
    public int maxHeight;
    
    
}
