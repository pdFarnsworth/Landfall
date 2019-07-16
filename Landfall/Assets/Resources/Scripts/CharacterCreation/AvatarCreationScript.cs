using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UMA;
using UMA.CharacterSystem;

public class AvatarCreationScript : MonoBehaviour
{
    public DynamicCharacterAvatar avatar;
    private Dictionary<string, DnaSetter> myDNA;

    public Slider heightSlider;
    public Slider weightSlider;

    // Start is called before the first frame update
    void Start()
    {
        //avatar = FindObjectOfType<DynamicCharacterAvatar>();
    }
    void OnEnable()
    {
        avatar.CharacterUpdated.AddListener(Updated);
        heightSlider.onValueChanged.AddListener(AdjustHeight);
    }
    void OnDisable()
    {
        avatar.CharacterUpdated.RemoveListener(Updated);
        heightSlider.onValueChanged.RemoveListener(AdjustHeight);
    }
    void Updated(UMAData data)
    {
        myDNA = avatar.GetDNA();
        heightSlider.value = myDNA["height"].Get();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGender(string s)
    {
        if (s == "Male" && avatar.activeRace.name != "HumanMaleDCS")
        {
            avatar.ChangeRace("HumanMaleDCS");
        }
        if (s == "Female" && avatar.activeRace.name != "HumanFemaleDCS")
        {
            avatar.ChangeRace("HumanFemaleDCS");
        }
    }

    public void AdjustHeight(float val)
    {
        myDNA["height"].Set(val);
        avatar.BuildCharacter();
    }
    public void AdjustWeight()
    { }

    public void ChangeSkinColor(Color col)
    {
        avatar.SetColor("Skin", col);
        avatar.UpdateColors(true);
    }
}
