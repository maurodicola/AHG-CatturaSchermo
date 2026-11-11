// Autore: AHG
'use strict';
const HOST = "it.ahg.catturaschermo";
const ACTION = "capture";
const TITLE = "Cattura schermo \u00b7 AHG";
let busy = false;
function native(action) {
  return new Promise(resolve => {
    chrome.runtime.sendNativeMessage(HOST, {action}, response => {
      const error = chrome.runtime.lastError;
      resolve(error ? {ok: false, error: error.message} : (response || {ok: false, error: 'Nessuna risposta da Windows.'}));
    });
  });
}
async function run() {
  if (busy) return;
  busy = true;
  try {
    const result = await native(ACTION);
    const lastError = result.ok ? '' : (result.error || 'Impossibile aprire il pannello Windows.');
    await chrome.storage.session.set({lastError});
    await chrome.action.setBadgeText({text: lastError ? '!' : ''});
    await chrome.action.setTitle({title: lastError ? TITLE + ' — Apri la guida dalle opzioni' : TITLE});
    if (lastError) {
      await chrome.action.setBadgeBackgroundColor({color: '#a22e21'});
      await chrome.runtime.openOptionsPage();
    }
  } finally { busy = false; }
}
chrome.action.onClicked.addListener(() => {
  run().catch(error => console.error('AHG:', error.message));
});
chrome.runtime.onMessage.addListener((message, sender, reply) => {
  if (sender.id !== chrome.runtime.id || message?.type !== 'status') return false;
  native('ping').then(reply).catch(() => reply({ok: false}));
  return true;
});
