# Cattura schermo · AHG

Autore: **AHG** · Versione **0.2.0** · Microsoft Edge per Windows 10/11.

Mentre navighi con Edge browser, un clic sulla sua icona - da visualizzare nella barra dei strumenti - apre la cronologia dei testi e delle immagini copiati, richiamando **Windows + V**. Non c’è un menu intermedio. La scelta dell’appunto o dell’area da catturare avviene nel pannello di Windows.

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
