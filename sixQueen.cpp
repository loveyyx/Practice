#include <iostream>
using namespace std;
void showAnswer(int chess[6][6])
{	
    for(int i=0;i<6;i++)
	{
		for(int j=0;j<6;j++)
		    cout<<chess[i][j]<<'\t';
		cout<<endl;
	}
	cout<<endl; 
}
bool check(int chess[6][6],int i,int j)
{
	bool flag=true;
	for(int k=0;k<6;k++)
	    if(chess[k][j]==1)
	        flag=false;
	for(int t=1;i-t>=0 && j-t>=0;t++)
	    if(chess[i-t][j-t]==1)
	        flag=false;
	for(int p=1;i-p>=0 && j+p<6;p++)
	    if(chess[i-p][j+p]==1)
	        flag=false;
	return flag;
} 
void set_queen(int chess[6][6],int row)
{
	if(row==6)
	{
		showAnswer(chess);
	}
	else
	{
		for(int i=0;i<6;i++)
		{
			if(check(chess,row,i))
			{
				chess[row][i]=1;
				set_queen(chess,row+1);
				chess[row][i]=0;
			}
		}
	}
}
int main()
{
	int chess[6][6]={0};
	set_queen(chess,0);
	return 0;
}
