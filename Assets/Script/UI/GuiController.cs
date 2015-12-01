using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiController: MonoBehaviour
{
    public GameObject playerHealth;
    public GameObject playerGold;
    public GameObject playerScore;
    public GameObject buildButton;
    public GameObject upgradeButton;
    public GameObject sellButton;
    public GameObject square;
    public GameObject turret;
    public GameObject chosenTurret;
    public GameObject indicator;

    void Update()
    {
        playerHealth.GetComponent<Text>().text = "Hit Point : " + GameObject.Find("Player").GetComponent<Player>().hitPoint;
        playerGold.GetComponent<Text>().text = "Gold : " + GameObject.Find("Player").GetComponent<Player>().gold;
        playerScore.GetComponent<Text>().text = "Score : " + GameObject.Find("Player").GetComponent<Player>().score;
    }

    public void build()
    {
        if (square != null)
        {
            Vector3 position = square.transform.position;
            //buildMenu.transform.position = new Vector3 (position.x, 30, position.z);
            indicator.transform.position = new Vector3(0, 200, 0);
            GameObject placeHolder = (GameObject)Instantiate(turret, new Vector3(position.x, 10, position.z), Quaternion.identity);
            if (GameObject.Find("Player").GetComponent<Player>().gold - placeHolder.GetComponent<turret>().cost < 0)
            {
                Destroy(placeHolder);
                Debug.Log("Not enough gold");
            }
            else
                GameObject.Find("Player").GetComponent<Player>().addGold(-placeHolder.GetComponent<turret>().cost);
            buildButton.GetComponent<Button>().interactable = false;
            square = null;
        }
        else
            Debug.Log("cant build there");

    }

    public void upgrade()
    {
        if (chosenTurret != null)
        {
            if (chosenTurret.GetComponent<turret>().nextLv != null)
            {
                chosenTurret.GetComponent<turret>().upgrade();
                indicator.transform.position = new Vector3(0, 200, 0);
                upgradeButton.GetComponent<Button>().interactable = false;
                sellButton.GetComponent<Button>().interactable = false;
                chosenTurret = null;
            }
        }
        else
            Debug.Log("chose a cannon first");
    }

    public void sell()
    {
        if (chosenTurret != null)
        {
            GameObject.Find("Player").GetComponent<Player>().addGold(chosenTurret.GetComponent<turret>().cost / 2);
            Destroy(chosenTurret);
            sellButton.GetComponent<Button>().interactable = false;
            upgradeButton.GetComponent<Button>().interactable = false;
            indicator.transform.position = new Vector3(0, 200, 0);
        }
    }


    public void setSquare(GameObject gObject)
    {
        square = gObject;
        indicator.transform.position = new Vector3(square.transform.position.x, 20, square.transform.position.z);
        chosenTurret = null;
        buildButton.GetComponent<Button>().interactable = true;
        upgradeButton.GetComponent<Button>().interactable = false;
        sellButton.GetComponent<Button>().interactable = false;
    }

    public void setChosenTurret(GameObject gObject)
    {
        chosenTurret = gObject;
        indicator.transform.position = new Vector3(chosenTurret.transform.position.x, 20, chosenTurret.transform.position.z);
        square = null;
        buildButton.GetComponent<Button>().interactable = false;
        sellButton.GetComponent<Button>().interactable = true;
        if (gObject.GetComponent<turret>().nextLv != null)
            upgradeButton.GetComponent<Button>().interactable = true;
        else
            upgradeButton.GetComponent<Button>().interactable = false;
    }

    public void turretToBuild(GameObject turret)
    {
        this.turret = turret;
    }

}
