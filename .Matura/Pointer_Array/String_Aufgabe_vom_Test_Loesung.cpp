#include  "stdafx.h"
#include  "iostream"
#include  "string.h"
using namespace std;

// stA="abc"; stB=123"; StrAppend(stA,stB); stB="123abc"
// aSrc an aDest anh‰ngen
void StrAppend(char aSrc[], char aDest[]);

// AppendMirrored(ì123ì, ìabcì);  =>  ìabc321ì
void AppendMirrored(char aSrc[],  char aDest[]);

void main()
{
	char A[20]; char B[20];

	strcpy(A,"abc");
	strcpy(B,"123");
	StrAppend(A,B);

	printf_s("Append = %s\n", B);
	
	strcpy(B,"123");
	AppendMirrored(A,B);
	printf_s("Mirrored = %s\n", B);
}

void StrAppend(char aSrc[], char aDest[])
{
	// startpunkt ist das momentane Ende von aDest
	int j=strlen(aDest); 
	int i=0; // i auf das erste zeichen von aSrc setzen
	for(i=0; i<strlen(aSrc); i++)
	{
		aDest[j]=aSrc[i];
		j++;
	}
	aDest[j]=0; // aDest mit 0 abschlieﬂen
}


void AppendMirrored(char aSrc[],  char aDest[])
{
	// startpunkt ist das momentane Ende von aDest
	int j=strlen(aDest); 
	int i;
	// i auf das Ende von Dest setzen
	// und r¸ckw‰rts bis 0 z‰hlen
	for(i=strlen(aSrc)-1; i>=0; i--)
	{
		aDest[j]=aSrc[i]; 
		aDest[j+1]=0; // Braucht man nur zum Debuggen
		j++;
	}
	aDest[j]=0; // aDest mit 0 abschlieﬂen
}


