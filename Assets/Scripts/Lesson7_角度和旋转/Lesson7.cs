using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7 : MonoBehaviour
{
    void Start()
    {
		#region 知识点一 角度相关
		//相对世界坐标角度
		print(this.transform.eulerAngles);

		//相对父对象角度
		print(this.transform.localEulerAngles);

		//注意:设置角度和设置位置一样 不能单独设置xyz 要一起设置
		//错误:this.transform.localEulerAngles.x = 10;
		//如果我们希望改变的 角度 是面板上显示的内容 那就改变 相对父对象的角度
		//this.transform.localEulerAngles = new Vector3(10,10,10);
		//this.transform.eulerAngles = new Vector3(10,10,10);

		print(this.transform.localEulerAngles);

		#endregion
	}


	void Update()
    {
		#region 知识点二 旋转相关
		//自己计算 (和位置(Lesson6中)类似 不停改变角度即可)

		//API计算
		//自转
		//每个轴 具体转多少度
		//第一个参数 相当于每一帧旋转的角度
		//第二个参数 不填 默认相对于自己坐标系进行旋转
		//this.transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime);
		//this.transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime,Space.World);

		//相对于某个轴 转多少度
		//参数一:相对于哪个轴进行转动
		//参数二:转动的角度
		//参数三:不填 默认相对于自己的坐标系进行旋转
		//		如果添 可以填写Space.World 相对于世界坐标系进行旋转
		//this.transform.Rotate(Vector3.right,10 * Time.deltaTime);
		//this.transform.Rotate(Vector3.right, 10 * Time.deltaTime, Space.World);


		//相对于某一个点转
		//参数一:相对于哪一个点 转
		//参数二:相对于哪一个点的 哪一个轴转
		//参数三:转的度数 旋转速度*时间
		this.transform.RotateAround(Vector3.zero,Vector3.right, 10 * Time.deltaTime);

		#endregion
	}
	//总结
	//角度相关和位置相关 差不多
	//如何得到角度
	//通过transform 可以得到相对于世界坐标系和相对于父对象的

	//如何自转和绕着别人转
	//Rotate
	//RotateAround
}
