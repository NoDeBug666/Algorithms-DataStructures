#include<cstdio>

int main()
{
    int a,b,t;
    while(scanf("%d %d",&a,&b) != EOF){
        while(t = a % b)
            a = b,b = t;
        printf("%d\n",b);
    }
}
