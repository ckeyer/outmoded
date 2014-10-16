#ifndef TEST4_H
#define TEST4_H

#include <iostream>
#include <string>
using namespace std;

class String
{
public :
    String(char *s)
    { this->s= s; }
    string s;
    int Length()
    {return s.length();}
};
class EditString:public String
{
public :
    EditString(char* s):String(s)
    {}
    void replace(char* s1 ,char* s2)
    {
        string::size_type pos=0;
        string::size_type a=string(s1).size();
        string::size_type b=string(s2).size();
        while((pos=this->s.find(s1,pos))!=string::npos)
        {
            this->s.replace(pos,a,s2);
            pos+=b;
        }
    }
    void remove(char* s1)
    {
        string::size_type pos=0;
        string::size_type a=string(s1).size();
        while((pos=this->s.find(s1,pos))!=string::npos)
        {
            s.erase(pos,a);
        }
    }
};

void test4()
{
    EditString s("Hero");
    cout<<s.s<<endl;
    s.replace("He","SHSHHSK");
    cout<<s.s<<endl;
    s.remove("H");
    cout<<s.s<<endl;
}

#endif // TEST4_H
