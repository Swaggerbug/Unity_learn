using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lesson3 : MonoBehaviour
{
	public lesson3 otherLesson3;
	private void Start()
	{
		#region 重要成员
		//获取依附的GameObject
		print(this.gameObject.name);
		//获取依附的GameObject的位置信息
		//下面三个效果相同,.gameObject可省略
		print(this.gameObject.transform.position);//位置
		print(this.transform.eulerAngles);//角度
		print(this.transform.lossyScale);//缩放大小

		//获取脚本是否激活
		this.enabled = false;

		//获取别的对象 依附的gameObject和transform信息
		print(otherLesson3.gameObject.name);
		print(otherLesson3.gameObject.transform.position);

		#endregion

		#region 重要方法
		//得到依附对象上挂载的其它脚本

		//1.得到自己挂载的单个脚本
		//根据脚本名获取
		//获取脚本的方法 如果获取失败 会默认返回空
		Lesson3_Test t=this.GetComponent("Lesson3_Test")as Lesson3_Test;
		print(t);
		//根据Type获取
		t=this.GetComponent(typeof(Lesson3_Test))as Lesson3_Test;
		print(t);

		//根据泛型获取建议使用泛型获取因为不用二次转换
		t=this.GetComponent<Lesson3_Test>();
		if (t != null)
		{
			print(t);
		}

		//只要你能得到场景中别的对象或者对象所依附的脚本
		//那你就能获取到它的所有信息

		//2.得到自己挂载的多个脚本
		lesson3[] array=this.GetComponents<lesson3>();
		print(array.Length);

		List<lesson3> list=new List<lesson3>();
		this.GetComponents<lesson3>(list);
		print(list.Count);


		//3.得到子对象挂载的脚本(默认也会在自己身上查找是否挂载该脚本)
		//函数是有一个参数的 默认不传 即为false 意思就是 如果子对象失活 就不会去获取这个对象上的脚本
		//如果传true 即使失活也会获取

		//获取单个子对象挂载的脚本
		t = this.GetComponentInChildren<Lesson3_Test>(true);
		print(t);
		//获取多个子对象挂载的脚本
		Lesson3_Test[] lts = this.GetComponentsInChildren<Lesson3_Test>(true);
		print(lts.Length);

		List<Lesson3_Test> list2 = new List<Lesson3_Test>();
		this.GetComponentsInChildren<Lesson3_Test>(true, list2);
		print(list2.Count);

		//4.得到父对象挂载的脚本
		//没有是否获取失活对象脚本的参数

		//获取单个父对象挂载的脚本
		t = this.GetComponentInParent<Lesson3_Test>();
		print(t);

		//获取多个父对象挂载的脚本
		Lesson3_Test[] lts2=this.GetComponentsInParent<Lesson3_Test>();
		print(lts2.Length);

		List<Lesson3_Test> list3 = new List<Lesson3_Test>();
		this.GetComponentsInParent(true, list3);
		print(list3.Count);

		//5.尝试获取脚本
		Lesson3_Test l3t;
		//提供了一个更加安全的 获取单个脚本的方法 如果得到 会返回true
		//然后再来进行逻辑处理即可
		if(this.TryGetComponent<Lesson3_Test>(out l3t))
		{
			//逻辑处理
		}
		#endregion
	}



}
