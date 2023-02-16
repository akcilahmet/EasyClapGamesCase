using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesType : CollectFeature
{
   public CollectType type;
   public enum CollectType
   {
      cube,
      sphere,
      cylinder
   }
}
