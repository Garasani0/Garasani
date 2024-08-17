using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;
using System.Net.Mail;
using TMPro;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System;
//"�����ߴ�"�� ���� ���� �ڿ� �����ϸ� ��
//"player"�� customize.playername ������ �� 

public class npc : MonoBehaviour
{
    public TMP_Text content;
    public GameObject talksqu;
    public GameObject button;
    public TMP_Text who;
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;
    public TMP_Text option4;
    public TMP_Text option5;
    public TMP_Text option6;
    //
    //public TMP_Text exit;

    public GameObject options;
    public GameObject option3_bt;
    public GameObject option4_bt;
    public GameObject option5_bt;
    public GameObject option6_bt;
    public static int clofirst = 0;
    public static int manjufirst = 0;
    public static int jihoonflag = 0;
    public static int optnum = 0;
    public static int glass = 0;//�κ��丮�� �Ȱ��� ������ 1�� �����ϸ� �ȴ�. 
    public static int glassinter = 0; //�� �� ���ο��� �Ȱ��� ������ ������ 
    public static int sibiinter = 0;
    public static int jobinter = 0;
    public static string interobj;
    public static string presentcol;
    public static int buttonnum = 0;


    public int playercolflag = 0;
    string[] weildcontent = new string[8] { "���� ���� ����.", "���� ���� ���ٴϱ�?", "....", "�׳༮���� ���� �ΰ� ����.", "�׳༮���� ���� �ΰ� ����.", "�ڽ� ������ Ű������ �� �ҿ���ٴ���...", "....", "�� �ٱ���....���� ���״���?" };
    string[] helpcontent = new string[5] { "�̻��ϴ�...�Ȱ��� ���� ��� �־��µ�.....", "��...�л�. Ȥ�� �� �Ȱ� �� �þ��?", "�̻��ϳ�...", "�츮 ���ֶ� �� ��ҳ�....", "�츮 ���� ���Ƽ� �ִ� �ž�..." };
    string[] objcontent = new string[1] { "................." };
    string[] angercontent = new string[3] { "����,�ű�!", "���� ��� �ΰ� �ٴϴ� �ž�?", "��." };
    string[] manjucontent = new string[4] {"����,���� ��������...","���γ�.","......","����....���л��� ���� ���� �ְھ��~"};
    string[] clocontent = new string[3] { "���ο�, �мǿ� ���� �����Ű�����? ������!","�����̰͵� ��� ���ϻ󰡿��� �� �Űŵ��~","���ο��� �� �����ٴϱ�?" };
    string[] jihoonfirst = new string[6] { "���ξ�, �ȳ�?", "�������ƾƾƾƾ�!!", "���ξ����� �ƺ��� ��𰡼̾�?", "���Ƹ���...�����ƾ�....", "���ƾ����� �� ����... ��....", "���ι̾ư�����...��ұ��?" };
    string[] stationcontent = new string[4] { "���ξ�, ����ϼ̳�...", "....", "���θ��������� ������ ��� ��������� ��ﳪ?","����(��������)" };
    string[] jobcontent = new string[2] { "�� ������, ������ �峭�� �ֽ��ϴ�. 360���� ���ư��� �̴ϴ�. \n�� ģȯ�� LED ", "����...����." };
    string[] godcontent = new string[8] { "������. ���� �����Բ����� �� �ϳ��� ����\n ���ڰ��� ���� ���� ���ư��ð�....","���ξ�", "����,�翬��! ��¥ �ƴϰڽ��ϱ�. �ϳ��Բ��� �����ϻ�....", "PL�װ� ��¥����? �ƴ� �� ������....", "����(�Ȼ��� �ķ�����)", "PL�׷� �� ����...", "��������,�˼��մϴ�.", "....." };
    //string[] jihoonfirst = new string[] = {"���ξ�, �ȳ�?","�������ƾƾƾƾƾ�!!","���ξ����� �ƺ��� ��𰡼̾�?","���Ƹ���...�����ƾ�...","���ƾ����� �� ����... ��....","���ι̾ư�����...��ұ��?","��1�̸��� �����","��2���� ���� �ǳٴ�")
    private void OnCollisionEnter2D(Collision2D collision)
    {

       
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 1;
            presentcol = gameObject.name;

            
        }
    }

   
    public void option1down()
    {
        optnum = 1;
        
        
        option1.text = "";
        option2.text = "";
       
        if (option3_bt!=null&&option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }
        }
        if (option4_bt != null && option4_bt.activeSelf)
        {
            if (option4 != null)
            {
                option4.text = "";
            }
        }
        if (option5_bt != null && option5_bt.activeSelf)
        {
            if (option5 != null)
            {
                option5.text = "";
            }
        }
        if (option6_bt != null && option6_bt.activeSelf)
        {
            if (option6 != null)
            {
                option6.text = "";
            }
        }



        if (interobj=="�������� ����")
        {
            if(manjufirst!=1)
            {
                who.text = "Player";
                content.text = "�� �ٱ��?";
                button.SetActive(true);
                buttonnum = 0;

            }
            else
            {
                who.text = "system";
                content.text = "�������긦 �����ߴ�.";
               
            }
            
            

        }

        if (interobj == "�� ����")
        {
            
            
             who.text = "system";
             content.text = "¯�� ����� �����ߴ�.";
             button.SetActive(true);
             buttonnum = 0;



        }

        if (interobj == "������")
        {
            who.text = "system";
            content.text = "���� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 0;


        }
        if(interobj=="������ �ʿ��غ��̴� ����")
        {
            who.text = "player";
            content.text = "�� �ּŵ� �ſ�";
            button.SetActive(true);
            buttonnum = 0;
            glassinter = 1;

        }
        if(interobj=="���̺�")
        {
            who.text = "player";
            content.text = "��¥��?";
            button.SetActive(true);
            buttonnum = 1;
           
            
        }
        if (interobj == "�ú�Ŵ� �밴")
        {
            who.text = "�ú�Ŵ� �밴";
            content.text = "����?";
            button.SetActive(true);
            buttonnum = 1;
            sibiinter = 1;


        }

       
        if (interobj == "�����")
        {
            who.text = "player";
            content.text = "�����̴� �������� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 10;
            


        }

        if (interobj == "���� �Ĵ� �ҸӴ�")
        {
            who.text = "player";
            content.text = "����� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 10;



        }

        if (interobj == "�޹���")
        {
            who.text = "player";
            content.text = "ī��Ʈ 96�� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 10;



        }
        /*if(interobj == "����"&&jihoonflag==0)
        {
            who.text = "����";
            content.text = "���� �����ߴ�.";
            button.SetActive(true);
        }*/
        options.SetActive(false);
       
       
    }
    public void option2down()
    {
        optnum = 2;
        option1.text = "";
        option2.text = "";
        if(option3_bt != null && option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }
            
        }
        if (option4_bt != null && option4_bt.activeSelf)
        {
            if (option4 != null)
            {
                option4.text = "";
            }
        }
        if (option5_bt != null && option5_bt.activeSelf)
        {
            if (option5 != null)
            {
                option5.text = "";
            }
        }
        if (option6_bt != null && option6_bt.activeSelf)
        {
            if (option6 != null)
            {
                option6.text = "";
            }
        }

        if (interobj == "�������� ����")
        {
            if(manjufirst==0)
            {
                who.text = "Player";
                content.text = "�� ��������?";
                button.SetActive(true);
                buttonnum = 1;

            }
            else
            {
                who.text = "system";
                content.text = "�ֵ��׸� �����ߴ�.";
            }
           

        }
        if (interobj == "�� ����")
        {
            who.text = "system";
            content.text = "����� �������� �����ߴ�";
            button.SetActive(true);
            buttonnum = 0;


        }
        if (interobj == "������")
        {
            who.text = "system";
            content.text = "�������͸��� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 0;


        }
        if (interobj == "������ �ʿ��غ��̴� ����")
        {
            who.text = "player";
            content.text = "�����մϴ�";
            button.SetActive(true);
            buttonnum = 0;
            glassinter = 1;
        }

        if (interobj == "���̺�")
        {

          
            who.text = "���̺�";
            content.text = "(������ �� ĭ���� �������)";
            /*if(gameObject.name== "���̺�")
            {
                Debug.Log("���̺� ��Ȱ��ȭ �ڵ�");
                
            }*/
            button.SetActive(true);
            buttonnum = 12;
           
        }

        if (interobj == "�ú�Ŵ� �밴")
        {
            who.text = "�ú�Ŵ� �밴";
            content.text = "(���� ���� �հ������� �Ѵ�)";
            button.SetActive(true);
            buttonnum = 1;
            sibiinter = 1;


        }
        if (interobj == "�����")
        {
            who.text = "player";
            content.text = "����ø� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 10;




        }

        if (interobj == "���� �Ĵ� �ҸӴ�")
        {
            who.text = "player";
            content.text = "�� �������� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 10;




        }

        if (interobj == "�޹���")
        {
            who.text = "player";
            content.text = "ī��Ʈ 32�� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 10;



        }
        options.SetActive(false);
    }
    public void option3down()
    {
        optnum = 3;
        option1.text = "";
        option2.text = "";
        if (option3_bt != null && option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }
        }
        if (option4_bt != null && option4_bt.activeSelf)
        {
            if (option4 != null)
            {
                option4.text = "";
            }
        }
        if (option5_bt != null && option5_bt.activeSelf)
        {
            if (option5 != null)
            {
                option5.text = "";
            }
        }
        if (option6_bt != null && option6_bt.activeSelf)
        {
            if (option6 != null)
            {
                option6.text = "";
            }
        }


        if (interobj == "�����")
        {
            who.text = "player";
            content.text = "Ǯ���̽� �ΰ��� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 10;



        }
        if (interobj == "�� ����")
        {
            who.text = "system";
            content.text = "�������� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 0;


        }
        if (interobj == "������")
        {
            who.text = "system";
            content.text = "���ڸ� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 0;


        }
        options.SetActive(false);


        if (interobj == "���̺�")
        {
            who.text = "player";
            content.text = "�װ� ��¥����? �ƴ� �� ������....";
            button.SetActive(true);
            buttonnum = 3;


        }
        if (interobj == "�ú�Ŵ� �밴")
        {
            who.text = "�ú�Ŵ� �밴";
            content.text = "���̾�....";
            button.SetActive(true);
            buttonnum = 1;
            sibiinter = 1;


        }
        if (interobj == "�޹���")
        {
            who.text = "player";
            content.text = "ī��Ʈ 3�� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 10;



        }
        options.SetActive(false);
    }

    public void option4down()
    {
        optnum = 4;


        option1.text = "";
        option2.text = "";

        if (option3_bt != null && option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }
        }
        if (option4_bt != null && option4_bt.activeSelf)
        {
            if (option4 != null)
            {
                option4.text = "";
            }
        }
        if (option5_bt != null && option5_bt.activeSelf)
        {
            if (option5 != null)
            {
                option5.text = "";
            }
        }
        if (option6_bt != null && option6_bt.activeSelf)
        {
            if (option6 != null)
            {
                option6.text = "";
            }
        }
        if (interobj == "�����")
        {
            who.text = "player";
            content.text = "Ű��� �Ľ��� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 10;




        }


        options.SetActive(false);
    }
    public void option5down()
    {
        optnum = 5;


        option1.text = "";
        option2.text = "";

        if (option3_bt != null && option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }
        }
        if (option4_bt != null && option4_bt.activeSelf)
        {
            if (option4 != null)
            {
                option4.text = "";
            }
        }
        if (option5_bt != null && option5_bt.activeSelf)
        {
            if (option5 != null)
            {
                option5.text = "";
            }
        }
        if (option6_bt != null && option6_bt.activeSelf)
        {
            if (option6 != null)
            {
                option6.text = "";
            }
        }
        if (interobj == "�����")
        {
            who.text = "player";
            content.text = "��¦ ����� �����ߴ�.";
            button.SetActive(true);
            buttonnum = 10;




        }


        options.SetActive(false);
    }
    public void option6down()
    {
        optnum = 6;


        option1.text = "";
        option2.text = "";

        if (option3_bt != null && option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }
        }
        if (option4_bt != null && option4_bt.activeSelf)
        {
            if (option4 != null)
            {
                option4.text = "";
            }
        }
        if (option5_bt != null && option5_bt.activeSelf)
        {
            if (option5 != null)
            {
                option5.text = "";
            }
        }
        if (option6_bt != null && option6_bt.activeSelf)
        {
            if (option6 != null)
            {
                option6.text = "";
            }
        }
        if (interobj == "�����")
        {
            who.text = "player";
            content.text = "ī��Ʈ �÷��̾ �����ߴ�.";
            button.SetActive(true);
            buttonnum = 10;




        }


        options.SetActive(false);
    }
    /*public void exitdown()
    {
        option1.text = "";
        option2.text = "";
        if (option3_bt != null && option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }

        }
        talksqu.SetActive(false);
        buttonnum = 0;
        interobj = null;
    }*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 1;
            presentcol = gameObject.name;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 0;
            presentcol = null;
        }
    }
    
    public void buttondown()
    {
        
        if(interobj=="�������� ����")
        {  
            Debug.Log(optnum+"");
            if (optnum==1&&manjufirst==0)
            {
              
                if (buttonnum>0)
                {   
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                    manjufirst = 1;

                }
                else
                {
                    who.text = "����";
                    content.text = manjucontent[buttonnum];
                    buttonnum++;
                }
                
            }
            if (optnum==2&&manjufirst==0)
            {
                Debug.Log(buttonnum);
                if(buttonnum>3)
                {
                   
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                    manjufirst = 1;
                }
                else
                {
                    if (manjucontent[buttonnum].Substring(0,2)=="����")
                    {
                        who.text = "����";
                        content.text = manjucontent[buttonnum].Substring(2);
                    }
                    else
                    {
                        who.text = "player";
                        content.text = manjucontent[buttonnum];
                    }
                    
                    buttonnum++;
                    Debug.Log(buttonnum);
                }
                
            }
            if(manjufirst==1)
            {
                if(buttonnum>14)//����������
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                    option1.text = "";
                    option2.text = "";
                    if (option3_bt != null && option3_bt.activeSelf)
                    {
                        if (option3 != null)
                        {
                            option3.text = "";
                        }
                    }
                }
                else
                {
                    if(buttonnum>1)
                    {
                        talksqu.SetActive(false);
                        buttonnum = 0;
                        interobj = null;
                        option1.text = "";
                        option2.text = "";
                        if (option3_bt != null && option3_bt.activeSelf)
                        {
                            if (option3 != null)
                            {
                                option3.text = "";
                            }
                        }
                    }
                    if(buttonnum==1)
                    {
                        who.text = "����";
                        content.text = "�����ϰ� �˵��ϰ� ����� Ŀ��Ÿ���� ��⸦...";
                        buttonnum++;
                    }
                    if(buttonnum==0)
                    {
                        who.text = "����";
                        content.text = "�ƴ�! ����ö���� ���긦 �Ѹ�ġ�� ���ٴ�...!";
                        buttonnum++;
                    }
                    who.text = "����";
                    content.text = "�ƴ�! ����ö���� ���긦 �Ѹ�ġ�� ���ٴ�...!";
                    buttonnum++;
                }
               
              
            }
            
          
          
        }


        if (interobj == "�� ����")
        {

           
            if (clofirst==0)
            {
                buttonnum++;
                if (buttonnum > 2)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    
                    interobj = null;
                    clofirst = 1;
                }
                else
                {
                    who.text = clocontent[buttonnum].Substring(0, 2);
                    content.text = clocontent[buttonnum].Substring(2);

                }
            }
            else
            {
                if(clofirst==1)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                    option1.text = "";
                    option2.text = "";
                    if (option3_bt != null && option3_bt.activeSelf)
                    {
                        if (option3 != null)
                        {
                            option3.text = "";
                        }
                    }
                }
            }



        }
        if (interobj == "������")
        {


            
            talksqu.SetActive(false);
            buttonnum = 0;
            interobj = null;





        }
        if(interobj=="�����")
        {
            if(buttonnum>9)
            {

                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                options.SetActive(false);
                if(buttonnum>1)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                }
                if (jobcontent[buttonnum].Substring(0, 2) == "����")
                {
                    who.text = "����";
                    content.text = jobcontent[buttonnum].Substring(2);
                }
                else
                {
                    who.text = "�����";
                    content.text = jobcontent[buttonnum];
                }
                buttonnum++;
            }
        }
        
        if (interobj == "�ú�Ŵ� �밴")
        {



            talksqu.SetActive(false);
            buttonnum = 0;
            interobj = null;
            option1.text = "";
            option2.text = "";
            if (option3_bt != null && option3_bt.activeSelf)
            {
                if (option3 != null)
                {
                    option3.text = "";
                }
            }





        }






        if (interobj == "��Ҹ� �ϴ� ����")
        {
            buttonnum++;
            if (buttonnum > 7)
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                who.text = "��Ҹ� �ϴ� ����";
                content.text = weildcontent[buttonnum];

            }
        }
        else if(interobj == "������ �ʿ��غ��̴� ����")
        {
            if(buttonnum==0&&glassinter==1) // �� �� ��ȣ�ۿ��� ��������
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                buttonnum++;
                if (buttonnum > 5)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                }
                if (buttonnum > 2)
                {
                    if (glass == 0)
                    {
                        talksqu.SetActive(false);
                        buttonnum = 0;
                        interobj = null;
                    }
                    else if (glass == 1)
                    {
                        if (helpcontent[buttonnum] == "�츮 ���� ���Ƽ� �ִ� �ž�...")
                        {
                            options.SetActive(true);
                            option3_bt.SetActive(false);
                            option1.text = "> �� �ּŵ� �ſ�";
                            option2.text = "> �����մϴ�";
                        }
                        who.text = "������ �ʿ��غ��̴� ����";
                        content.text = helpcontent[buttonnum];
                    }

                }
                else
                {
                    who.text = "������ �ʿ��غ��̴� ����";
                    content.text = helpcontent[buttonnum];

                }
            }
            
        }

        else if (interobj == "������ ��ġ�� ����")
        {
            buttonnum++;
            if (buttonnum > 0)
            {
               
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
                npcmove.moveflag = 1;
            }
            else
            {
                who.text = "������ ��ġ�� ����";
                content.text = objcontent[buttonnum];

            }
        }

        else if (interobj == "���̺�")
        {
            buttonnum++;
            if (buttonnum>10)
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
           
            if(optnum==1)
            {
                if(buttonnum>2)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                }
                if (godcontent[buttonnum].Substring(0,2)=="����")
                {
                    who.text = "����";
                    content.text = /*playername+*/godcontent[buttonnum].Substring(2);
                }
                else
                {
                    who.text = "���̺�";
                    content.text = /*playername+*/godcontent[buttonnum];
                }
                
            }
           
           
            else if(optnum==3)
            {
                if(buttonnum>7)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                }
                if (godcontent[buttonnum].Substring(0, 2) == "PL")
                {
                    who.text = "player";
                    content.text = /*playername+*/godcontent[buttonnum].Substring(2);
                }
                else if(godcontent[buttonnum].Substring(0, 2) == "����")
                {
                    who.text = "����";
                    content.text = /*playername+*/godcontent[buttonnum].Substring(2);
                }
                else
                {
                    who.text = "���̺�";
                    content.text = /*playername+*/godcontent[buttonnum];
                }
            }
            
            
        }



        else if (interobj == "�ú�Ŵ³���")
        {
            buttonnum++;
            if (buttonnum > 2)
            {
                //���⿡ �Ȱ��÷��� �߰� ����
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                who.text = "�ú� �Ŵ� ����";
                content.text = angercontent[buttonnum];

            }
        }


        else if (interobj == "������")
        {
            buttonnum++;
            if (buttonnum > 3)
            {

                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                if (stationcontent[buttonnum].Substring(0,2)=="����"|| stationcontent[buttonnum].Substring(0, 2)=="����")
                {
                    who.text = stationcontent[buttonnum].Substring(0, 2);
                    content.text = stationcontent[buttonnum].Substring(2);
                }
                else
                {
                    who.text = "player";
                    content.text = stationcontent[buttonnum];
                }
                

            }
        }

        else if (interobj == "���� �Ĵ� �ҸӴ�")
        {
            if(buttonnum>10)
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else if (buttonnum > 9)
            {
                who.text = "���� �Ĵ� �ҸӴ�";
                content.text = "������.";
                buttonnum++;

            }
            else 
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
                


            }
            
            
        }

        else if (interobj == "�޹���")
        {
            if (buttonnum > 10)
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else if (buttonnum > 9)
            {
                who.text = "����";
                content.text = "(�ڴ� ô)";
                buttonnum++;

            }
            else
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;



            }


        }

        else if (interobj == "����")
        {
            buttonnum++;
            if (buttonnum > 5)
            {

                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {   
                if (jihoonfirst[buttonnum].Substring(0, 2) == "����" || jihoonfirst[buttonnum].Substring(0, 2) == "����")
                {
                    who.text = jihoonfirst[buttonnum].Substring(0, 2);
                    if(jihoonfirst[buttonnum].Substring(2)== "���ƾƾƾƾ�!!")
                    {
                        content.fontSize = 7;

                    }
                    else
                    {
                        content.fontSize = 3;
                    }
                    
                    if(jihoonfirst[buttonnum].Substring(2) == "�̾ư�����...��ұ�� ?")
                    {
                        //options.SetActive(true);
                        //option3_bt.SetActive(false);
                        //option1.text = "> �̸��� �����";
                        //option2.text = "> ���� ���� �ǳٴ�";//�κ��丮 ���� ���� �з��� �������� ����Ѵ� 
                        
                    }
                         content.text = jihoonfirst[buttonnum].Substring(2);
                }
                else
                {
                    who.text = "player";
                    content.text = jihoonfirst[buttonnum];
                }


            }
        }
    }
    void OnMouseDown()
    {
        Debug.Log("���콺Ŭ������");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.colitemname);

        if (playercolflag==1&&gameObject.name == "��Ҹ� �ϴ� ����" && presentcol == "��Ҹ� �ϴ� ����")
        {
            interobj = "��Ҹ� �ϴ� ����";
           
            if(buttonnum==0)
            {
                talksqu.SetActive(true);
                who.text = "��Ҹ� �ϴ� ����";
                content.text = weildcontent[0];
            }
           
            Debug.Log("��Ҹ� �ϴ� ���� Ŭ����");
           
        }

        if (playercolflag == 1 && gameObject.name == "������ �ʿ��غ��̴� ����" && presentcol == "������ �ʿ��غ��̴� ����")
        {
            interobj = "������ �ʿ��غ��̴� ����";

            if (buttonnum == 0)
            {
                if(glassinter==0)
                {
                    talksqu.SetActive(true);
                    who.text = "������ �ʿ��غ��̴� ����";
                    content.text = helpcontent[0];
                }
                else
                {
                    talksqu.SetActive(true);
                    who.text = "������ �ʿ��غ��̴� ����";
                    content.text = "�Ȱ��� �����ϴ��� ���� �߾��߾� �а� �ִ�.";
                }
                
            }

         

        }

        if (playercolflag == 1 && gameObject.name == "������ ��ġ�� ����" && presentcol == "������ ��ġ�� ����")
        {
            interobj = "������ ��ġ�� ����";

            if (buttonnum == 0)
            {
                npcmove.moveflag = 0;
                talksqu.SetActive(true);
                who.text = "������ ��ġ�� ����";
                content.text = objcontent[0];
            }



        }

        if (playercolflag == 1 && gameObject.name == "�ú�Ŵ³���" && presentcol == "�ú�Ŵ³���")
        {
            interobj = "�ú�Ŵ³���";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "�ú� �Ŵ� ����";
                content.text = angercontent[0];
            }



        }

        if (playercolflag == 1 && gameObject.name == "�������� ����" && presentcol == "�������� ����")
        {
            interobj = "�������� ����";
            if (manjufirst == 1&& buttonnum==0)
            {
                talksqu.SetActive(true);
                options.SetActive(true);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                who.text = "system";
                content.text = "������ �����ұ�?";
                option1.text = "> ��������";
                option2.text = "> �ֵ���";
                button.SetActive(true);
                //exit.text = "> ���� �ʴ´�.";
            }
            else if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                options.SetActive(true);
                who.text = "����";
                content.text = "........";
                option1.text = "> �� �ٱ��?";
                option2.text = "> �� ��������?";
                option3_bt.SetActive(false);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                button.SetActive(false);
            }



        }

        if (playercolflag == 1 && gameObject.name == "�� ����" && presentcol == "�� ����")
        {
            interobj = "�� ����";
            Debug.Log(clofirst +"�� �÷���");
            if (buttonnum == 0 && clofirst == 0)
            {
                
                talksqu.SetActive(true);
                options.SetActive(false);
                who.text = clocontent[0].Substring(0, 2);
                content.text = clocontent[0].Substring(2);
            }
            if (buttonnum==0&&clofirst != 0)

            {
                Debug.Log("����");
                talksqu.SetActive(true);
                options.SetActive(true);
                option3_bt.SetActive(true);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                button.SetActive(true);
                who.text = "system";
                content.text = "������ �����ұ�?";
                option1.text = "> ¯�� ���";
                option2.text = "> ����� ������";
                option3.text = "> ������";
                //exit.text = "> ���� �ʴ´�.";
            }



        }

        if (playercolflag == 1 && gameObject.name == "������" && presentcol == "������")
        {
            interobj = "������";
           
            
                Debug.Log("����");
                talksqu.SetActive(true);
                options.SetActive(true);
                option3_bt.SetActive(true);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                button.SetActive(true);
                who.text = "system";
                content.text = "������ �����ұ�?";
                option1.text = "> ��";
                option2.text = "> �������͸�";
                option3.text = "> ����";
                //exit.text = "> ���� �ʴ´�.";




        }

        if (playercolflag == 1 && gameObject.name == "������" && presentcol == "������")
        {
            interobj = "������";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = stationcontent[0].Substring(0,2);
                content.text = stationcontent[0].Substring(2);
            }



        }

        if (playercolflag == 1 && gameObject.name == "����"&&presentcol == "����")
        {
            interobj = "����";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = jihoonfirst[0].Substring(0, 2);
                content.text = jihoonfirst[0].Substring(2);
            }



        }

        if (playercolflag == 1 && gameObject.name == "���̺�"&&presentcol == "���̺�")
        {
            interobj = "���̺�";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "���̺�";
                content.text = godcontent[buttonnum];
                options.SetActive(true);
                option3_bt.SetActive(true);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                option1.text = "> ��¥��?";
                option2.text = "> (������ �ִ´�)";
                option3.text = "> (�ú� �Ǵ�)";
                button.SetActive(false);
            }



        }


        if (playercolflag == 1 && gameObject.name== "�ú�Ŵ� �밴"&&presentcol == "�ú�Ŵ� �밴")
        {
            interobj = "�ú�Ŵ� �밴";

            if (buttonnum == 0&&sibiinter==0)
            {
                talksqu.SetActive(true);
                who.text = "�ú�Ŵ��밴";
                content.text = "����! ����! ��!";
                options.SetActive(true);
                option3_bt.SetActive(true);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                option1.text = "> ����";
                option2.text = "> ����";
                option3.text = "> ��";
                button.SetActive(false);
            }
            else
            {
                talksqu.SetActive(true);
                who.text = "�ú�Ŵ��밴";
                content.text = "����...!";
            }



        }
        if (playercolflag == 1 && gameObject.name == "�����"&&presentcol=="�����")
        {
            interobj = "�����";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "�����";
                content.text = "1000��¥�� �� ��, �� �常 �ްڽ��ϴ�.";
              
                options.SetActive(true);
                option3_bt.SetActive(true);
                button.SetActive(true);
                
                option1.text = "> �����̴� ������";
                option2.text = "> �����";
                option3.text = "> Ǯ���̽� �ΰ�";
                option4.text= "> Ű��� �Ľ�";
                option5.text = "> ��¦ ���";
                option6.text = "> ī��Ʈ �÷��̾�";
                
            }



        }

        if (playercolflag == 1 && gameObject.name == "���� �Ĵ� �ҸӴ�" && presentcol == "���� �Ĵ� �ҸӴ�")
        {
            interobj = "���� �Ĵ� �ҸӴ�";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "���� �Ĵ� �ҸӴ�";
                content.text = "....";

                options.SetActive(true);
                option3_bt.SetActive(false);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                button.SetActive(true);

                option1.text = "> ���";
                option2.text = "> �� ������";
                

            }



        }
        if (playercolflag == 1 && gameObject.name == "�޹���" && presentcol == "�޹���")
        {
            interobj = "�޹���";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "�޹���";
                content.text = "~..~";

                options.SetActive(true);
                
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                button.SetActive(true);

                option1.text = "> ī��Ʈ 96";
                option2.text = "> ī��Ʈ 32";
                option3.text = "> ī��Ʈ 3";


            }



        }



    }
// Start is called before the first frame update
void Start()
    {
        talksqu.SetActive(false);
        customize.sceneflag = 2;
        options.SetActive(false);
        button.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(buttonnum);
        Debug.Log(presentcol);
        
    }
}
