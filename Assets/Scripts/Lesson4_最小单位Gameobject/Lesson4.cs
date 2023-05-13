using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
	//准备用来克隆的对象
	//1.直接是场景上的某一个对象
	//2.可以是一个预设体对象
	public GameObject obj;

	private void Start()
	{
		#region GameObject中的成员变量
		//名字 name
		print(this.gameObject.name);
		this.gameObject.name = "Lesson4_修改后的名称";
		print(this.gameObject.name);
		//对象是否激活 
		print(this.gameObject.activeSelf);
		//this.gameObject.SetActive(false);

		//是否为静态 Static
		print(this.gameObject.isStatic);

		//层级 layer
		print(this.gameObject.layer);

		//标签 tag
		print (this.gameObject.tag);

		//位置信息 transform
		print(this.gameObject.transform.position);
		#endregion

		#region GameObject中的静态方法
		//创建自带几何体
		//只要得到了一个GameObject对象 就可以得到它挂载的任何脚本信息
		//通过obj.GetComponent获取脚本信息
		GameObject obj1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		obj1.name = "我在Lesson4里创建的一个立方体";

		//查找对象相关知识


		//一、查找单个对象
		//下面两种方法共同点
		//1.无法找到失活的对象
		//只能找到激活的对象

		//2.如果场景中 存在多个满足条件的对象
		//我们无法准确找到的是哪一个

		//通过对象名查找
		//这个查找效率比较底下 因为他会在场景中所有对象去查找 遍历
		//没有找到返回空
		GameObject obj2 = GameObject.Find("Find测试");
		if(obj2 != null)
		{
			print (obj2.name);
		}
		else
		{
			print("没有找到对应对象");
		}
		//通过tag查找对象
		//GameObject obj3 = GameObject.FindWithTag("Player");
		//GameObject.FindWithTag()与下面的方法效果一样
		GameObject obj3 = GameObject.FindGameObjectWithTag("Player");
		if (obj3 != null)
		{
			print("根据tag找到对象 "+obj3.name);
		}
		else
		{
			print("根据tag没有找到对应对象");
		}

		//得到某一个单个对象 目前有两种方式
		//1.public从外部面板拖 进行关联
		//2.通过API查找

		//二、查找多个对象
		//找多个对象的API 只能是通过tag去找多个 不能通过名字查找多个

		//通过tag找到多个对象
		//它也是 只能找到激活对象 不能找到失活对象 
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
		print("找到tag为Player的对象个数" + objs.Length);

		//还有几个查找对象相关用的比较少的方法 是GameObject的父类 Object提供的方法
		//Unity里的Object 不是指万物之父的Object
		//Unity里的Object 命名空间在UnityEngine中的 Object类 也是继承万物之父的一个自定义类
		//C#中的Object 命名空间是在System中
		//它可以找到场景中挂载的某一个脚本对象
		//这个效率更低 上面的GameObject.Find和FindWithTag查找 只是遍历对象
		//而这个方法 不仅要遍历对象 还要遍历对象上挂载的脚本
		Lesson4 o = GameObject.FindObjectOfType<Lesson4>();

		//三、实例化对象(克隆对象)的方法
		//实例化(克隆)对象 它的作用 是根据一个GameObject对象 创建出一个和它一模一样的对象

		GameObject obj5= GameObject.Instantiate(obj);
		//以后学了更多知识点 就可以在这操作obj5
		//如果你继承了 MonoBehavior 其实可以不用写gameObject.就可以使用
		//因为 这个方法是Unity里面的 Object基类提供给我们的 所以可以直接用
		//Instantiate(obj);

		//四、删除对象的方法
		//第二个参数代表延迟多少秒
		//GameObject.Destroy(obj5,5);
		//Destroy不仅可以删除对象 还可以删除脚本
		//GameObject.Destroy(this);

		//删除对象有两种作用
		//1.删除指定的一个游戏对象
		//2.删除一个指定的脚本对象
		//注意:这个Destroy方法 不会马上移除对象 只是给这个对象加了一个移除标记
		//	一般情况下 它会在下一帧时把这个对象移除并从内存中移除

		//如果没有特殊需求 就是一定要马上移除一个对象的话
		//建议使用上面的Destroy方法 因为是异步的 会降低卡顿的概率
		//下面的方法会立即删除对象
		//GameObject.DestroyImmediate(obj1);

		//如果是继承MonoBehavior的类 不用写GameObject.
		//Destroy(obj5,5);
		//DestroyImmediate(obj1);

		//过场景不移除

		//默认情况 在切换场景时 场景中的对象都会被自动删除掉
		//如果你希望某个对象 过场景不被移除
		//下面这句代码 就是不想谁过场景被移除 就传谁
		//一般都是传 依附的GameObject对象
		//比如下面这句代码的意思 就是自己依附的Gameobject)对象过场景不被删除
		//GameObject.DestroyImmediate(this.gameObject);

		//可以省略GameObject.
		//DestroyImmediate(this.gameObject);
		#endregion

		#region GameObject中的成员方法
		//创建空物体
		//new一个GameObject就是在创建一个空物体
		GameObject obj6 = new GameObject();
		GameObject obj7 = new GameObject("创建物体的名字");
		GameObject obj8 = new GameObject("创建加了脚本的物体", typeof(Lesson4_1),typeof(Lesson4_1));

		//为对象添加脚本
		//继承MonoBehavior的脚本 是不能new的
		//如果想要动态的添加脚本在某一对象上
		//使用GameObject提供的AddComponent()方法
		Lesson4_1 les1 = obj6.AddComponent(typeof(Lesson4_1))as Lesson4_1;
		//用泛型更方便
		obj6.AddComponent<Lesson4_1>();
		//通过返回值 可以得到加入的脚本信息
		//从而进一步处理

		//得到脚本的成员方法 和继承Mono的类得到脚本的方法一模一样 参考Mono
		
		//标签比较
		//下面两种方法是一样的
		if(this.gameObject.CompareTag("Player"))
		{
			print("对象的标签是 Player");
		}
		if (this.gameObject.tag == "Player")
		{
			print("对象的标签是 Player");
		}

		//设置激活失活
		//false 失活
		//true 激活
		obj6.SetActive(false);
		obj7.SetActive(false);
		obj8.SetActive(false);

		//次要的成员方法 了解即可 不建议使用 效率较低
		//通过广播或者发送消息的形式 让自己或别人 执行某些行为方法
		//下面的方法都不建议使用 效率较低

		//通知自己 执行什么行为
		//命令自己 去执行这个TestFun函数 会在自己身上挂载的所有脚本去寻找这个名字的函数
		//它会遍历自己身上所有的脚本 每一个脚本的同名函数都会执行
		this.gameObject.SendMessage("TestFun");
		this.gameObject.SendMessage("TestFun2",2022);

		//广播行为 让自己和自己的子对象执行
		//this.gameObject.BroadcastMessage("函数名");
		//向父对象和自己发送消息 并执行
		//this.gameObject.SendMessageUpwards("函数名");
		#endregion
	}

	void TestFun()
	{
		print("Lesson4的TestFun");
	}
	void TestFun2(int a)
	{
		print("Lesson4的TestFun,参数为" + a);
	}

	//总结
	//Gameobject的常用内容
	//基本成员变量
	//名字失活激活状态标签层级等等

	//静态方法相关
	//创健自带几何体
	//查找场景中对象
	//实例化对像
	//删除对象
	//过场景不移除

	//成员方法
	//为对象动态添加指定脚本
	//设置失活激活的状态
	//和MonoBehavior中相同的得到脚本相关的方法

}
