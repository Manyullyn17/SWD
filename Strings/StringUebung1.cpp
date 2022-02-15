//#include "stdafx.h"
#include "iostream"
#include "string.h"
#include "math.h"
using namespace std;

// gibt die Länge von aStr zurück
// Absicherung gegen Strings die nicht mit 0 abgeschlossen sind
int MStrLen(char aStr[]);

int MStrLenSave(char aStr[]);

// Vertauscht die Reihenfolge der Zeichen "abcd" -> "dcba"
void ChangeStrOrder(char aSrc[], char aDest[]);

// Kopiert aSrc nach aDest und ersetzt dabei die Umlaute durch ae, ue, oe ....
// ä ö ü
// siehe FSST_3ACEL_mts_hl.pdf S16
// Programmieren und testen
void UmlauteErsatz(char aSrc[], char aDest[]);

// "1001" => 9
int BinString2Int(char aTxt[]);

// 9 => "1001"
void Int2BinString(int aVal, char aBinStr[]);


void main()
{
	int len;
	char txt[] = "abcd";
	char txt2[100];
	char txt3[] = "Dürüm";
	char binString[100];
	
	len = MStrLen(txt);	// eigentlich "abcd" aber C++ mag nicht lmao
	printf_s("Laenge von %s = %d\n", txt, len);
	
	ChangeStrOrder(txt, txt2);
	printf_s("txt2 = %s\n", txt2);

	UmlauteErsatz(txt3, txt2);
	printf_s("UmlauteErsatz = %s\n", txt2);

	printf("Gib eine Binaerzahl ein: ");
	cin >> binString;
	int num = BinString2Int(binString);
	printf("BinString2Int: %d\n", num);
	
	printf("Gib eine Zahl ein: ");
	scanf_s("%d", &num);
	Int2BinString(num, binString);
	cout << "Int2BinString: " << binString << endl;
}


void ChangeStrOrder(char aSrc[], char aDest[])
{
	int len = MStrLen(aSrc);
	for (int i = 0; i < len; i++)
	{
		aDest[len - 1 - i] = aSrc[i];
	}
	aDest[len] = 0;
}


int MStrLen(char aStr[])
{
	int i = 0;
	while (aStr[i] != 0)
	{
		i++;
	}
	return i;
}

// Absichern gegen wir finden keinen 0er
// und fahren ewig in RAM-Speicher herum
// Suche auf z.B. 1000 chars begrenzen
// Im Fehlerfall -1 zurückgeben
int MStrLenSave(char aStr[])
{
	for (int i = 0; i <= 1000; i++)
	{
		if (aStr[i] == 0)
			return i;	//Endzeichen gefunden OK
	}
	return -1;	// Endzeichen nicht gefunden ERROR
}

void UmlauteErsatz(char aSrc[], char aDest[]) // unterstützt nur kleine Umlaute, weil ich zu faul bin alles doppelt zu schreiben
{
	int len = MStrLen(aSrc);
	int j = 0;
	for (int i = 0; i < len; i++)
	{
		if (aSrc[i] == 'ä')
		{
			aDest[j] = 'a';
			aDest[j + 1] = 'e';
			j += 2;
		} else if (aSrc[i] == 'ö')
		{
			aDest[j] = 'o';
			aDest[j + 1] = 'e';
			j += 2;
		} else if (aSrc[i] == 'ü')
		{
			aDest[j] = 'u';
			aDest[j + 1] = 'e';
			j += 2;
		} else if (aSrc[i] == 'ß')
		{
			aDest[j] = 's';
			aDest[j + 1] = 's';
			j += 2;
		}
		else {
			aDest[j] = aSrc[i];
			j++;
		}
	}
	aDest[j] = 0;
}

int BinString2Int(char aTxt[])
{
	int len = MStrLen(aTxt);
	int result = 0;

	for (int i = 0; i < len; i++)
	{
		if (aTxt[i] == '1')
		{
			result += pow(2, len - 1 - i);
		}
	}
	return result;
}

void Int2BinString(int aVal, char aBinStr[])
{
	int i = 0;
	char result[100];

	while (aVal >= 1)
	{
		result[i] = aVal % 2 + '0';
		aVal /= 2;
		i++;
	}

	result[i] = 0;
	ChangeStrOrder(result, aBinStr);
}

// 1010
// 0010
// AND
// <<
// repeat

// durch 2 div
// Reste in reverse aufschreiben