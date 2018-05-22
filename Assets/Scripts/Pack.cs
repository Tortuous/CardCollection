using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New", menuName = "Pack")]
public class Pack : ScriptableObject {

    public enum Tier { Bronze, Silver, Gold };
    public Tier tier;

    public List<Card> cards = new List<Card>();

    public Sprite artwork;

    int buyCost;
    public int cardsContained;
    int minValue;
    int maxValue;
}