using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesLibrary : MonoBehaviour
{
    public static ImagesLibrary instance;
    [SerializeField]
    public Sprite[] sprites;
    public Dictionary<(int, char), Sprite> image_dict;
    

    void Awake()
    {
        instance = this;
        image_dict = new Dictionary<(int, char), Sprite>
        {
            [(01, 'C')] = sprites[00],
            [(02, 'C')] = sprites[01],
            [(03, 'C')] = sprites[02],
            [(04, 'C')] = sprites[03],
            [(05, 'C')] = sprites[04],
            [(06, 'C')] = sprites[05],
            [(07, 'C')] = sprites[06],
            [(08, 'C')] = sprites[07],
            [(09, 'C')] = sprites[08],
            [(10, 'C')] = sprites[09],
            [(11, 'C')] = sprites[10],
            [(12, 'C')] = sprites[11],
            [(13, 'C')] = sprites[12],
            [(01, 'D')] = sprites[13],
            [(02, 'D')] = sprites[14],
            [(03, 'D')] = sprites[15],
            [(04, 'D')] = sprites[16],
            [(05, 'D')] = sprites[17],
            [(06, 'D')] = sprites[18],
            [(07, 'D')] = sprites[19],
            [(08, 'D')] = sprites[20],
            [(09, 'D')] = sprites[21],
            [(10, 'D')] = sprites[22],
            [(11, 'D')] = sprites[23],
            [(12, 'D')] = sprites[24],
            [(13, 'D')] = sprites[25],
            [(01, 'H')] = sprites[26],
            [(02, 'H')] = sprites[27],
            [(03, 'H')] = sprites[28],
            [(04, 'H')] = sprites[29],
            [(05, 'H')] = sprites[30],
            [(06, 'H')] = sprites[31],
            [(07, 'H')] = sprites[32],
            [(08, 'H')] = sprites[33],
            [(09, 'H')] = sprites[34],
            [(10, 'H')] = sprites[35],
            [(11, 'H')] = sprites[36],
            [(12, 'H')] = sprites[37],
            [(13, 'H')] = sprites[38],
            [(01, 'S')] = sprites[39],
            [(02, 'S')] = sprites[40],
            [(03, 'S')] = sprites[41],
            [(04, 'S')] = sprites[42],
            [(05, 'S')] = sprites[43],
            [(06, 'S')] = sprites[44],
            [(07, 'S')] = sprites[45],
            [(08, 'S')] = sprites[46],
            [(09, 'S')] = sprites[47],
            [(10, 'S')] = sprites[48],
            [(11, 'S')] = sprites[49],
            [(12, 'S')] = sprites[50],
            [(13, 'S')] = sprites[51],

        };
    }


}
