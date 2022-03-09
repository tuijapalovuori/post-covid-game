using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Scenes;
using Unity.Transforms;


public class SubSceneLoader : ComponentSystem {
    
    private SceneSystem sceneSystem;
    private GameObject player;

    private readonly float load_distance = 60f;

    protected override void OnCreate() {
        sceneSystem = World.GetOrCreateSystem<SceneSystem>();
    }

    protected override void OnStartRunning() {
        // Try to get player from PlayerFinder
        player = PlayerFinder.FindPlayer();
    }

    protected override void OnUpdate() {

        // Log player coords for debug
        //Debug.Log(player.transform.position);

        foreach (SubScene subScene in SubSceneReferences.Instance.mapBlocks) {

            if (Vector3.Distance(player.transform.position, subScene.transform.position) < load_distance) {
                LoadSubScene(subScene);
            } else {
                UnloadSubScene(subScene);
            }
        }
    }

    private void LoadSubScene(SubScene subScene) {
        sceneSystem.LoadSceneAsync(subScene.SceneGUID);
    }

    private void UnloadSubScene(SubScene subScene) {
        sceneSystem.UnloadScene(subScene.SceneGUID);
    }
}

