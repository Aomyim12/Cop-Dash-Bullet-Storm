using System.Collections;
using UnityEngine;

public class BossRunner : MonoBehaviour
{
    public float speed = 10f;           // ความเร็วในการวิ่ง
    public float attackRange = 1.5f;    // ระยะการโจมตี
    public int attackDamage = 20;    // ความเสียหายจากการโจมตี
    private Transform player;           // อ้างอิงถึงผู้เล่น
    private bool isRunning = false;     // กำหนดให้ Boss วิ่งหรือไม่

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // ค้นหาผู้เล่น
    }

    void Update()
    {
        // วิ่งไปหาผู้เล่น
        if (isRunning)
        {
            RunTowardsPlayer();
        }

        // ตรวจสอบการโจมตี
        AttackPlayer();
    }

    // ฟังก์ชันที่ทำให้ Boss วิ่งไปที่ผู้เล่น
    void RunTowardsPlayer()
    {
        float step = speed * Time.deltaTime; // ระยะทางที่ Boss วิ่งไปในแต่ละเฟรม
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);
    }

    // ฟังก์ชันตรวจสอบการโจมตี
    void AttackPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange)
        {
            // ถ้า Boss อยู่ในระยะโจมตีให้ทำความเสียหาย
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            Debug.Log("Boss Attack!");
        }
    }

    // ฟังก์ชันนี้จะถูกเรียกเพื่อเริ่มการวิ่งของ Boss
    public void StartRunning()
    {
        isRunning = true;
    }

    // ฟังก์ชันนี้จะหยุดการวิ่ง
    public void StopRunning()
    {
        isRunning = false;
    }
}
