using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    //this script changes the numbers next to sliders in the debugger menu, updating them to the value of the slider
    [SerializeField] Slider playerSpeedSlider; //we find what the slider is so we can store its default value
    [SerializeField] Text playerSpeedText;
    float defaultValueForPlayerSpeed; //this is where its default value is stored

    [SerializeField] Slider SpeedIncreaseSlider;
    [SerializeField] Text playerIncreaseSpeedText;
    float defaultValueForIncreaseSpeed;

    [SerializeField] Slider forceOfBoostSlider;
    [SerializeField] Text forceOfBoostValue;
    float defaultValueForForceOfBoost;

    [SerializeField] Slider speedOfBoostSlider;
    [SerializeField] Text speedOfBoostValue;
    float defaultValueForSpeedOfBoost;

    [SerializeField] Slider numberOfCoinsNeededSlider;
    [SerializeField] Text numberOfCoinsNeededText;
    float defaultValueForNumberOfCoinsNeeded;

    [SerializeField] Slider cameraYAxxisSlider;
    [SerializeField] Text cameraYAxxis;
    float defaultValueForYAxxis;

    [SerializeField] Slider cameraZAxxisSlider;
    [SerializeField] Text cameraZAxxis;
    float defaultValueForZAxxis;

    [SerializeField] Slider cameraAngleSlider;
    [SerializeField] Text cameraAngle;
    float defaultValueForCameraAngle;

    [SerializeField] Slider coinsToSpawnSlider;
    [SerializeField] Text coinsToSpawn;
    float defaultValueForCoinsToSpawn;

    [SerializeField] ForkMovement forkMovement; //we need to access the fork movement script since that object is a prefab
    [SerializeField] Slider forkMoveSpeedSlider;
    [SerializeField] Text forkMoveSpeed;
    float defaultValueForForkMoveSpeed;

    //on awake, we store the default values
    private void Awake()
    {
        defaultValueForPlayerSpeed = playerSpeedSlider.value;
        defaultValueForIncreaseSpeed = SpeedIncreaseSlider.value;
        defaultValueForForceOfBoost = forceOfBoostSlider.value;
        defaultValueForSpeedOfBoost = speedOfBoostSlider.value;
        defaultValueForNumberOfCoinsNeeded = numberOfCoinsNeededSlider.value;
        defaultValueForYAxxis = cameraYAxxisSlider.value;
        defaultValueForZAxxis = cameraZAxxisSlider.value;
        defaultValueForCameraAngle = cameraAngleSlider.value;
        defaultValueForCoinsToSpawn = coinsToSpawnSlider.value;
        defaultValueForForkMoveSpeed = forkMoveSpeedSlider.value;
    }

    //when we press the button, the values return to default
    public void ResetToDefaults()
    {
        playerSpeedSlider.value = defaultValueForPlayerSpeed;
        SpeedIncreaseSlider.value = defaultValueForIncreaseSpeed;
        forceOfBoostSlider.value = defaultValueForForceOfBoost;
        speedOfBoostSlider.value = defaultValueForSpeedOfBoost;
        numberOfCoinsNeededSlider.value = defaultValueForNumberOfCoinsNeeded;
        cameraYAxxisSlider.value = defaultValueForYAxxis;
        cameraZAxxisSlider.value = defaultValueForZAxxis;
        cameraAngleSlider.value = defaultValueForCameraAngle;
        coinsToSpawnSlider.value = defaultValueForCoinsToSpawn;
        forkMoveSpeedSlider.value = defaultValueForForkMoveSpeed;
    }
    
    
    public void ShowSliderValueForPlayerSpeed(float value) //text1 is the number for player speed
    {
        playerSpeedText.text = value.ToString();
    }
    public void ShowSliderValueForSpeedIncrease(float value) //this is for the amount of speed increase per coin collected
    {
        playerIncreaseSpeedText.text = value.ToString();
    }
    public void ShowSliderValueForForceOfBoost(float value) 
    {
        forceOfBoostValue.text = value.ToString();
    }
    public void ShowSliderValueForSpeedOfBoost(float value) 
    {
        speedOfBoostValue.text = value.ToString();
    }
    public void ShowSliderValueForNumberOfCoinsNeeded(float value) 
    {
        value = Mathf.Round(value);
        numberOfCoinsNeededText.text = value.ToString();
    }
    public void ShowSliderValueForYAxxis(float value) //this is for the change to camera height
    {
        cameraYAxxis.text = value.ToString();
    }
    public void ShowSliderValueForZAxxis(float value) //thos is for the change to camera offset 
    {
        cameraZAxxis.text = value.ToString();
    }
    public void ShowSliderValueForAngle(float value) //this is for camera angle
    {
        cameraAngle.text = value.ToString();
    }
    public void ShowSliderValueForCoins(float value) //this is for # of coins per tile spawned
    {
        value = Mathf.RoundToInt(value);
        coinsToSpawn.text = value.ToString();
    }
    public void ChangeForkSpeed(float value) //we access the fork speed from here since it is a prefab object spawned from code
    {
        forkMovement.moveSpeed = value;
    }
    public void ShowSliderValueForForkSpeed(float value) //this is for fork speed
    {
        forkMoveSpeed.text = value.ToString();
    }
}