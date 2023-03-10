using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// スクリプト
/// </summary>
public class ModelImporterSettings : AssetPostprocessor
{
    #region Unity Methods

    private void OnPostprocessModel(GameObject go)
    {
        ModelImporter modelImporter = assetImporter as ModelImporter;

        //初回インポートのみに制限
        if (!modelImporter.importSettingsMissing) return;

        //ヒューマン用に設定
        modelImporter.animationType = ModelImporterAnimationType.Human;
        if(go.name.Contains("@"))
        {
            modelImporter.avatarSetup = ModelImporterAvatarSetup.CopyFromOther;
            //var modelName = go.name.Split('@');
            ////エディター
            //foreach (var guid in AssetDatabase.FindAssets("t:Avatar"))
            //{
            //    var path = AssetDatabase.GUIDToAssetPath(guid);
            //    var obj = AssetDatabase.LoadMainAssetAtPath(path);
            //    if (obj as ModelImporter) continue;
            //    var data = obj as Avatar;
            //    Debug.Log(data);

            //    if (data.name == $"{modelName[0]}")
            //    {
            //        Debug.Log("Set");
                    
            //        modelImporter.sourceAvatar = data;
            //    }
            //}
        }

        //var humanDescription = modelImporter.humanDescription;
        //foreach (var bone in humanDescription.human)
        //{
        //    var isNotMatch = bone.humanName.Equals(bone.boneName);
        //    var decorationColor = isNotMatch ? "<color=black>" : "<color=blue>";
        //    Debug.Log($"{bone.humanName}:{decorationColor}{bone.boneName}</color>");
        //}
    }

    #endregion
}