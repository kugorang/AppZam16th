using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : SingleTon<CharacterManager>
{
    public List<Sprite> manSprites = new List<Sprite>();
    public List<Sprite> womanSprites = new List<Sprite>();

    public GameScene.Character.Receiver receiver;
    public GameScene.Character.Thrower thrower;
}    
