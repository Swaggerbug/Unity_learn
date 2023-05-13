using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8 : MonoBehaviour
{
	public Transform lookAtobject;
    void Start()
    {
		#region 知识点一 缩放
		//相对世界坐标系
		print(this.transform.lossyScale);
		//相对本地坐标系(父对象)
		print(this.transform.localScale);

		//注意:
		//1.同样缩放不能只改xyz 只能一起改(相对于世界坐标系的缩放大小不能修改,只能获取)
		//所以 我们一般修改缩放大小 都是改的 相对于父对象的 缩放大小 localScale
		//this.transform.localScale = new Vector3(3, 3, 3);
	}
	void Update()
    {
		//2.Unity没有提供关于缩放的API
		//之前的 旋转 位移 都提供了 对应的 API 而 缩放没有
		//如果你想要 缩放发生变化 只能自己去写(自己算)
		//this.transform.localScale += Vector3.one*Time.deltaTime*0.1f;
		#endregion

		#region 知识点二 看向
		//让一个对象的面朝向 可以一直看向某一个点或者对象
		//看向一个点
		//this.transform.LookAt(Vector3.zero);

		//看向一个对象
		this.transform.LookAt(lookAtobject);
		#endregion
	}
	
	
	//总结：
	//缩放相关
	//相对于世界坐标系的缩放 只能得不能改
	//只能去修改 相对于本地坐标系的缩放（相对于父对像）
	//没有提供对应的API 来缩放变化 只能自己算
	//看向
	//LookAt看向一个点或者一个对象
	//一定记往是写在Update里面 才会不停变化
}
