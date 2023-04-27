using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class lesson1 : MonoBehaviour
{
	#region 知识点一 了解帧的概念
	//Unity 底层已经帮助我们做好了死循环
	//我们需要学习Unity的生命周期函数
	//利用它做好的规则来执行我们的游戏逻辑就行了
	#endregion
	#region 知识点二 生命周期函数的概念
	//所有继承MonoBehavior的脚本最终都会挂载到Gameobject游戏对象上
	//生命周期函数就是该脚本对象依附的Gameobjecti对象从出生到消亡整个生命周期中
	//会通过反射自动调用的一些特殊函数
	//Unity帮助我们记录了一个Gameobjecti对象依附了哪些脚本
	//会自动的得到这些对象，通过反射去执行一些固定名字的函数
	#endregion
	#region 知识点三 生命周期函数
	//注意:
	//生命周期函数的访问修饰符一般为private和protected
	//因为不需要在外部自己调用生命周期函数 都是Unity自动帮我们调用
	
	
	//当自己这个类对象被创建时,调用Awake生命周期函数
	//类似于构造函数 我们可以在一个类对象 创建是进行一些初始化操作
	protected virtual void Awake()
	{
		//在Unity中打印信息的两种方式
		//1.没有继承MonoBehavior类时
		//Debug.Log("日志测试");
		//Debug.LogError("错误测试");
		//Debug.LogWarning("警告测试");

		//2.继承了MonoBehavior类 有一个方法可以使用
		print("Awake");

	}

	//依附的GameObject对象每次激活时调用 OnEnable函数
	//当想要一个对象被激活时 进行一些逻辑处理 就可以写在这个函数里
	private void OnEnable()
	{
		print("OnEnable");
	}
	

	//主要作用类似于Awake,用于初始化,但更晚一些
	//对象被创建出来后,进行第一次帧更新之前才会被执行
	void Start()
	{
		print("State");
		OnEnable();
	}


	//主要用于 进行物理更新
	//它是每一物理帧执行一次
	//它的时间间隔 可以在 project setting中的 Time里去设置
	private void FixedUpdate()
	{
		print("FixedUpdate");
	}

	//主要用于处理游戏核心逻辑更新的函数
	void Update()
	{
		print("Update");
	}

	//在Update之后执行
	//一般这个函数更新用于处理 摄像机位置更新相关内容
	//Update和LateUpdate之间 Unity进行了一些处理 处理动画相关的更新
	private void LateUpdate()
	{
		print("LateUpdate");
	}

	//依附的GameObject对象每次失活时调用 OnDisable函数
	private void OnDisable()
	{

		print("OnDisable");
	}

	//对象销毁时执行,类似于析构函数
	private void OnDestroy()
	{
		print("OnDestroy");
	}
	#endregion
	#region 知识点四 生命周期函数 支持继承多态
	
	#endregion

}

//总结
//这些生命周期函数 如果不打算在其中写逻辑 那就不要写出这些函数

//
