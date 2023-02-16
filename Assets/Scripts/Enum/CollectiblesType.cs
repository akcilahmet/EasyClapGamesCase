using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesType : CollectProperty
{
   public CollectType type;
   public enum CollectType
   {
      cube,
      sphere,
      cylinder
   }
}
