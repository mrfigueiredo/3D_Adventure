using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clothing
{
    public enum ClothType
    {
        SPEED,
        DAMAGE_REDUCTION
    }

    public class ClothingManager : Singleton<ClothingManager>
    {
        public List<ClothingSetup> setups;

        public ClothingSetup GetByType(ClothType type)
        {
            return setups.Find( i => i.clothType == type );
        }
    }

    [System.Serializable]
    public class ClothingSetup
    {
        public ClothType clothType;
        public Texture2D texture;

    }

}