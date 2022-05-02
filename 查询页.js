// ==UserScript==
// @name         查询页
// @namespace    http://tampermonkey.net/
// @version      0.1
// @description  try to take over the world!
// @author       You
// @match       
// @icon         data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==
// @grant        none
// ==/UserScript==

(function() {
    'use strict';
    var ws = new WebSocket("ws://localhost:7182");
    ws.onopen = function(e){
        ws.send('n');};
    ws.onmessage = function(e){
        var s = document.getElementsByTagName("input");
        var t = e.data.split(' ');
        s[0].value = t[0];
        s[1].value = t[1];
        var z =document.getElementById("yiDunSubmitBtn");
        ws.close();
        z.click();};
    // Your code here...
})();