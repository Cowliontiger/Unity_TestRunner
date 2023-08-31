using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    // 玩家对象
    private GameObject player = null;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

        // 查找玩家地实例对象
        this.player = GameObject.FindGameObjectWithTag("Player");

        this.offset = this.transform.position - this.player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // 和玩家一起移动
        this.transform.position = new Vector3(player.transform.position.x + this.offset.x, this.transform.position.y, this.transform.position.z);
    }
}
