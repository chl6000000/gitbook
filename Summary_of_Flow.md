# Summary
* step1: web pages analysis
    * get fragment of html node
    * find the key path/css characters
* step2: pages controls extract
    * use XPath/CssSelector to create instancev
* step1: page flow and input data priorities collection
    * learn bussiness logic, and create input data 
    

------------------------------------------
<pre><code>
--Find all text under span element.
var spans = $("icx-dynamic-view span");
var reg = /<i>(\S*)<\/i>/ig;

for (var i = 0; i < spans.length; i++) {
    if (spans[i].firstChild && spans[i].firstChild.data)
        if (spans[i].firstChild.data.trim().length > 1)
            console.log(spans[i].firstChild.data)
}
</code></pre>
---------------------------------------------