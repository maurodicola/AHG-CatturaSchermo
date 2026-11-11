// Autore: AHG
'use strict';
const error = document.getElementById('error');
chrome.storage.session.get('lastError').then(saved => {
  error.textContent = saved.lastError ? 'Ultima operazione: ' + saved.lastError : 'Nessun errore registrato. Usa l’icona nella barra di Edge per aprire il pannello.';
});
document.getElementById('check').addEventListener('click', async () => {
  const result = document.getElementById('result');
  result.textContent = 'Verifica in corso…';
  try {
    const reply = await chrome.runtime.sendMessage({type:'status'});
    result.textContent = reply?.ok ? 'Collegamento riuscito. Ora prova l’icona nella barra di Edge.' : 'Componente non disponibile. Avvia Installa.cmd e riprova.';
  } catch { result.textContent = 'Collegamento non disponibile. Chiudi e riapri Edge.'; }
});
