#include<iostream>
#include<string>
#include<vector>

using namespace std;

bool isInTheString(char c,string tString)
{
    for(int i=0;i<main.Length();i++){
        if(c==tString[i]){
            return true;
        }
    }
    return false;
}

int howManyInRow(&string main, int pos, &string tString)
{
    int counter=0;
    for(inti=pos;i<main.Length();i++){
        if(isInTheString(main[i], tString)){
            counter++;
        }else {
            break;
        }
    }
    return counter;
}

void subStrings(&vector<string,int> condidates, &string main, &string tString....)
{
    int howmany=0;
    pair<
    for(int i=0;i<main.Length();i++){
        if(isInTheString(main[i])){
            howmany=howManyInRow(main, i, tString)
        }
    }



    condidates.push_back();
}
// vector<string> subStrings(&string main,string tString,...)
// {
//     for(int i=0;i<main.Length();i++){
//         if()
//     }
// }
int bestLocation(&string appleGen, &string tGen)
{
    string temp="";
    vector<pair<string,int> condidates;


}

int main()
{
    int n, a,c,g,t;
    string appleGen, tGen;
    cin>>appleGen>>tGen>>a>>c>>g>>t;

    map<char, int>={A= a,C= c,G= g,T=t}


}