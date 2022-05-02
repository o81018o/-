// ==UserScript==
// @name         结果页
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
    var s = document.getElementsByTagName("td");
    var str = s[0].innerText;
    var m = s.length;
    for (var i = 1; i < m; i++)
    {
        str += "#" + s[i].innerText;
    }
    var ws = new WebSocket("ws://localhost:7181");
    ws.onopen = function(e){
        ws.send(str);
        ws.close();
        var z = document.getElementsByTagName('a');
        z[1].click();};
    // Your code here...
})();