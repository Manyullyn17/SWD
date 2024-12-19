#include  "stdafx.h"
#include  "iostream"
#include  "string.h"
using namespace std;

// gibt die Länge von aStr zurück
// Absicherung gegen Strings die nicht mit 0 abgeschlossen sind
int MStrLen(char aStr[]);

// Es entsteht auch dann kein Fehler
// wenn MStrLenSave() keinen 0er findet
int MStrLenSave(char aStr[]);

// Vertauscht die Reihenfolge der Zeichen "abcd" -> "dcba"
void ChangeStrOrder(char aSrc[], char aDest[]);

// Kopiert aSrc nach aDest und ersetzt dabei die Umlaute durch ae, ue, oe ....
// ä ö ü
// siehe FSST_3ACEL_mts_hl.pdf S16
// Programmieren und testen
void UmlauteErsatz(char aSrc[], char aDest[]);

void main()
{
	int len;
	char B[100];

	len = MStrLenSave("Hallo");
	if( len==-1 )
		printf("Fehler!!\n");
	else
		printf("Len = %d\n", len);

	ChangeStrOrder("Hallo", B);
	printf("Gespiegelt: %s\n", B);

	UmlauteErsatz("Hälö", B);
	printf("Umlaute: %s\n", B);
}


void ChangeStrOrder(char aSrc[], char aDest[])
{
	int N=MStrLen(aSrc);
	int j=N-1;
	for(int i=0; i<N; i++)
	{
		aDest[j]=aSrc[i];
		j--;
	}
	aDest[N]=0; // Dest mit 0 abschließen
}

int MStrLen(char aStr[])
{
	int i=0;
	while( aStr[i]!=0 )
	{
		i++;
	}
	return i;
}

int MStrLenSave(char aStr[])
{
	int i=0;
	for(i=0; i<=100; i++)
	{
		if( aStr[i]==0 )
			return i; // Gutfall
	}
	// Error
	return -1; // Fehler
}


void UmlauteErsatz(char aSrc[], char aDest[])
{
	int i=0, j=0;
	for(i=0; i<MStrLen(aSrc); i++)
	{
		if( aSrc[i]=='ä' )
		{
			aDest[j]='a'; j++;
			aDest[j]='e'; j++;
		}
		else if( aSrc[i]=='ö' )
		{
			aDest[j]='o'; j++;
			aDest[j]='e'; j++;
		}
		else // kein Umlaut umkopieren
		{
			aDest[j]=aSrc[i]; j++;
		}
	}
	aDest[j]=0; // Dest mit 0 abschließen
}




