# Cattura schermo · AHG

**Cattura schermo · AHG** è un’estensione per Microsoft Edge su Windows che apre il pannello di cattura dello schermo di Windows con un clic sulla propria icona. Equivale a premere **Windows + Maiusc + S**.

**Autore: AHG** · Versione 0.2.0

## Download

[Scarica Cattura schermo 0.2.0 per Windows](downloads/AHG-CatturaSchermo-0.2.0.zip)

Il pacchetto include l’estensione, il sorgente del componente Windows e gli script per installarlo e rimuoverlo. Non è richiesta la pubblicazione nello Store di Edge.

## Installazione

1. Scarica lo ZIP qui sopra e scegli **Estrai tutto**.
2. Nella cartella estratta fai doppio clic su **Installa.cmd**. Non serve eseguirlo come amministratore. Attendi **Componente Windows installato**.
3. Apri **edge://extensions** in Edge.
4. Attiva **Modalità sviluppatore** e scegli **Carica estensione decompressa**.
5. Seleziona **%LOCALAPPDATA%\AHG\CatturaSchermo\extension**. L’installazione apre la cartella che la contiene.
6. Dal menu Estensioni di Edge rendi visibile **Cattura schermo · AHG** nella barra degli strumenti.
7. Clicca l’icona per aprire il pannello di Windows.

Non caricare soltanto la cartella extension senza eseguire Installa.cmd: manca altrimenti il collegamento al componente Windows.

## Requisiti

- Microsoft Edge su Windows 10/11.
- Windows PowerShell 5.1 e .NET Framework, normalmente inclusi in Windows.
- Possibilità di caricare estensioni manualmente. Su PC gestiti possono esserci restrizioni.

Il componente viene compilato sul computer dal sorgente incluso. Non occorrono Python o AutoHotkey. Il pacchetto non è firmato digitalmente. L’opzione PowerShell Bypass vale solo per l’esecuzione dello script e non modifica le impostazioni permanenti.

## Uso

Un clic sull’icona apre il pannello di sistema. Windows gestisce la scelta dell’appunto o della modalità di cattura. Per incollare dalla cronologia, seleziona prima il campo di testo di destinazione. Se Windows lo richiede, abilita la cronologia degli appunti. Le opzioni dello Strumento di cattura dipendono dalla versione installata.

## Risoluzione dei problemi

**Si apre la guida con “Specified native messaging host not found”.** Esegui Installa.cmd dal pacchetto estratto. Nella guida premi **Verifica collegamento**. Se appare “Collegamento riuscito”, riprova l’icona nella barra di Edge. Il vecchio messaggio rosso può restare visibile fino alla riapertura della pagina; si riferisce all’ultima operazione.

**Il collegamento riesce, ma il pannello non si apre.** Mantieni Edge in primo piano, rilascia i tasti e verifica la scorciatoia dalla tastiera. Non avviare Edge come amministratore.

**Vuoi riaprire la guida.** Fai clic destro sull’icona e scegli **Opzioni**.

## Dati e funzionamento

L’estensione non legge appunti, contenuti delle pagine o schermate e non invia dati in rete. Il componente locale riceve solo il comando previsto o una verifica del collegamento; richiama la scorciatoia di Windows e termina. L’eventuale errore viene conservato temporaneamente per mostrarlo nella guida.

I file vengono installati in **%LOCALAPPDATA%\AHG\CatturaSchermo**. La registrazione del componente riguarda soltanto l’utente corrente. I sorgenti sono in **extension/** e **native/**.

## Disinstallazione

Rimuovi **Cattura schermo · AHG** da **edge://extensions**, poi esegui **Disinstalla.cmd** dalla cartella estratta. Appunti e screenshot rimangono gestiti da Windows.

## Altra estensione AHG

[Appunti · AHG](https://github.com/maurodicola/AHG-Appunti) è installabile separatamente. Ciascun progetto ha il proprio componente: rimuovere uno non compromette l’altro.

## Stato del progetto

Prototipo personale. Verificate la sintassi JavaScript, la coerenza degli identificativi e la logica con API simulate. L’installazione completa e i pannelli richiedono verifiche su Windows; il risultato può dipendere dalla configurazione del computer.
