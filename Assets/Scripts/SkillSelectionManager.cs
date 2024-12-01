using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectionManager : MonoBehaviour
{
    public static SkillSelectionManager Instance; // Singleton instance

    public PlayerSkills playerSkills; // Reference to PlayerSkills
    public GameObject skillSelectionUI; // UI for skill selection
    public GameObject[] skillButtons;  // Skill buttons

    private void Awake()
    {
        // Ensure only one instance of SkillSelectionManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instance
        }

        // Prevent this object from being destroyed on scene load
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializePlayerSkills();
        skillSelectionUI.SetActive(false); // Hide UI at game start
    }

    private void OnEnable()
    {
        // Subscribe to the scene-loaded event to reinitialize playerSkills
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event when this object is disabled
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Reinitialize PlayerSkills when a new scene is loaded
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        InitializePlayerSkills();
    }

    // Find and assign PlayerSkills reference
    private void InitializePlayerSkills()
    {
        playerSkills = FindObjectOfType<PlayerSkills>();
        if (playerSkills == null)
        {
            Debug.LogError("PlayerSkills not found in the scene!");
        }
        else
        {
            UpdateSkillButtons(); // Update skill buttons after reassigning PlayerSkills
        }
    }

    // Show the skill selection menu
    public void ShowSkillSelectionMenu()
    {
        skillSelectionUI.SetActive(true); // Show UI
        Time.timeScale = 0f; // Pause the game
    }

    // Handle skill selection
    public void SelectSkill(int skillIndex)
    {
        if (playerSkills != null)
        {
            playerSkills.UpgradeSkill(skillIndex); // Upgrade the selected skill
            UpdateSkillButtons(); // Refresh buttons after upgrading
        }
        else
        {
            Debug.LogError("PlayerSkills reference is missing!");
        }

        skillSelectionUI.SetActive(false); // Hide UI
        Time.timeScale = 1f; // Resume the game
    }

    // Update skill buttons based on player skill levels
    public void UpdateSkillButtons()
    {
        if (playerSkills == null)
        {
            Debug.LogError("PlayerSkills reference is missing!");
            return;
        }

        for (int i = 0; i < skillButtons.Length; i++)
        {
            bool isUnlocked = i switch
            {
                0 => playerSkills.powerBlastLevel > 0,
                1 => playerSkills.shootSpeedLevel > 0,
                2 => playerSkills.moveSpeedLevel > 0,
                _ => false
            };

            skillButtons[i].SetActive(isUnlocked); // Enable/disable buttons based on conditions
        }
    }
}
