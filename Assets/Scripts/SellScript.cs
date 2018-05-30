using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellScript : MonoBehaviour {
    public PlayerInformation playerInformation;
    public CardDisplay cardDisplay;

    public void SellCardCall()
    {
        playerInformation.SellCard(cardDisplay);
    }
}