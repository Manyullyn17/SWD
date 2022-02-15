
// #include "stdafx.h"
#include "stdio.h"

// 1. Array-Capacity z.B. 100
// 2. Anzahl der gültigen Werte z.B. 10
// Anzahl der gültigen Werte muss kleiner als Capacity sein

// Bearbeitung von Arrays mithilfe von Funktionen
// Die Funktion bekommt das Array und die Länge des
// Arrays als Parameter übergeben.

// aAry mit aLaenge Daten befüllen
// Bsp.: FillAry(A, 10, 10, 3); ergibt [10, 20, 30]
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

// Bsp.: aA[7, 8, 9]  aB[14, 15, 16]
// =>    aC[7, 14, 8, 15, 9, 16]
// returns Lange von C
int Mischen(int aA[], int aB[], int aC[], int aLaenge);


void main()
{
	int A[100], B[100];


	// A mit 3, 6, 9, 12, 15 befüllen
	FillAry(A, 3, 3, 5);

	// A ausgeben
	PrintAry("Array A", A, 5);

	// A mit CopyAry nach B kopieren
	CopyAry(A, B, 5);

	// B ausgeben
	PrintAry("Array B (Copy)", B, 5);

	// A mit Spiegeln nach B spiegeln
	Spiegeln(A, B, 5);

	// B ausgeben
	PrintAry("Array B (Spiegeln)", B, 5);

	// A mit Anhaengen an B anhängen
	// B ausgeben
	PrintAry("Array B (Anhaengen)", B, Anhaengen(A, B, 5, 5));
	
	int C[100];
	// A und B mit Mischen gemischt nach C geben
	// C ausgeben
	PrintAry("Array C (Mischen)", C, Mischen(A, B, C, 5));

}


void FillAry(int aAry[], int aVon, int aSchritt, int aLaenge)
{
	int i, val;

	val = aVon;
	for (i = 0; i < aLaenge; i++)
	{
		aAry[i] = val;
		val += aSchritt;
	}
}

void PrintAry(const char* aName, int aAry[], int aLaenge)
{
	printf("%s: ", aName);
	for (int i = 0; i < aLaenge; i++)
	{
		printf("%d ", aAry[i]);
	}
	printf("\n");
}

void CopyAry(int aQuelle[], int aZiel[], int aLaenge)
{
	for (int i = 0; i < aLaenge; i++)
	{
		aZiel[i] = aQuelle[i];
	}
}

void Spiegeln(int aQuelle[], int aZiel[], int aLaenge)
{
	for (int i = 0; i < aLaenge; i++)
	{
		aZiel[i] = aQuelle[aLaenge - 1 - i];
	}
}

int Anhaengen(int aQuelle[], int aZiel[], int aQLaenge, int aZLaenge)
{
	for (int i = 0; i < aQLaenge; i++)
	{
		aZiel[aZLaenge + i] = aQuelle[i];
	}
	return aQLaenge + aZLaenge;
}

int Mischen(int aA[], int aB[], int aC[], int aLaenge)
{
	int j = 0;
	for (int i = 0; i < aLaenge * 2; i += 2)
	{
		aC[i] = aA[j];
		aC[i + 1] = aB[j];
		j++;
	}

	return aLaenge * 2;
}