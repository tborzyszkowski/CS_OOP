# Zadanie 1

Do projektu ``Zoo`` dodaj klasê ``SmokWawelski``, 
klasa powinna implementowaæ podobne metody do zaimplementowanych w klasie ``Wilk``.
Zaadoptuj klasê ``SmokWawelski`` (podobnie jak zrobiono to w przypadku klasy ``Wilk``) 
i dodaj do fabryki oraz menu programu g³ównego.

# Zadanie 2

Napisz klasê ``Towar`` posiadaj¹c¹ publiczne pola: 
``Nazwa``, ``Cena`` oraz ``Iloœæ`` 
i wirtualn¹ metodê ``Opis`` wyœwietlaj¹c¹ na standardowym wyjœciu wszystkie informacje 
przechowywane w obiekcie.

Zaimplementuj nastêpuj¹ce klasy pochodne klasy ``Towar``:
- ``Gwozdzie``: posiadaj¹ca dodatkowe publiczne pola ``D³ugoœæ``, ``Gruboœæ`` i ``Rodzaj£epka``
- ``PapierScierny``: posiadaj¹ca dodatkowe publiczne pola ``Ziarnistoœæ`` i ``Szerokoœæ``
- ``Mebel``: posiadaj¹ca dodatkowe publiczne pole ``NazwaKolekcji``.
Wszystkie klasy pochodne klasy ``Towar`` powinny mieæ przeci¹¿on¹ metodê ``Opis``.

Zaimplementuj klasê ``Szafa`` pochodn¹ klasy ``Mebel``. 
Klasa ``Szafa`` powinna posiadaæ publiczne pola ``Wysokoœæ``, ``Szerokoœæ`` i ``G³êbokoœæ``. 
Metoda ``Opis`` powinna zostaæ przeci¹¿ona w taki sposób, 
¿eby wykorzystaæ kod metody ``Opis`` z klas bazowych.

Przetestuj swoje rozwi¹zanie.
