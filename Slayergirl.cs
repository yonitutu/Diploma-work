using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slayergirl : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        QuestName = "SlayerGirl uwu";
        Description = " Pick up random items";

        Goals.Add(new CollectionGoal(this, "Croissant", "Pick up 3 items", false, 0, 1));

        Goals.ForEach(g => g.Init());
    }

   
}
