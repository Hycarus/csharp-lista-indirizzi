Oggi esercitazione sui file, ossia vi chiedo di prendere dimestichezza con quanto appena visto sui file in classe, in particolare nel live-coding di oggi.

In questo esercizio dovrete leggere un file CSV, che cambia poco da quanto appena visto nel live-coding in classe, e salvare tutti gli indirizzi in esso contenuti all’interno di una lista di oggetti istanziati a partire dalla classe Indirizzo.

Attenzione: gli ultimi 3 indirizzi presentano dei possibili “casi particolari” che possono accadere a questo genere di file: vi chiedo di pensarci e di gestire come meglio crediate queste casistiche.

Bonus: iterare la lista di indirizzi e risalvarli in un file.



Vogliamo realizzare il gioco del tris.

Si gioca da console.

Ci sono due giocatori e si gioca a turni.
Ad ogni turno viene disegnata la griglia di gioco.
Una versione molto semplice :

 123
1
2
3

Inizia il giocatore A scegliendo la giocata da fare indicando la riga e la colonna della griglia nella quale posizionare la sua pedina (es. 1-2 significa riga 1 colonna 2).

 123
1A
2
3

A quel punto viene ridisegnata la griglia e si verifica se il giocatore ha vinto.

In caso contrario tocca al giocatore B e anche lui sceglie la sua giocata.
 123
1A
2  B
3

Si continua così finchè tutte le caselle sono state occupate o finchè un giocatore ha vinto.

Bonus : creare una griglia graficamente più elaborata (ad esempio disegnando le caselle)
———————-
| # | 1 | 2 | 3 |
———————-
| 1 | A | B | A |
———————-
| 2 | B | A | B |
———————-
| 3 | A | B | A |
———————-

Bonus+++ : fare in modo che il giocatore B non sia mosso da un umano ma da una qualche intelligenza artificiale sviluppata da noi……