using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_TestEnum
{
	Normal, Player, Monster
}

[System.Serializable]
public struct MyStruct
{
	public int age;
	public string name;
}

[System.Serializable]
public class Myclass
{
	public int age;
	public string name;
}

public class lesson2 : MonoBehaviour
{
	#region Inspector显示的可编辑内容就是脚本的成员变量

	#endregion

	#region 知识点一 私有和保护无法显示编辑
	private int i1;
	protected string str2;
	#endregion

	#region 知识点二 让私有的和保护的也可以被显示
	//加上强制序列化字段特性
	//[SerializeField]
	//所谓序列化就是把一个对象保存到一个文件或数据库去
	[SerializeField]
	private int privateInt;
	[SerializeField]
	protected string protectedStr;
	#endregion

	#region 知识点三 公共的可以显示编辑
	public int publicInt = 10;
	public bool publicBool = false;
	#endregion

	#region 知识点四 公共的也不让其显示编辑
	//在变量前加上特性
	//[HideInInspector]

	[HideInInspector]
	public bool publicBool2 = false;
	#endregion

	#region 知识点五 大部分类型都能显示编辑
	public int[] array;
	public List<int> list;
	public E_TestEnum type;
	public GameObject gameObj;

	//字典不能被Inspector窗口显示
	public Dictionary<int, string> dic;
	//自定义类型变量
	public Myclass myclass;
	public MyStruct myStruct;


	#endregion

	#region 知识点六 让自定义类型可以被访问
	//加上序列化特性
	//[System.Serializable]
	//字典怎么样都不行
	#endregion

	#region 知识点七 一些辅助特性
	//1.分组说明特性Header
	//为成员分组
	//Header特性
	//[Header("分组说明")]

	[Header("基础属性")]
	public int age;
	public bool sex;
	[Header("战斗属性")]
	public int atk;
	public int dif;

	//2.悬停注释Tooltip
	//为变量添加说明
	//[Tooltip("说明内容")]
	[Tooltip("闪避")]
	public int miss;

	//3.间隔特性Space（）
	//让两个字段间出现间隔
	//[Space（）]
	[Space()]
	public int crit;

	//4.修饰数值的滑条范围Range
	//[Range(最小值，最大值)]
	[Range(0, 10)]
	public int luck;

	//5.多行显示字符串 默认不写参数显示3行
	//写参数就是对应行
	//[Multiline(行数)]
	[Multiline(4)]
	public string tips;

	//滚动显示字符串
	//默认不写参数就是超过3行显示滚动条
	//[TextArea(3,4)]  
	//最少显示3行,最多4行,超过4行就显示滚动条

	[TextArea(3, 4)]
	public string mylife;

	//为变量添加快捷方法 ContextMenuItem
	//参数1:显示按钮名
	//参数2:方法名 不能有参数
	//[ContextMenuItem("显示按钮名","方法名")]
	[ContextMenuItem("将钱设置为100", "Test")]
	public int money;
	private void Test()
	{
		money = 100;
	}

	//8.为方法添加特性能够在Inspector窗口中执行
	//[ContextMenu("测试函数")]
	[ContextMenu("调用测试方法")]
	private void TestFun()
	{
		print("测试方法");
	}

	#endregion

	#region 注意
	//1.Inspector窗口中的变量关联的就是对象的成员变量，运行时改变他们就是在改变成员变量

	//1.拖曳到GameObject对象后再改变脚本中变量默认值界面上不会改变
	//2.运行中修改的信息不会保存
	#endregion

	private void Start()
	{
		print(privateInt);
		print(protectedStr);
	}
}
