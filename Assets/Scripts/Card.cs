using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Regular")]
public class Card : ScriptableObject {

    public enum Rarity { Basic, Rare, Epic, Legendary };
    public enum CardType { Minion, Spell, Hero };
    public new string name;
    public string description;
    public string tag;
    
    public Sprite Artwork;

    public int cost;
    public int attack;
    public int health;

    public void Print()
    {
        Debug.Log(name = ": " + description + " The card costs " + cost);
    }
}