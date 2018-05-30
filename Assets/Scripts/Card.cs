using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New", menuName = "Card")]
public class Card : ScriptableObject {

    public enum Rarity { Basic, Rare, Epic};
    public Rarity rarity;
    public enum CardType { Minion, Spell, Hero };
    public CardType cardType;

    public new string name;
    public string description;
    public string cardID;
    public float percentage;

    public Sprite raritySprite;
    public Sprite artwork;
    public Sprite cardBack;

    public int cost;
    public int attack;
    public int health;
    public int sellValue;

    public void Print()
    {
    }
}