using UnityEngine;
using System.Collections;

public class ButtonUndo : MonoBehaviour {

    public GameObject TheChosen;
    public void setChosenOnject(GameObject gObj)
    {
        TheChosen = gObj;
    }
    public void UndoObject()
    {
        if (TheChosen != null && TheChosen.GetComponent<turret>().fired == false)
        {
            print("undo");

            GameObject.Find("Player").GetComponent<Player>().addGold(TheChosen.GetComponent<turret>().cost);
            TheChosen.GetComponent<turret>().setIsClicked(false);
            Destroy(TheChosen);
        }
        else print("Cant not undo");
    }
}
