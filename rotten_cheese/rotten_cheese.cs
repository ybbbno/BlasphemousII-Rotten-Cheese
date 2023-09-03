using System.Linq;
using BlasII.ModdingAPI;
using Il2Cpp;
using Il2CppTGK.Game;
using Il2CppTGK.Game.Components.StatsSystem;
using UnityEngine;

namespace rotten_cheese
{
    public class rotten_cheese : BlasIIMod
    {
        public rotten_cheese() : base(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_AUTHOR, ModInfo.MOD_VERSION) { }

        protected override void OnInitialize()
        {
            LogError($"{ModInfo.MOD_NAME} is initialized");
        }
        protected override void OnSceneLoaded(string sceneName)
        {
            GameObject flask_object = GameObject.Find("Flask");
            Log("Found Flask GameObject: " + flask_object.ToString());

            UIFlaskBar flask_ui_bar = flask_object.GetComponent<UIFlaskBar>();
            Log("Found Flask UIFlaskBar: " + flask_ui_bar.ToString());
            // stat - Flask
            // flaskStrengthStat - Healing Flasks Factor
            // statRef - PlayerStatsComponent Ref (TGK.Game.Components.StatsSystem.StatsComponentRef)
            // childFlask - Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray`1[Il2Cpp.UIFlaskUpgradeControl]
            // staticControl - False
            // noFlaskWarningFade - FlaskWarning (TGK.Game.Components.FadeImage)
            // noFlaskWarning - FlaskWarning (UIFlaskUpgradeControl)
            // delayBeforeFillPerFlask - 0,2
            // statsComponent - #Main Player (TGK.Game.Components.StatsSystem.StatsComponent)
            // player - #Main Player (Lightbug.Kinematic2D.Implementation.CharacterController2D)
            // flaskUse - abilities (Game._3rd_party.Kinematic2D.Implementation.Scripts.Character_Abilities.Item_Usage.FlaskUse)
            // prevLastFilledFlask - 3

            Main.rotten_cheese.FileHandler.LoadDataAsSprite("cheese.png", 23, new Vector2(0, 0), true, out Sprite rooten_cheese_sprite);

            Log("Rotten Cheese Sprite was created:" + rooten_cheese_sprite.ToString());

            foreach(var child_flask in flask_ui_bar.childFlask){
                /*
                foreach(var empty in child_flask.upgradeImagesEmpty){
                    Log(empty.ToString());
                }
                */
                for(int i = 0; i < child_flask.upgradeImagesFill.Count(); i++){
                    child_flask.upgradeImagesFill[i] = rooten_cheese_sprite;
                }
            }

            Log("All sprites was successfully modified");
            
            /*
            Il2CppTGK.Game.Components.FadeImage flask_warning_fade = flask_ui_bar.noFlaskWarningFade;
            Image first_flask_image = flask_warning_fade.image;
            first_flask_image.color = UnityEngine.Color.black;

            foreach(var component in flask_warning_fade.fades){
                component.targetColor = UnityEngine.Color.black;
            } 
            */
            //Data.LoadAllObjects();
            //Log(string.Join(Environment.NewLine, Data._rangeStats));
            /*
            Log(flask_object.activeInHierarchy.ToString());
            Log(flask_object.activeSelf.ToString());
            Log(flask_object.isStatic.ToString());
            Log(flask_object.layer.ToString());
            Log(flask_object.scene.ToString());
            Log(flask_object.sceneCullingMask.ToString());
            Log(flask_object.tag.ToString());
            if (sceneName == "MainMenu"){
                Data.TryGetRangeStat("Flask", out RangeStatID test);
            } else {
                if (Data.TryGetRangeStat("Flask", out RangeStatID flask)){
                    Log("Found Flask ID");
                    //PlayerStats.SetCurrentValue(flask, 3);
                    //PlayerStats.SetCurrentToMax(flask);
                    
                    
                    //GameObject rotten_cheese_object = new GameObject("Flask");
                    //Il2CppArrayBase<Texture2D> images = ;
                    
                    //Component[] components = flask_object.GetComponents();
                    
                }
            }
            */
        }

        private StatsComponent _playerStats;
        public StatsComponent PlayerStats
        {
            get
            {
                if (_playerStats == null)
                    _playerStats = CoreCache.PlayerSpawn.PlayerInstance.GetComponent<StatsComponent>();
                return _playerStats;
            }
        }

    }
}
