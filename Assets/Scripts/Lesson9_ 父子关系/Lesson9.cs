using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9 : MonoBehaviour
{
	//public GameObject F2;

	public Transform son;
    void Start()
    {
		#region 获取和设置父对象
		//获取父对象
		//print(this.transform.parent.name);

		//设置父对象 断绝父子父子关系
		//this.transform.parent = null;

		//设置父对象 认爸爸
		//this.transform.parent = F2.transform;

		//通过API来进行父子关系的设置
		//第一个参数:设置谁为父对象
		//第二个参数为true 会保留世界坐标系下的信息 (与在Unity面板上拖动相同)
		//第二个参数为false 则相对父对象坐标系中的信息不变 (也就是Inspector面板上的数值不变)
		//(不填第二个参数 默认为true)
		//this.transform.SetParent(null, false);//移除父对象,且面板上的transform数值不变
		//this.transform.SetParent(F2.transform, true);//添加父对象F2,且保持相对世界坐标系的信息不变

		#endregion

		#region 与所有子对象断绝关系
		//this.transform.DetachChildren();
		#endregion

		#region 获取子对象
		//按名字查找子对象
		//找到子对象的 transform信息
		//Find方法 可以找到失活的对象 而GameObject相关的查找是找不到失活对象的
		print(this.transform.Find("Cube (1)").name);
		//它只能找到子对象,不能找到孙子对象
		//print(this.transform.Find("GameObject").name);
		//虽然它的效率 比GameObject相关 更高一些 但是 前提是必须知道父对象是谁

		//遍历子对象
		//如何得到有多少个子对象
		//失活的子对象也会计数 ,孙子对象不会计数,同上
		print(this.transform.childCount);
		//通过索引号 去得到自己对应的子对象
		//如果编号超过了子对象的数量 会直接报错
		//返回值是 transform 可以得到对应子对象的 位置相关信息
		this.transform.GetChild(0);		//类似数组

		for (int i = 0; i < this.transform.childCount; i++)
		{
			print(this.transform.GetChild(i).name);
		}
		#endregion

		#region 儿子的操作
		//判断父对象是谁
		//一个对象 判断自己是不是另一个对象的子对象
		if (son.IsChildOf(this.transform))
		{
			print("目标是子对象");
		}
		else
		{
			print("目标不是子对象");
		}
		//得到自己作为子对象的编号
		print(son.GetSiblingIndex());
		//把自己编号设置为第一个
		son.SetAsFirstSibling();
		//把自己设置为最后一个
		son.SetAsLastSibling();
		//把自己设置为指定编号
		//如果参数超出 子对象数量范围(负数和超过最大编号的数) 则会设置成最后一个子对象
		son.SetSiblingIndex(6);
		#endregion
	}
	void Update()
    {
        
    }
	//总结
	//设置父对象相关内容
	//获取子对象

	//移除所有子对象
	//子对象操作
}
