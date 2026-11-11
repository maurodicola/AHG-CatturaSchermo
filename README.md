# Cattura schermo · AHG

Autore: **AHG** · Versione **0.2.0** · Microsoft Edge per Windows 10/11.

Mentre navighi con Edge, un clic sulla sua icona - da far visualizzare nella barra degli strumenti - apre il pannello per scegliere rettangolo, finestra o schermo intero, richiamando **Windows + Maiusc + S**. Non c’è un menu intermedio. La scelta dell’area da catturare avviene nel pannello di Windows.

## Installazione

1. Estrai tutto lo ZIP in una cartella.
2. Apri **Installa.cmd** dalla cartella estratta. Non serve avviarlo come amministratore.
3. In Edge apri **edge://extensions** e attiva **Modalità sviluppatore**.
4. Scegli **Carica estensione decompressa** e seleziona **%LOCALAPPDATA%\AHG\CatturaSchermo\extension**. Il programma di installazione apre la cartella che la contiene.
5. Dal menu Estensioni rendi visibile **Cattura schermo · AHG** nella barra degli strumenti.
6. Clicca la nuova icona per aprire il pannello.

Puoi installare solo questa estensione o anche l’altra: sono indipendenti e ciascuna ha il suo componente Windows. Rimuovere una non compromette l’altra.

## Se hai già Clic Windows

Puoi rimuovere la precedente estensione **Clic Windows** da edge://extensions e usare il suo vecchio **Disinstalla.cmd** per rimuovere il componente precedente. I nuovi componenti AHG sono in cartelle diverse e non vengono rimossi dal vecchio script. Non devi disinstallare Clic Windows per provare queste nuove estensioni.

## Uso e problemi

Per incollare un appunto, fai prima clic nel campo di testo desiderato. Se la cronologia è disattivata, abilitala nel pannello di Windows quando richiesto. Le modalità di cattura disponibili dipendono dalla versione dello Strumento di cattura.

Se compare **!** sull’icona, si apre la guida con l’errore. Puoi ritrovare la guida facendo clic destro sull’icona e scegliendo **Opzioni**. Dalla guida puoi verificare il collegamento al componente. Una successiva apertura del pannello riuscita cancella il punto esclamativo.

Mantieni Edge in primo piano e rilascia i tasti della tastiera. Controlla che **Windows + Maiusc + S** funzioni dalla tastiera. Non avviare Edge come amministratore. Se manca il componente, avvia Installa.cmd e riprova; se serve riavvia Edge.

Il pacchetto personale non ha una firma digitale. Se Windows mostra un avviso che non sai interpretare, riporta il messaggio a Gaia. Edge può ricordare che la Modalità sviluppatore è attiva.

## Installazione e dati

Serve Windows PowerShell 5.1 con .NET Framework, normalmente inclusi in Windows 10/11; non servono Python o AutoHotkey. Il componente viene compilato sul PC dal sorgente incluso. L’opzione Bypass vale solo per l’esecuzione dello script e non cambia permanentemente le impostazioni di PowerShell. Criteri aziendali possono impedire l’installazione manuale.

File installati: **%LOCALAPPDATA%\AHG\CatturaSchermo**. Registrazione del solo utente: **HKCU\Software\Microsoft\Edge\NativeMessagingHosts\it.ahg.catturaschermo**.

L’estensione non legge appunti, pagine o screenshot e non invia dati in rete. Il componente richiama solo il suo pannello e termina. L’eventuale errore resta nello stato temporaneo dell’estensione.

## Disinstallazione

Rimuovi **Cattura schermo · AHG** da edge://extensions, poi avvia **Disinstalla.cmd** da questo pacchetto estratto. Rimuove solo il proprio componente. Non cancella appunti o screenshot.

## Verifica

Controllate sintassi JavaScript, coerenza degli identificativi, pacchetti e logica dei comandi tramite API simulate. Apertura effettiva del pannello e installazione da verificare su Windows; in questo ambiente non è disponibile una prova completa con Edge e Windows. Il successo indica che Windows ha accettato i tasti, senza una verifica visiva del pannello.

Sorgenti inclusi. Documentazione tecnica: https://learn.microsoft.com/en-us/microsoft-edge/extensions/developer-guide/native-messaging e https://developer.chrome.com/docs/extensions/reference/api/action

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
