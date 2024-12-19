

#include "pch.h"
#include "stdio.h"

// Bearbeitung von Arrays mithilfe von Funktionen
// Die Funktion bekommt das Array und die Länge des
// Arrays als Parameter übergeben.

// aAry mit aLaenge Daten befüllen
// Bsp.: FillAry(A, 10, 2, 3); ergibt [10, 12, 14]
void FillAry(int aAry[], int aVon, int aSchritt, int aLaenge);

// Elemente von aAry auf der Konsole ausgeben
void PrintAry(const char* aName, int aAry[], int aLaenge);

// Elemente von aQuelle auf aZiel kopieren
// Die Arrays sind aLaenge lang
void CopyAry(int aQuelle[], int aZiel[], int aLaenge);

// Elemente von aQuelle in gespiegelter Form auf aZiel schreiben
// Bsp.: aQuelle[4, 7, 9, 5]  =>  aZiel[5, 9, 7, 4]
void Spiegeln(int aQuelle[], int aZiel[], int aLaenge);

// Elemente von aQuelle an aZiel anhaengen
// Bsp.: aQuelle[10,11,12]; aZiel[20,21,22]; => aZiel[20,21,22, 10,11,12]
// return = aQLaenge + aZLaenge also Anhaengen() soll die neue Laenge von
// Ziel zurückgeben
int Anhaengen(int aQuelle[], int aZiel[], int aQLaenge, int aZLaenge);

// 2te Vektor HÜ
// Bsp.: aA[7, 8, 9]  aB[14, 15, 16]
// =>    aC[7, 14, 8, 15, 9, 16]
// returns Lange von C
int Mischen(int aA[], int aB[], int aC[], int aLaenge);


void main()
{
	int A[100], B[100];
  
  // A mit 13, 15, 17 ... befüllen
	FillAry(A, 13, 2, 5);
	// A ausgeben
	PrintAry("A", A, 5);
	
	// Weitere Aufgaben:
	//1. B mit 20, 23, ... befüllen
	FillAry(B, 20, 3, 5);
	//2. B ausgeben
	PrintAry("B", B, 5);
	
	//3. A mit CopyAry() nach B kopieren
	CopyAry(A, B, 5);
	//4. B ausgeben
	PrintAry("B nach copy", B, 5);

	//5. A nach B spiegeln
	Spiegeln(A, B, 5);
	//6 . B ausgeben
	PrintAry("B nach spiegeln", B, 5);

	FillAry(B, 20, 3, 5);
	int Len = Anhaengen(B, A, 5, 5);
	PrintAry("A nach anhaengen", A, Len); 
}

int Anhaengen(int aQuelle[], int aZiel[], int aQLaenge, int aZLaenge)
{
	int j = aZLaenge;
	for (int i = 0; i < aQLaenge; i++)
	{
		aZiel[j] = aQuelle[i];
		j++;
	}
	return aQLaenge + aZLaenge;
}

void Spiegeln(int aQuelle[], int aZiel[], int aLaenge)
{
	int j = aLaenge - 1;
	for (int i = 0; i < aLaenge; i++)
	{
		aZiel[j] = aQuelle[i];
		j--;
	}
}

void PrintAry(const char* aName, int aAry[], int aLaenge)
{
	printf("%s = ", aName);
	for (int i = 0; i < aLaenge; i++)
	{
		printf("%d ", aAry[i]);
	}
	printf("\n");
}

void FillAry(int aAry[], int aVon, int aSchritt, int aLaenge)
{
	int val;
	val = aVon;
	for (int i = 0; i < aLaenge; i++)
	{
		aAry[i] = val;
		val = val + aSchritt;
	}
}

void CopyAry(int aQuelle[], int aZiel[], int aLaenge)
{
	// in der Funktionen !!kein!! printf
	for (int i = 0; i < aLaenge; i++)
	{
		aZiel[i] = aQuelle[i];
	}
}





