using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Scenes;
using Unity.Transforms;


public class SubSceneLoader : ComponentSystem {

    
    private SceneSystem sceneSystem;

    protected override void OnCreate() {
        sceneSystem = World.GetOrCreateSystem<SceneSystem>();
    }

    protected override void OnUpdate() {

        // Don't really know what this does, but is nessessary to getting thsi working
        float deltaTime = Time.DeltaTime;

        // ®Find objects with player tag and look for position and load or unload scene depending
        // on the position. 
        Entities
            .WithAll<PlayerTag>()
            .ForEach((ref Translation translation, ref MovementData movementData) => {

                foreach (SubScene subScene in SubSceneReferences.Instance.mapBlocks) {

                    // For moving the blue test cube called "PlayerLocation"
                    if (Input.GetKey(movementData.fowardKey)) {
                        translation.Value.z += movementData.movementSpeed * deltaTime;
                    }
                    if (Input.GetKey(movementData.backKey)) {
                        translation.Value.z -= movementData.movementSpeed * deltaTime;
                    }
                    if (Input.GetKey(movementData.leftKey)) {
                        translation.Value.x -= movementData.movementSpeed * deltaTime;
                    }
                    if (Input.GetKey(movementData.rightKey)) {
                        translation.Value.x += movementData.movementSpeed * deltaTime;
                    }
                    

                    /*
                    * T‰ss‰ on ongelma se, ett‰ Entity ei liiku kun peli pistet‰‰n p‰‰lle, eli 
                    * Player positionin mukaan ei saada koordinaatteja haettua
                    */

                    float loadistance = 60f;

                    if (Vector3.Distance(translation.Value, subScene.transform.position) < loadistance) {
                        LoadSubScene(subScene);
                    } else {
                        UnloadSubScene(subScene);
                    }
                }
            });
    }    

    // Fod loading and 
    private void LoadSubScene(SubScene subScene) {
        sceneSystem.LoadSceneAsync(subScene.SceneGUID);
    }

    private void UnloadSubScene(SubScene subScene) {
        sceneSystem.UnloadScene(subScene.SceneGUID);
    }
}

