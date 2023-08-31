using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

public class FloorController : MonoBehaviour
{

    // 摄像机
    private GameObject main_camera = null;

    // 初始位置
    private Vector3 initial_position;

    // 地面的宽度（X方向）
    public const float WIDTH = 10.0f * 1.0f;

    // 地面模型的数量
    public const int MODEL_NUM = 3;


    // Start is called before the first frame update
    void Start()
    {
        // 查找摄像机的实例对象
        this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");

        this.initial_position = this.transform.position;

        this.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 生成无限循环地面



		// 修改后，玩家移动时也不会出问题的方法

		// 背景全体（所有的模型并列）的宽度
		//
		float		total_width = FloorController.WIDTH * FloorController.MODEL_NUM;
        Debug.Log("total_width:" + total_width);
        Vector3		camera_position = this.main_camera.transform.position;
        //Debug.Log("camera_position:" + camera_position);
        Debug.Log("this.initial_position.x:" + this.initial_position.x);
        float		dist = camera_position.x - this.initial_position.x;

		// 模型出现在total_width 的整数倍位置
		// 用初始位置的距离除以整体背景的宽度，再四舍五入

		int			n = Mathf.RoundToInt(dist/total_width);
        Debug.Log("n:"+n);
		Vector3		position = this.initial_position;

		position.x += n*total_width;
        Debug.Log("position:" + position);
        this.transform.position = position;

    }
}
