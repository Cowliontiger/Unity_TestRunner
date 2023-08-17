using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.Reflection;

namespace Assets._0_Script.MainSystem.Shop
{
    class Class1
    {
        private Action<bool> _callBack;//是否注册成功
        private static bool flag = false;
        public static bool NewTestScriptSimplePasses(Action<int> callback)
        {
            ShopType st = new ShopType();
            List<ShopItemTo> alist = new List<ShopItemTo>();
            ShopItemTo sit = new ShopItemTo();
            sit.Id = 123;
            sit.Count = 12;
            alist.Add(sit);
            //ShopModule.Shopping(st,alist);
            //ShopModule.AddGoodsToShoppingCart(st, alist);
            object[] obj = new object[] { st, alist };

            //Reflaction mehtod
            TUtils.ReflectMethod("Assembly-CSharp", "ShopModule", "", "RemoveGoodsToShoppingCart", obj);

            //Reflaction field
            MethodInfo m;
            BindingFlags flags;
            Assembly assembly = Assembly.Load("Assembly-CSharp");
            Type t = assembly.GetType("ShopModule");
            m = t.GetMethod("RemoveGoodsToShoppingCart");
            var obj2 = Activator.CreateInstance(t);
            m.Invoke(obj2, obj);
            Dictionary<ShopType, List<ShopItemTo>> dict_shoppingCart =
                (Dictionary<ShopType, List<ShopItemTo>>)obj2.GetType().GetField("dict_shoppingCart", BindingFlags.Static | BindingFlags.NonPublic).GetValue(obj2);
            Debug.Log("flag:" + dict_shoppingCart.Count);
            return flag;
        }
    }
}
