using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clicker_Player : MonoBehaviour
{
    public float lifePlayer = 50f;
    public float lifePlayerMax = 50f;
    public float lifeToAdd = 3f;

    public float lifeUpgrade = 10f;
    public float lifeUpgradeRemove = 25f;
    public float lifeMaxPrice = 25f;
    
    public float attackValue = 3f;
    public float attackUpgradeRemove = 15f;

    public float nmbrEnemyKilled = 0f;
    public float nmbrEnemySwitch = 0f;

    public float currentEnnemyLife = 10f;
    public float ennemyLife = 10f;

    private GameObject ennemyToDestroy;

    public GameObject ennemyKappa;
    public GameObject ennemyTengu;
    public GameObject ennemyTsuchigumo;
    public GameObject ennemyOni;
    public GameObject ennemySuzammo;

    public GameObject transformEnnemy;

    public bool isOK = true;
    //

    public Animator animCharacter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Example());
        GameObject newEnnemyToDestroy = Instantiate(ennemyKappa);
        newEnnemyToDestroy.transform.position = transformEnnemy.transform.position;
        ennemyToDestroy = newEnnemyToDestroy;
        //animCharacter.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (lifePlayer <= 0f)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    public void OnClickUpgradeAttack()
    {
        animCharacter.enabled = true;
        lifeToAdd = lifeToAdd * 1.5f;
        attackValue = attackValue * 1.5f;
        lifePlayer -= attackUpgradeRemove;
        attackUpgradeRemove = attackUpgradeRemove * 1.5f;
    }

    public void OnClickUpgradeLife()
    {
        lifePlayerMax = lifePlayerMax += lifeUpgrade;
        lifePlayer = lifePlayer -= lifeUpgradeRemove;
        lifeUpgrade = lifeUpgrade * 1.5f;
        lifeUpgradeRemove = lifeUpgradeRemove * 1.5f;
    }

    public void OnClickEnemy()
    {
        if (lifePlayer < lifePlayerMax)
        {
            ParticlePlay.Singleton2.launchVFX();
            lifePlayer = lifePlayer += lifeToAdd;
            currentEnnemyLife -= attackValue;
            CheckDead();
        }
        else if (lifePlayer == lifePlayerMax)
        {
            ParticlePlay.Singleton2.launchVFX();
            currentEnnemyLife -= attackValue;
            CheckDead();
        }
        else if (lifePlayer > lifePlayerMax)
        {
            ParticlePlay.Singleton2.launchVFX();
            lifePlayer = lifePlayerMax;
            currentEnnemyLife -= attackValue;
            CheckDead();
        }
    }

    public void CheckDead()
    {
        if (currentEnnemyLife <= 0f)
        {
            nmbrEnemyKilled += 1f;
            currentEnnemyLife = ennemyLife;
            ennemyLife = ennemyLife * 1.5f;
            Destroy(ennemyToDestroy);
            if (nmbrEnemySwitch == 10f)
            {
                nmbrEnemyKilled = 0f;
                GameObject newEnnemyToDestroy = Instantiate(ennemySuzammo);
                newEnnemyToDestroy.transform.position = transformEnnemy.transform.position;
                ennemyToDestroy = newEnnemyToDestroy;
            }
            else
            {
                if (nmbrEnemyKilled <= 3)
                {
                    GameObject newEnnemyToDestroy = Instantiate(ennemyKappa);
                    newEnnemyToDestroy.transform.position = transformEnnemy.transform.position;
                    ennemyToDestroy = newEnnemyToDestroy;
                }
                else if (nmbrEnemyKilled >= 8)
                {
                    GameObject newEnnemyToDestroy = Instantiate(ennemyOni);
                    newEnnemyToDestroy.transform.position = transformEnnemy.transform.position;
                    ennemyToDestroy = newEnnemyToDestroy;
                }
                else if (nmbrEnemyKilled > 3 && nmbrEnemyKilled < 6)
                {
                    GameObject newEnnemyToDestroy = Instantiate(ennemyTengu);
                    newEnnemyToDestroy.transform.position = transformEnnemy.transform.position;
                    ennemyToDestroy = newEnnemyToDestroy;
                }
                else if (nmbrEnemyKilled > 6 && nmbrEnemyKilled < 8)
                {
                    GameObject newEnnemyToDestroy = Instantiate(ennemyTsuchigumo);
                    newEnnemyToDestroy.transform.position = transformEnnemy.transform.position;
                    ennemyToDestroy = newEnnemyToDestroy;
                }
            }
        }
    }

    IEnumerator Example()
    {
        while (isOK == true)
        {
            yield return new WaitForSeconds(1);
            lifePlayer -= 1f;
        }
    }
}
