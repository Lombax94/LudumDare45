using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class visualtest : MonoBehaviour {

    public Grid theGrid;
    public Tilemap TheTileMap;

    public Tile WorkTile;
    public Tile WaterWorkTile;
    public Tile WaterTile;

    public Tile[] WalkableTiles;

    Vector3Int place = Vector3Int.zero;
    TileBase saver;
    TileBase saverCurrent;
    Vector3Int tilePos = Vector3Int.zero;

    // Start is called before the first frame update
    //test 2
    void Start() {

        for (int i = 0; i < 25; i++) {
            for (int j = 0; j < 25; j++) {
                place.x = i;
                place.y = j;

                if (TheTileMap.GetTile(place) != WaterTile) {//Setting All Tiles To Become Water, But Water That Are Special (Buildable)
                    TheTileMap.SetTile(place, WaterWorkTile);
                }

            }
        }

        for (int i = 5; i < 7; i++) {
            for (int j = 5; j < 7; j++) {
                place.x = i;
                place.y = j;
                saverCurrent = TheTileMap.GetTile(place);

                if (saverCurrent == WaterWorkTile || saverCurrent == WorkTile) {
                    place.x = 50 + i;
                    saver = TheTileMap.GetTile(place);
                    saverCurrent = saver;

                    place.x = i;
                    TheTileMap.SetTile(place, saver);
                    map.SetWalking(place.x, place.y, 0);

                    CheckIfWalkableTile(place);
                    Checksides(place);
                }


            }
        }



    }

    Vector3Int tilepos3 = Vector3Int.zero;
    bool continueSearch = false;

    void Checksides(Vector3Int position) {

        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {



                if (!(i == 0 && j == 0)) {
                    tilepos3.x = position.x + i + 50;
                    tilepos3.y = position.y + j;
                    saver = TheTileMap.GetTile(tilepos3);

                    continueSearch = true;
                    for (int h = 0; h <= 9; h++) {
                        if (saver == WalkableTiles[h]) {
                            continueSearch = false;
                        }
                    }

                    if (continueSearch == true) {
                        tilepos3.x = position.x + i;

                        if (CheckSideSides(tilepos3) == true) {
                            tilepos3.x = position.x + i + 50;
                            tilepos3.y = position.y + j;
                            saver = TheTileMap.GetTile(tilepos3);

                            tilepos3.x = position.x + i;
                            TheTileMap.SetTile(tilepos3, saver);



                        }

                    }
                }
            }
        }
    }

    Vector3Int tilepos2 = Vector3Int.zero;

    bool CheckSideSides(Vector3Int position) {

        for (int l = -1; l <= 1; l++) {
            for (int m = -1; m <= 1; m++) {

                if (l + m == 1 || l + m == -1) {//Check Each Side Of The Square If There Are Any Walkable Paths To Its Sides.
                    tilepos2.x = position.x + l;
                    tilepos2.y = position.y + m;
                    saver = TheTileMap.GetTile(tilepos2);

                    if (saver == WorkTile) {
                        Debug.Log("WORKTILE");
                        return false;
                    }


                    if (saver == WaterWorkTile) {

                        for (int h = 0; h <= 9; h++) {
                            if (saver == WalkableTiles[h]) {
                                if (saver == saverCurrent) {
                                } else {
                                    return false;
                                }
                            }
                        }

                    } else {

                        for (int h = 0; h <= 9; h++) {
                            if (saver == WalkableTiles[h]) {
                                return true;
                            }
                        }


                    }
                }
            }
        }

        return true;

    }

    void CheckIfWalkableTile(Vector3Int position) {

        for (int l = -1; l <= 1; l++) {
            for (int m = -1; m <= 1; m++) {

                if (l + m == 1 || l + m == -1) {

                    tilepos3.x = position.x + l;
                    tilepos3.y = position.y + m;
                    saver = TheTileMap.GetTile(tilepos3);

                    CheckerWalk(tilepos3);

                }
            }
        }

    }

    void CheckerWalk(Vector3Int position) {

        if (saver == WaterWorkTile) {
            tilepos2.x = position.x + 50;
            tilepos2.y = position.y;
            saver = TheTileMap.GetTile(tilepos2);

            for (int h = 0; h <= 9; h++) {
                if (saver == WalkableTiles[h]) {
                    TheTileMap.SetTile(position, WorkTile);
                    return;
                }
            }

        }
    }





    public CollisionMap map;
    public CurrencyManager money;

    // Update is called once per frame 
    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = theGrid.WorldToCell(mouseWorldPos);



            for (int i = coordinate.x; i < coordinate.x + 1; i++) {
                for (int j = coordinate.y; j < coordinate.y + 1; j++) {
                    place.x = i;
                    place.y = j;
                    saverCurrent = TheTileMap.GetTile(place);

                    if (saverCurrent == WorkTile) {

                        if (money.Leavs >= 2 && money.Wood >= 2) {
                            money.addLeaves(-2);
                            money.addWood(-2);


                            place.x = 50 + i;
                            saver = TheTileMap.GetTile(place);
                            saverCurrent = saver;

                            place.x = i;
                            TheTileMap.SetTile(place, saver);
                            map.SetWalking(place.x, place.y, 0);

                            CheckIfWalkableTile(place);
                            Checksides(place);
                        }


                    }
                }
            }

        }
    }
} 
