using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private TankPlayer player;
    [SerializeField] private SpriteRenderer[] playerSprites;
    [SerializeField] private Color[] tankcolor;
    [SerializeField] private int colorIndex;
    void Start()
    {
        HandlePlayerColorChange(0, player.PlayerColorIndex.Value);
        player.PlayerColorIndex.OnValueChanged += HandlePlayerColorChange;
    }

    private void HandlePlayerColorChange(int oldIndex, int newIndex)
    {
        colorIndex = newIndex;
        foreach (var sprite in playerSprites)
        {
            sprite.color = tankcolor[colorIndex];
        }
    }

    private void OnDestroy()
    {
        player.PlayerColorIndex.OnValueChanged -= HandlePlayerColorChange;
    }
}
