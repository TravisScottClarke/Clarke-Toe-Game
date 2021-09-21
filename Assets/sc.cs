using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour
{
    public GameObject difselc;
    public int Health;
    public int Maxhealth;
    public GameObject txthealth;
    public GameObject proj;
    public GameObject proj2;
    public GameObject proj3;
    public GameObject proj4;
    public GameObject proj5;
    public GameObject proj6;
    public GameObject projlaser;
    public GameObject Plr;
    public GameObject Tower1;
    public GameObject Tower2;
    public GameObject Tower3;
    public GameObject Tower4;
    public GameObject Tower5;
    public GameObject Tower6;
    public GameObject Tower7;
    public GameObject Tower8;
    private int w;
    public int phase = 1;
    bool towersmove = false;
    string stg;
    int cont;
    public GameObject doggo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        txthealth.GetComponent<UnityEngine.UI.Text>().text = "Clarke HP:" + Health + "/" + Maxhealth;
        if(Health <=0)
        {
            Destroy(gameObject);
        }
        if (phase == 1)
        {
            Vector2 target = Plr.transform.position;
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
            Vector2 direction = target - myPos;
            direction.Normalize();
            if (w >= 500)
            {
                Tower1.GetComponent<Fire>().ON = true;
                Tower2.GetComponent<Fire>().ON = true;
                Tower3.GetComponent<Fire>().ON = true;
                Tower4.GetComponent<Fire>().ON = true;
                Tower5.GetComponent<Fire>().ON = true;
                Tower6.GetComponent<Fire>().ON = true;
                Tower7.GetComponent<Fire>().ON = true;
                Tower8.GetComponent<Fire>().ON = true;
                this.GetComponent<Rigidbody2D>().velocity = direction * 10;

                if (Health <= 900)
                {
                    phase = 2;
                    cont = 0;

                }
                if (cont < 100)
                {
                    fire_2(Plr.transform.position, 50,100);
                }
                else if (cont >= 100)
                {

                    if (towersmove == true)
                    {
                        fire_1(Tower1.transform.position, 100);
                        fire_1(Tower2.transform.position, 100);
                        fire_1(Tower3.transform.position, 100);
                        fire_1(Tower4.transform.position, 100);
                        fire_2(Plr.transform.position, 50,500);


                    }
                    else if (towersmove == false)
                    {
                        fire_1(Tower5.transform.position, 100);
                        fire_1(Tower6.transform.position, 100);
                        fire_1(Tower7.transform.position, 100);
                        fire_1(Tower8.transform.position, 100);
                        fire_2(Plr.transform.position, 50, 100);

                    }

                    if (cont > 300)
                    {
                        cont = 0;
                        towersmove = !towersmove;
                    }

                }
                cont += 1;
            }
            if (w < 500)
            {
                w += 1;
            }
        }
        else if(phase == 2)
        {
            gameObject.transform.position = Tower1.transform.position;

            if (Health<=800)
           {
                phase = 3;
                Tower1.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Tower1.GetComponent<Fire>().ON = false;
                makedog(gameObject.transform.position);
                cont = 0;
            }
            phase2firecrap();
            

        }
        else if (phase == 3)
        {
            if (Health <= 700)
            {
                phase = 4;
                Tower2.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Tower2.GetComponent<Fire>().ON = false;
                makedog(gameObject.transform.position);

            }
            phase3firecrap();
            gameObject.transform.position = Tower2.transform.position;

        }
        else if(phase ==4)
        {
            if (Health <= 600)
            {
                phase = 5;
                Tower3.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Tower3.GetComponent<Fire>().ON = false;
                makedog(gameObject.transform.position);
            }
            phase4firecrape();
            gameObject.transform.position = Tower3.transform.position;

        }
        else if(phase == 5)
        {
            if (Health <= 500)
            {
                phase = 6;
                Tower4.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Tower4.GetComponent<Fire>().ON = false;
                makedog(gameObject.transform.position);
            }
            phase5firecrap();
            gameObject.transform.position = Tower4.transform.position;

        }
        else if (phase == 6)
        {
            if (Health <= 400)
            {
                phase = 7;
                Tower5.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Tower5.GetComponent<Fire>().ON = false; makedog(gameObject.transform.position);
                makedog(gameObject.transform.position);
            }
            phase6firecrap();
            gameObject.transform.position = Tower5.transform.position;

        }
        else if (phase == 7)
        {
            if (Health <= 300)
            {
                phase = 8;
                Tower6.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Tower6.GetComponent<Fire>().ON = false; makedog(gameObject.transform.position);
                makedog(gameObject.transform.position);
            }
            phase7firecrap();
            gameObject.transform.position = Tower6.transform.position;

        }
        else if (phase == 8)
        {
            if (Health <= 200)
            {
                phase = 9;
                Tower7.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Tower7.GetComponent<Fire>().ON = false; makedog(gameObject.transform.position);
                makedog(gameObject.transform.position);
            }
            phase8firecrap();
            gameObject.transform.position = Tower7.transform.position;

        }
        else if (phase == 9)
        {
            if (Health <= 100)
            {
                phase = 10;
                Tower8.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Tower8.GetComponent<Fire>().ON = false; makedog(gameObject.transform.position);
                makedog(gameObject.transform.position);
                cont = 0;
            }
            fire_2(Plr.transform.position, 20, 10.0f);
            gameObject.transform.position = Tower8.transform.position;

        }
        else if (phase == 10)
        {
            if(cont<=100)
            {
                Vector2 target = Tower1.transform.position;
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                this.GetComponent<Rigidbody2D>().velocity = direction * 100;
            }
            else if (cont <= 300)
            {
                Vector2 target = Tower2.transform.position;
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                this.GetComponent<Rigidbody2D>().velocity = direction * 100;
            }
            else if (cont <= 500)
            {
                Vector2 target = Tower3.transform.position;
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                this.GetComponent<Rigidbody2D>().velocity = direction * 100;
            }
            else if (cont <= 700)
            {
                Vector2 target = Tower4.transform.position;
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                this.GetComponent<Rigidbody2D>().velocity = direction * 100;
            }
            else if (cont <= 800)
            {
                Vector2 target = Tower5.transform.position;
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                this.GetComponent<Rigidbody2D>().velocity = direction * 100;
            }
            else if (cont <= 900)
            {
                Vector2 target = Tower6.transform.position;
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                this.GetComponent<Rigidbody2D>().velocity = direction * 100;
            }
            else if (cont <= 1000)
            {
                Vector2 target = Tower7.transform.position;
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                this.GetComponent<Rigidbody2D>().velocity = direction * 100;
            }
            else if (cont <= 1200)
            {
                Vector2 target = Tower8.transform.position;
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                this.GetComponent<Rigidbody2D>().velocity = direction * 100;
            }
            else if (cont <= 1400)
            {
                gameObject.transform.position = new Vector2(-601.16f, -572.57f);
            }
            else if (cont <= 1600)
            {
                cont = 0;
            }
            cont += 1;
            fire_2(Plr.transform.position, 150, 10.0f);
        }

    }
  

        void fireingTyper()
    {

    }
        void fire_1(Vector2 pos,int speed)
        {
        int xcount = Random.Range(1, 6);
        GameObject projrand = proj;
        if (xcount == 1)
        {
            projrand = proj;
        }
        if (xcount == 2)
        {
            projrand = proj2;
        }
        if (xcount == 3)
        {
            projrand = proj3;
        }
        if (xcount == 4)
        {
            projrand = proj4;
        }
        if (xcount == 5)
        {
            projrand = proj5;
        }
        if (xcount == 6)
        {
            projrand = proj6;
        }
        Vector2 target = pos;
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * 180);
            GameObject projectile = (GameObject)Instantiate(projrand, myPos, rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
            Destroy(projectile, 2.0f);


        }
    void fire_2(Vector2 pos, int speed,float durration)
    {
        Vector2 target = pos;
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x)*45);
        GameObject projectile = (GameObject)Instantiate(projlaser, myPos, rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        Destroy(projectile, durration);
    }

    void phase2firecrap()
    {
        if (cont < 200)
        {
            fire_1(Tower1.transform.position, 100);
            fire_1(Tower2.transform.position, 100);
            fire_1(Tower3.transform.position, 100);
            fire_1(Tower4.transform.position, 100);
            fire_1(Tower5.transform.position, 100);
            fire_1(Tower6.transform.position, 100);
            fire_1(Tower7.transform.position, 100);
            fire_1(Tower8.transform.position, 100);
            fire_2(Plr.transform.position, 20, 10.0f);
        }
        else if (cont >= 200)
        {

            if (towersmove == true)
            {
                fire_1(Tower1.transform.position, 100);
                fire_1(Tower2.transform.position, 100);
                fire_1(Tower3.transform.position, 100);

                fire_1(Tower4.transform.position, 100);
                fire_2(Plr.transform.position, 20, 10.0f);
            }
            else if (towersmove == false)
            {
                fire_1(Tower5.transform.position, 100);
                fire_1(Tower6.transform.position, 100);
                fire_1(Tower7.transform.position, 100);
                fire_1(Tower8.transform.position, 100);
                fire_2(Plr.transform.position, 20, 10.0f);
            }

            if (cont > 300)
            {
                cont = 0;
                towersmove = !towersmove;
            }

        }
        cont += 1;
    }
    void phase3firecrap()
    {
        if (cont < 200)
        {
            fire_1(Tower2.transform.position, 100);
            fire_1(Tower3.transform.position, 100);
            fire_1(Tower4.transform.position, 100);
            fire_1(Tower5.transform.position, 100);
            fire_1(Tower6.transform.position, 100);
            fire_1(Tower7.transform.position, 100);
            fire_1(Tower8.transform.position, 100);
            fire_2(Plr.transform.position, 20, 10.0f);
        }
        else if (cont >= 200)
        {

            if (towersmove == true)
            {
                fire_1(Tower2.transform.position, 100);
                fire_1(Tower3.transform.position, 100);
                fire_1(Tower4.transform.position, 100);
                fire_2(Plr.transform.position, 20, 10.0f);
            }
            else if (towersmove == false)
            {
                fire_1(Tower5.transform.position, 100);
                fire_1(Tower6.transform.position, 100);
                fire_1(Tower7.transform.position, 100);
                fire_1(Tower8.transform.position, 100);
                fire_2(Plr.transform.position, 20, 10.0f);
            }

            if (cont > 300)
            {
                cont = 0;
                towersmove = !towersmove;
            }

        }
        cont += 1;
    }
    void phase4firecrape()
    {
        if (cont < 200)
        {
            fire_1(Tower4.transform.position, 100);
            fire_1(Tower5.transform.position, 100);
            fire_1(Tower6.transform.position, 100);
            fire_1(Tower7.transform.position, 100);
            fire_1(Tower8.transform.position, 100);
            fire_2(Plr.transform.position, 20, 10.0f);
        }
        else if (cont >= 200)
        {

            if (towersmove == true)
            {
                fire_1(Tower4.transform.position, 100);
                fire_2(Plr.transform.position, 20, 10.0f);
            }
            else if (towersmove == false)
            {
                fire_1(Tower5.transform.position, 100);
                fire_1(Tower6.transform.position, 100);
                fire_1(Tower7.transform.position, 100);
                fire_1(Tower8.transform.position, 100);
                fire_2(Plr.transform.position, 20, 10.0f);
            }

            if (cont > 300)
            {
                cont = 0;
                towersmove = !towersmove;
            }

        }
        cont += 1;

    }
    void phase5firecrap()
    {
        if (cont < 200)
        {
            fire_1(Tower4.transform.position, 100);
            fire_1(Tower5.transform.position, 100);
            fire_1(Tower6.transform.position, 100);
            fire_1(Tower7.transform.position, 100);
            fire_1(Tower8.transform.position, 100);
            fire_2(Plr.transform.position, 20, 10.0f);
        }
        else if (cont >= 200)
        {

            if (towersmove == true)
            {
                fire_1(Tower4.transform.position, 100);
                fire_2(Plr.transform.position, 20, 10.0f);
            }
            else if (towersmove == false)
            {
                fire_1(Tower5.transform.position, 100);
                fire_1(Tower6.transform.position, 100);
                fire_1(Tower7.transform.position, 100);
                fire_1(Tower8.transform.position, 100);
                fire_2(Plr.transform.position, 20, 10.0f);
            }

            if (cont > 300)
            {
                cont = 0;
                towersmove = !towersmove;
            }

        }
        cont += 1;
    }
    void phase6firecrap()
    {
        if (cont < 200)
        {
            fire_1(Tower5.transform.position, 100);
            fire_1(Tower6.transform.position, 100);
            fire_1(Tower7.transform.position, 100);
            fire_1(Tower8.transform.position, 100);
            fire_2(Plr.transform.position, 20, 10.0f);
        }
        else if (cont >= 200)
        {

            if (towersmove == true)
            {
                fire_2(Plr.transform.position, 20, 10.0f);
            }
            else if (towersmove == false)
            {
                fire_1(Tower5.transform.position, 100);
                fire_1(Tower6.transform.position, 100);
                fire_1(Tower7.transform.position, 100);
                fire_1(Tower8.transform.position, 100);
                fire_2(Plr.transform.position, 20, 10.0f);
            }

            if (cont > 300)
            {
                cont = 0;
                towersmove = !towersmove;
            }

        }
        cont += 1;
    }
    void phase7firecrap()
    {
        if (cont < 200)
        {
            fire_1(Tower6.transform.position, 100);
            fire_1(Tower7.transform.position, 100);
            fire_1(Tower8.transform.position, 100);
            fire_2(Plr.transform.position, 20, 10.0f);
        }
        else if (cont >= 200)
        {

            if (towersmove == true)
            {
                fire_2(Plr.transform.position, 20, 10.0f);
            }
            else if (towersmove == false)
            {
                fire_1(Tower6.transform.position, 100);
                fire_1(Tower7.transform.position, 100);
                fire_1(Tower8.transform.position, 100);
                fire_2(Plr.transform.position, 20, 10.0f);
            }

            if (cont > 300)
            {
                cont = 0;
                towersmove = !towersmove;
            }

        }
        cont += 1;
    }
    void phase8firecrap()
    {
        if (cont < 200)
        {
            fire_1(Tower7.transform.position, 100);
            fire_1(Tower8.transform.position, 100);
            fire_2(Plr.transform.position, 20, 10.0f);
        }
        else if (cont >= 200)
        {

            if (towersmove == true)
            {
                fire_2(Plr.transform.position, 20, 10.0f);
            }
            else if (towersmove == false)
            {
                fire_1(Tower7.transform.position, 100);
                fire_1(Tower8.transform.position, 100);
                fire_2(Plr.transform.position, 20, 10.0f);
            }

            if (cont > 300)
            {
                cont = 0;
                towersmove = !towersmove;
            }

        }
        cont += 1;
    }


    void makedog(Vector2 pos)
    {

        GameObject doge1 = (GameObject)Instantiate(doggo, pos, gameObject.transform.rotation);
        doge1.GetComponent<fOLLWpLAYER>().act = true;

    }
}
