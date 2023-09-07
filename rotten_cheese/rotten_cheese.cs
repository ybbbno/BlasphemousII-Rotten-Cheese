using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using BlasII.ModdingAPI;
using Il2Cpp;
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
        Texture2D duplicateTexture(Texture2D source)
        {
            RenderTexture renderTex = RenderTexture.GetTemporary(
                        source.width,
                        source.height,
                        0,
                        RenderTextureFormat.Default,
                        RenderTextureReadWrite.Linear);

            Graphics.Blit(source, renderTex);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = renderTex;
            Texture2D readableText = new Texture2D(source.width, source.height);
            readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
            readableText.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(renderTex);
            readableText.name = source.name;
            return readableText;
        }

        protected override void OnSceneLoaded(string sceneName)
        {
            GameObject ingame_flask_object = GameObject.Find("Flask");
            Log("Found Flask GameObject: " + ingame_flask_object.ToString());
            //Log(ingame_flask_object.GetType().GetMethods());    
            UIFlaskBar ingame_flask_ui_bar = ingame_flask_object.GetComponent<UIFlaskBar>();
            Log("Found Flask UIFlaskBar: " + ingame_flask_ui_bar.ToString());

            Main.rotten_cheese.FileHandler.LoadDataAsSprite("cheese.png", 24, new Vector2(0, 0), true, out Sprite new_sprite);
            Log("New Flask Sprite was created:" + new_sprite.ToString());
            int i = 0;
            foreach(var ingame_child_flask in ingame_flask_ui_bar.childFlask){
                i++;
                for(int j = 0; j < ingame_child_flask.upgradeImagesFill.Count; j++){
                    if(i == 1){
                        var ingame_child_flask_sprite = ingame_child_flask.upgradeImagesFill[j];
                        var ingame_child_flask_texture = ingame_child_flask_sprite.texture;
                        var child_flask_texture = duplicateTexture(ingame_child_flask_texture);
                        Log(child_flask_texture.name+".png="+child_flask_texture.GetPixels());
                        byte[] child_flask_texture_bytes = child_flask_texture.EncodeToPNG();
                        File.WriteAllBytes("Modding/data/"+child_flask_texture.name+j+"Fill.png", child_flask_texture_bytes);
                    }
                    //ingame_child_flask.upgradeImagesFill[j] = new_sprite;
                }
                for(int j = 0; j < ingame_child_flask.upgradeImagesEmpty.Count; j++){
                    if(i == 1){
                        var ingame_child_flask_sprite = ingame_child_flask.upgradeImagesEmpty[j];
                        var ingame_child_flask_texture = ingame_child_flask_sprite.texture;
                        var child_flask_texture = duplicateTexture(ingame_child_flask_texture);
                        Log(child_flask_texture.name+".png="+child_flask_texture.GetPixels());
                        byte[] child_flask_texture_bytes = child_flask_texture.EncodeToPNG();
                        File.WriteAllBytes("Modding/data/"+child_flask_texture.name+j+"Empty.png", child_flask_texture_bytes);
                    }
                    //ingame_child_flask.upgradeImagesEmpty[j] = new_sprite;
                }
            }

            Log("All sprites was successfully modified");

            /*
            GameObject flask_object = GameObject.Find("Flask");
            Log("Found Flask GameObject: " + flask_object.ToString());

            UIFlaskBar flask_ui_bar = flask_object.GetComponent<UIFlaskBar>();
            Log("Found Flask UIFlaskBar: " + flask_ui_bar.ToString());

            Main.rotten_cheese.FileHandler.LoadDataAsSprite("cheese.png", 23, new Vector2(0, 0), true, out Sprite rooten_cheese_sprite);

            Log("Rotten Cheese Sprite was created:" + rooten_cheese_sprite.ToString());
            */
            //foreach(var child_flask in flask_ui_bar.childFlask){
                /*
                foreach(var empty in child_flask.upgradeImagesEmpty){
                    Log(empty.ToString());
                }
                */
                //for(int j = 0; j < child_flask.upgradeImagesFill.Count(); j++){
                //    child_flask.upgradeImagesFill[j] = rooten_cheese_sprite;
                //}

                /*
                if (i <= 3){
                    Log("\nNumber of flusk is "+i);
                    
                    string upgradeImagesEmpty_str = null;
                    if (child_flask.upgradeImagesEmpty != null) {
                        upgradeImagesEmpty_str = "";
                        foreach (var image_empty in child_flask.upgradeImagesEmpty) upgradeImagesEmpty_str += image_empty.ToString()+", ";
                    }
                    Log("upgradeImagesEmpty: "+upgradeImagesEmpty_str);
                    
                    string upgradeImagesFill_str = null;
                    if (child_flask.upgradeImagesFill != null) {
                        upgradeImagesFill_str = "";
                        foreach (var image_empty in child_flask.upgradeImagesFill) upgradeImagesFill_str += image_empty.ToString()+", ";
                    }
                    Log("upgradeImagesFill: "+upgradeImagesFill_str);
                    
                    //UnityEngine.UI.Image
                    var imageControl = child_flask.imageControl != null ? child_flask.imageControl.sprite.ToString() : null;
                    Log("imageControl: "+imageControl);

                    Log("animDelay: "+child_flask.animDelay);

                    var OnFilled = child_flask.OnFilled != null ? child_flask.OnFilled.ToString() : null;
                    Log("OnFilled: "+OnFilled);

                    var currentSprite = child_flask.currentSprite != null ? child_flask.currentSprite.ToString() : null;
                    Log("currentSprite: "+currentSprite);

                    Log("prevUpgradeLevel: "+child_flask.prevUpgradeLevel);

                    Log("wasFilled: "+child_flask.wasFilled);

                    Log("delayBeforeFill: "+child_flask.delayBeforeFill);
                }
                */


            //Log("All sprites was successfully modified");
            
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
        
    }
}
