using BlasII.ModdingAPI;
using Il2Cpp;
using UnityEngine;

namespace rotten_cheese {
    public static class FlaskChanger{
        private static GameObject ingame_flask_object;
        private static UIFlaskBar ingame_flask_ui_bar;
        private static void FoundObjects(){
            ingame_flask_object = GameObject.Find("Flask");
            ingame_flask_ui_bar = ingame_flask_object.GetComponent<UIFlaskBar>();
            //Main.rotten_cheese.Log("Found Flask GameObject: " + ingame_flask_object.ToString());
        }
        public static void ChangeUIFlaskSprite(string file_name_fill, int image_size_fill, string file_name_empty, int image_size_empty){
            FoundObjects();

            Main.rotten_cheese.FileHandler.LoadDataAsSprite(file_name_fill, image_size_fill, new Vector2(0, 0), true, out Sprite fill_sprite);
            Main.rotten_cheese.FileHandler.LoadDataAsSprite(file_name_empty, image_size_empty, new Vector2(0, 0), true, out Sprite empty_sprite);

            foreach(var ingame_child_flask in ingame_flask_ui_bar.childFlask){
                for(int j = 0; j < ingame_child_flask.upgradeImagesFill.Count; j++){
                    //if(i == 1) Loader.DownloadTexture(ingame_child_flask.upgradeImagesFill[j].texture, "Modding/data/", "Fill"+j);
                    ingame_child_flask.upgradeImagesFill[j] = fill_sprite;
                }
                for(int j = 0; j < ingame_child_flask.upgradeImagesEmpty.Count; j++){
                    //if(i == 1) Loader.DownloadTexture(ingame_child_flask.upgradeImagesEmpty[j].texture, "Modding/data/", "Empty"+j);
                    ingame_child_flask.upgradeImagesEmpty[j] = empty_sprite;
                }
            }
        }
    }
}