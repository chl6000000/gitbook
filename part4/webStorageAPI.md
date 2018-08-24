# Web Storage API
>web storage API, 提供存储机制，保证浏览器可以安全存储键值对，比使用cookie更直观。都特定于页面的协议（http, http5）。 提供的两种存储机制：

>>sessionStorage，为每一个给定源维持一个独立的存储区域，该存储区域在页面会话期间可用（即浏览器打开期间可用，包括刷新和恢复），当页面被关闭时，数据存储在sessionStorage会被清除。 
>>localStorage, 一直存储在客户端，重新打开页面后数据仍然存在。

## Window.sessionStorage

>sessionStorage 属性允许访问一个session storage对象， 它与localStorage相似,不同之处在于localStorage里面存储的数据没有过期时间设置，而sessionStorage里面的数据在页面会话结束时会被清除。 页面会话中浏览器打开期间一直保持，并重新加载或恢复页面仍会保持原来的页面会话。 在新标签或窗口打开一个页面会初始化一个新的会话（和session cookies的运行方式不一样）。

```js
    sessionStorage.setItem('key','value');// save data to sessionStorage instance in current domain
    var data = sessionStorage.getItem('key');// get item from sessionStorage instance
    sessionStorage.removeItem('key');// remove item from sessionStorage instance
    sessionStorage.clear();// clear all items(reset) from sessionStorage instance

    //Demo : auto save textbox value if page be refreshed
    var field=document.getElementById("field");
    if(sessionStorage.getItem("autosave")) field.value=sessionStorage.getItem("autosave");

    field.addEventListener("change",function(){
        sessionStorage.setItem("autosave",field.value);
    });
```
