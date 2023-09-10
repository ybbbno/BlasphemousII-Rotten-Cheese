using System;
using System.Collections.Generic;
using System.Linq;
using Harmony;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppPlaymaker.Inventory;
using Il2CppTGK.Game.Components;
using UnityEngine;


namespace rotten_cheese {
    public static class FlaskChanger{
        private static GameObject _ingame_flask_object;
        private static UIFlaskBar _ingame_flask_ui_bar;
        private static Il2CppReferenceArray<Sprite> _fill_sprites = new Il2CppReferenceArray<Sprite>(4);
        public static Il2CppReferenceArray<Sprite> fill_sprites { get {return _fill_sprites;} }
        private static Il2CppReferenceArray<Sprite> _empty_sprites = new Il2CppReferenceArray<Sprite>(4);
        public static Il2CppReferenceArray<Sprite> empty_sprites { get {return _empty_sprites;} }
        private static Il2CppReferenceArray<Sprite> _warning_sprites = new Il2CppReferenceArray<Sprite>(4);
        public static Il2CppReferenceArray<Sprite> warning_sprites { get {return _warning_sprites;} }
        private static void FoundObjects(){
            _ingame_flask_object = GameObject.Find("Flask");
            _ingame_flask_ui_bar = _ingame_flask_object.GetComponent<UIFlaskBar>();
        }
        public static void ChangeUIFillFlaskSprite(string upgrade_0_file_path, int upgrade_0_image_size,
                                                   string upgrade_1_file_path, int upgrade_1_image_size,
                                                   string upgrade_2_file_path, int upgrade_2_image_size,
                                                   string upgrade_3_file_path, int upgrade_3_image_size){
            FoundObjects();

            Sprite _sprite;

            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_0_file_path, upgrade_0_image_size, new Vector2(0, 0), true, out _sprite);
            _fill_sprites[0] = _sprite;
            
            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_1_file_path, upgrade_1_image_size, new Vector2(0, 0), true, out _sprite);
            _fill_sprites[1] = _sprite;

            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_2_file_path, upgrade_2_image_size, new Vector2(0, 0), true, out _sprite);
            _fill_sprites[2] = _sprite;
            
            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_3_file_path, upgrade_3_image_size, new Vector2(0, 0), true, out _sprite);
            _fill_sprites[3] = _sprite;

            foreach(var ingame_child_flask in _ingame_flask_ui_bar.childFlask){
                ingame_child_flask.upgradeImagesFill = _fill_sprites;
            }
        }

        public static void ChangeUIEmptyFlaskSprite(string upgrade_0_file_path, int upgrade_0_image_size,
                                                    string upgrade_1_file_path, int upgrade_1_image_size,
                                                    string upgrade_2_file_path, int upgrade_2_image_size,
                                                    string upgrade_3_file_path, int upgrade_3_image_size){
            FoundObjects();

            Sprite _sprite;

            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_0_file_path, upgrade_0_image_size, new Vector2(0, 0), true, out _sprite);
            _empty_sprites[0] = _sprite;
            
            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_1_file_path, upgrade_1_image_size, new Vector2(0, 0), true, out _sprite);
            _empty_sprites[1] = _sprite;

            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_2_file_path, upgrade_2_image_size, new Vector2(0, 0), true, out _sprite);
            _empty_sprites[2] = _sprite;
            
            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_3_file_path, upgrade_3_image_size, new Vector2(0, 0), true, out _sprite);
            _empty_sprites[3] = _sprite;

            foreach(var ingame_child_flask in _ingame_flask_ui_bar.childFlask){
                ingame_child_flask.upgradeImagesEmpty = _empty_sprites;
            }
        }

        public static void ChangeUINoFlaskWarningSprite(string upgrade_0_file_path, int upgrade_0_image_size,
                                                        string upgrade_1_file_path, int upgrade_1_image_size,
                                                        string upgrade_2_file_path, int upgrade_2_image_size,
                                                        string upgrade_3_file_path, int upgrade_3_image_size){
            FoundObjects();

            Sprite _sprite;

            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_0_file_path, upgrade_0_image_size, new Vector2(0, 0), true, out _sprite);
            _warning_sprites[0] = _sprite;

            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_1_file_path, upgrade_1_image_size, new Vector2(0, 0), true, out _sprite);
            _warning_sprites[1] = _sprite;

            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_2_file_path, upgrade_2_image_size, new Vector2(0, 0), true, out _sprite);
            _warning_sprites[2] = _sprite;

            Main.rotten_cheese.FileHandler.LoadDataAsSprite(upgrade_3_file_path, upgrade_3_image_size, new Vector2(0, 0), true, out _sprite);
            _warning_sprites[3] = _sprite;

            _ingame_flask_ui_bar.noFlaskWarning.upgradeImagesEmpty = _warning_sprites;

        }
    }
}