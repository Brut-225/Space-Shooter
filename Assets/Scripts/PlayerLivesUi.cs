using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLivesUi : MonoBehaviour
{
    public TMP_Text LivesText;

    PlayerController player;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
        player.OnPlayerHealthChanged.AddListener(UpdateLivesText);
        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
        LivesText.text = $"Lives: {player.Life}";
    }
}
