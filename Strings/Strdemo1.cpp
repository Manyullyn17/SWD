//#include "stdafx.h"
#include "iostream"
#include "string.h"

using namespace std;

void StringStandartFunktionen1();

void StringStandartFunktionen2();

void StringIo1();

void main()
{
	//StringStandartFunktionen1();
	StringIo1();
}

void StringStandartFunktionen1()
{
	char str[100]; // leerer String mit Platz für 100 Zeichen
	char str2[] = "uvw";  // Bei der Deklaration gleich mit einem Text initialisieren
	char ch;

	int len = 0, res = 0;

	// ASCII-Code Tablelle

	// String über die Zuweisung einzelner char's befüllen
	str[0] = 'H';
	str[1] = 'a';
	str[2] = 'l';
	str[3] = 'l';
	str[4] = 'o';
	str[5] = '\n'; // Zeilenumbruch
	str[6] = '1';
	str[7] = '2';
	str[8] = 0;   // strings immer mit 0 abschließen

	printf_s("Inh: %s", str);

	ch = str[0];
	ch = str[1];

	// C-Stringfunktionen
	// strcpy() kopieren ( zuweisen );  strcat() zusammenhängen  
	// strlen() länge abfragen;  strcmp() Strings lexikalisch vergleichen

	strcpy_s(str, "ABC"); // auf str den Text "ABC" hinkopieren

	len = strlen(str); // Länge von str bestimmen

	strcpy_s(str, "XYZ"); // auf str den Text "XYZ" hinkopieren

	strcat_s(str, "DEFG"); // An str den Text "DEFG" anhängen

	strcat_s(str, str2); // An str den Text str2 anhängen

	len = strlen(str); // Länge von str bestimmen

	cout << "Inhalt von str: " << str << endl;  // str auf der Console ausgeben

	  // Strings lexikalisch vergleichen
	  // 0 ...str1 == str2
	  // 1 ...str1 >  str2
	  // -1...str1 <  str2
	res = strcmp("Hans", "Hans");
	res = strcmp("aaa", "bbb");
	res = strcmp("bbb", "aaa");
}


void StringStandartFunktionen2()
{
	char string1[30], string2[] = "Butterbrot";

	int comp = 0, len = 0;

	char* res = 0;


	strcpy_s(string1, "Butter");

	len = strlen(string1);

	comp = strcmp(string1, string2);

	comp = strncmp(string1, string2, 6);

	strcat_s(string1, "brot");

	strncat_s(string1, " und Käse", 4);

	string1[6] = '\0';

	strncpy_s(string1, "xxxx", 2);

	res = strstr(string2, "ter");

	res = strstr(string2, "xx");
}


void StringIo1()
{
	char str1[100], str2[100];

	printf_s("Bitte 2 Strings eingeben: ");
	scanf_s("%s %s", str1, str2);

	printf_s("Es wurde str1=%s str2=%s eingegeben\n", str1, str2);


	cout << "Bitte 2 Strings eingeben: ";
	cin >> str1 >> str2;

	cout << "Es wurde str1=" << str1 << " str2=" << str2 << " eingegeben" << endl;
}

