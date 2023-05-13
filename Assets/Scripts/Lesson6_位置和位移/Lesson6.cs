using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    void Start()
    {
		#region Transform主要用来干嘛?
		//游戏对象(GameObject)位移、旋转、缩放、父子关系、坐标转换等相关操作都由它处理
		//它是Unity提供的极其重要的类
		#endregion

		#region 必备知识点 Vector3基础
		//Vector3主要是用来表示三维坐标系中的 一个点 或者一个向量
		//申明
		Vector3 v = new Vector3();
		v.x = 10;
		v.y = 10;
		v.z = 10;

		//传参按xyz排序 不传默认为0;
		Vector3 v2 = new Vector3(10,10);

		//一步到位
		Vector3 v3 = new Vector3(10,10,10);

		Vector3 v4;
		v4.x = 10;
		v4.y = 10;
		v4.z = 10;


		//Vector的基本计算
		//+ - * /
		Vector3 v1 = new Vector3(1,1,1);
		Vector3 v12 = new Vector3(2,2,2);
		print(v1+ v12);
		print(v1- v12);

		print(v1*10);
		print(v12/2);
		//常用
		print(Vector3.zero);///0,0,0
		print(Vector3.right);//1,0,0
		print(Vector3.left);//-1,0,0
		print(Vector3.forward);//0,0,1
		print(Vector3.back);//0,0,-1
		print(Vector3.up);//0,1,0
		print(Vector3.down);//0,-1,0

		//常用方法
		//计算两个点之间的距离
		Vector3.Distance(v1, v12);
		#endregion

		#region 知识点二 位置
		//相对世界坐标系

		//通过position得到的位置 是相对于 世界坐标系的 原点的位置
		//可能和面板上显示的不同
		//因为如果对象有父子关系 并且父对象位置不在原点 那么 和面板上的肯定就是不一样的
		//this.gameObject.transform
		print(this.transform.position);

		//相对父对象
		//这两个坐标 对于我们来说 很重要 如果你想以面板坐标为准来进行位置设置
		//那一定是通过localPosition来进行设置的
		print(this.transform.localPosition);

		//上面两个 数值可能是相同的
		//1.在父对象位于世界坐标系中心(0,0,0)时
		//2.对象没有父对象时

		//注意:位置的赋值不能直接改变x,y,z 只能整体改变
		//不能单独改 x y z某一个值 下面这样会报错
		//this.transform.position.x = 10;
		this.transform.position = new Vector3(10,10,10);
		this.transform.localPosition = Vector3.up*10;
		//如果只想改一个值 其他值保持与原有一致
		//1.直接赋值
		this.transform.position=new Vector3(19,this.transform.position.y, this.transform.position.z);
		//2.先取出来 再赋值
		//虽然不能直接改 transform的 xyz 但是 Vector3是可以直接改 xyz的
		//所以可以先取出来改Vector3 再重新赋值
		Vector3 vPos=this.transform.localPosition;
		vPos.x = 10;
		this.transform.localPosition=vPos;

		//对象当前的各朝向
		//如果你想得到对象当前的 朝向
		//那么就是通过 transform.出来的
		//对象当前的面朝向
		print(this.transform.forward);
		//对象当前的头顶朝向
		print(this.transform.up);
		//对象当前的右边
		print(this.transform.right);

		#endregion
	}
	private void Update()
	{
		#region 知识点三 位移
		//理解坐标系下的位移计算公式
		//路程 = 方向 * 速度 * 时间

		//方式一 自己计算
		//想要变化的 就是 position

		//用当前的位置 + 我要动多长距离  得出最终所在的位置
		//this.transform.position = this.transform.position + this.transform.forward * 1 * Time.deltaTime;

		//因为用的是 this.transform.forward 所以它始终会朝向相对于自己的面朝向去动
		//this.transform.position += this.transform.forward * 1 * Time.deltaTime;

		//方向非常重要 因为 它决定了你的前进方向
		//this.transform.position += Vector3.forward * 1 * Time.deltaTime;

		//方式二 API (重要)
		//参数一:表示位移多少		路程 = 方向 * 速度 * 时间
		//参数二:表示 相对坐标系 (默认该参数 是相对于自身坐标系的)

		//1.相对于世界坐标系的 z轴 运动
		//this.transform.Translate(Vector3.forward * 1 * Time.deltaTime,Space.World);

		//2.相对于世界坐标系的 自己的面朝向去动
		//this.transform.Translate(this.transform.forward * 1 * Time.deltaTime,Space.World);


		//3.相对于自己坐标系的 自己的面朝向去动 (通常不会这样让物体移动)
		//this.transform.Translate(this.transform.forward * 1 * Time.deltaTime,Space.Self);

		//4.相对于自己坐标系的 z轴正方向 运动
		//this.transform.Translate(Vector3.forward * 1 * Time.deltaTime,Space.World);


		//注意 一般使用API来进行位移

		#endregion
	}

	//总结
	//Vector3
	//如何申明 提供的 常用静态属性 和一个 计算距离的方法
	//位置
	//相对于世界坐标系 和 相对于父对像 这两个坐标的区别
	//不能够单独修改 xyz 只能一起统一改
	//位移
	//自己如何计算来进行位移
	//API是哪个方法 来进行位移 使用时 要注意
}
