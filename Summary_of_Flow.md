# Summary
* step1: web pages analysis
    * get fragment of html node
    * find the key path/css characters
* step2: pages controls extract
    * use XPath/CssSelector to create instancev
* step1: page flow and input data priorities collection
    * learn bussiness logic, and create input data 
    


    var spans=$("icx-dynamic-view span");for(var i=0;i<spans.length;i++){string test=spans[i].innerHTML console.log(spans[i].innerHTML)}


var spans=$("icx-dynamic-view span");var reg=/<i>(\S*)<\/i>/ig;for(var i=0;i<spans.length;i++){var spantxt=spans[i].innerHTML.replace(spans[i].innerHTML.match(reg),'');console.log(spantxt)}